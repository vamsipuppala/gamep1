using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;

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
    public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public string wordCreated;
    public float move;
    int numberOfHits;
    int localHits = 1;
     [SerializeField] private TextMeshProUGUI  goodword;
    List<GameObject[]> nestedList;

    LogicManagerScript logic;
     int ind=0;
    void Start()
    {
        int ind=0;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
        // logic = GameObject.FindGameObjectWithTag("LogicManagerScript").GetComponent<LogicManagerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        nestedList = bs.nestedList;
    }

    // Update is called once per frame
    void Update()
    {
        goodword.text = "Aim: "+bs.wordsss[ind];
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        transform.up = direction;
        // move = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);
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

            move = Input.GetAxisRaw("Horizontal");
            String givenWord = bs.wordsss[j];
            

            // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);

            for (int i = 0; i < reflections; i++)
            {
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.name.Contains("LetterSquare"))
                    {
                        //Debug.Log("GIVEN WORD: " + givenWord);
                        nestedList = bs.nestedList;
                        GameObject gameObject = hitInfo.collider.gameObject;
                        
                        Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                        numberOfHits = givenWord.Length;
                        Debug.Log("now the numberOfHits is " + numberOfHits);
                        TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                        if(j==GetIndexOfGameObject(gameObject, nestedList))
                        {
                            if (gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                            {
                                localHits--;
                                if (gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                                {
                                    wordCreated = wordCreated.Replace(text.text.ToString(), "");
                                }
                                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                                if (localHits < 0)
                                {
                                    localHits = 1;
                                }
                                Debug.Log("hurrrrrayyyyy" + localHits);
                            }
                            else
                            {

                                if (localHits > numberOfHits)
                                {
                                    Debug.Log("no shooting");
                                }
                                else
                                {
                                    localHits++;

                                    if (!givenWord.Contains(text.text.ToString()))
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                    else if (givenWord.Contains(text.text.ToString()))
                                    {
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                                        //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);
                                        wordCreated += text.text;
                                        //Debug.Log("GIVEN WORD: " + givenWord);
                                    }


                                    if (wordCreated.Length == bs.wordsss[j].Length)
                                    {

                                        Debug.Log("the word is       " + wordCreated);
                                        if (findMatch(wordCreated, bs.wordsss[j]))
                                        {
                                            Debug.Log(bs);
                                            GameObject[] gs = bs.nestedList[j];
                                            for (int k = 0; k < gs.Length; k++)
                                            {
                                                Destroy(gs[k]);
                                            }
                                            wordCreated = "";
                                            j++;
                                            ind++;
                                            localHits = 1;
                                        }
                                    }
                                }

                            }
                        }
                       

                       

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

    private void FixedUpdate()
    {      
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        

    }

    private int GetIndexOfGameObject(GameObject target, List<GameObject[]> list)
    {
        for (int i = 0; i < list.Capacity; i++)
        {
            if (list[i].Contains(target))
            {
                return i;
            }
        }
        return -1;
    }



    private bool findMatch(string createdWord, string givenWord)
    {
       
        var s1Array = createdWord.ToCharArray();
        var s2Array = givenWord.ToCharArray();

        Array.Sort(s1Array);
        Array.Sort(s2Array);

        createdWord = new string(s1Array);
        givenWord = new string(s2Array);

        return string.Equals(createdWord, givenWord, StringComparison.OrdinalIgnoreCase);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("oncollision - ");
        logic.gameOver();
    }
}