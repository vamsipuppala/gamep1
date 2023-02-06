using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Line OF Renderer
    public LineRenderer LineOfSight;
    int j = 0;
    public BlockSpawnerScript bs;
    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    public float moveSpeed;
    private Rigidbody2D rb;
    public string wordCreated;
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        transform.up = direction;
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);

        if (Input.GetButtonDown("Fire1"))
        {

            LineOfSight.positionCount = 1;
            LineOfSight.SetPosition(0, transform.position);

            Debug.Log(transform.position);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
            // Ray
            Ray2D ray = new Ray2D(transform.position, transform.right);

            bool isMirror = false;
            Vector2 mirrorHitPoint = Vector2.zero;
            Vector2 mirrorHitNormal = Vector2.zero;

            // float move = Input.GetAxis("Horizontal");

            // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);

            for (int i = 0; i < reflections; i++)
            {
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.name.Contains("LetterSquare"))
                    {
                        GameObject gameObject = hitInfo.collider.gameObject;
                        TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                        Debug.Log("%%%%%%%%%%%%%%" + text.text);
                        wordCreated += text.text;
                        Debug.Log("the word is       " + wordCreated);
                        if (string.Equals(wordCreated, bs.wordss[j], StringComparison.OrdinalIgnoreCase))
                        {
                            Debug.Log(bs);
                            GameObject[] gs = bs.nestedList[j];
                            for (int k = 0; k < gs.Length; k++)
                            {
                                Destroy(gs[k]);
                            }
                            wordCreated = "";
                            j++;
                        }

                        // change this if we need to restart the laser beam


                    }
                    LineOfSight.SetPosition(LineOfSight.positionCount - 1, hitInfo.point - ray.direction * -0.1f);

                    isMirror = false;
                    if (hitInfo.collider.CompareTag("Mirror"))
                    {
                        // mirrorHitPoint = (Vector2)hitInfo.point;
                        // mirrorHitNormal = (Vector2)hitInfo.normal;
                        // hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(hitInfo.point - ray.direction * -0.1f, hitInfo.normal), MaxRayDistance, LayerDetection);
                        // isMirror = true;
                        mirrorHitPoint = (Vector2)hitInfo.point;
                        mirrorHitNormal = (Vector2)hitInfo.normal;
                        hitInfo = Physics2D.Raycast((Vector2)hitInfo.point - ray.direction * -0.1f, Vector2.Reflect(hitInfo.point - ray.direction * -0.1f, hitInfo.normal), MaxRayDistance, LayerDetection);
                        isMirror = true;
                    }
                    else
                        break;
                }
                else
                {

                    if (isMirror)
                    {
                        LineOfSight.SetPosition(LineOfSight.positionCount - 1, mirrorHitPoint + Vector2.Reflect(mirrorHitPoint, mirrorHitNormal) * MaxRayDistance);
                        break;
                    }
                    else
                    {
                        LineOfSight.SetPosition(LineOfSight.positionCount - 1, transform.position + transform.right * MaxRayDistance);
                        break;
                    }
                }
            }
        }
    }
}