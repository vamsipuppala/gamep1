using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float t = 0;
    Vector3 startPosition;
    public float pauseDuration = 1f;
    public bool first = false;
    public bool moveforward = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MoveDown());
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
            
        StartCoroutine(MoveDown());
        //transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        //new WaitForSeconds(pauseDuration);
        //StartCoroutine(MoveDown());
        // if (transform.position.y < deadZone)
        //{
        //Debug.Log("pipe deleted");
        // Destroy(gameObject);
        //}
    }
   
    IEnumerator MoveDown()
    {
        
        while (true)
        {
            
            Vector3 endPosition = startPosition - Vector3.up * moveSpeed * Time.deltaTime;
            
            float t = 0.0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
               yield return null;
            }
            startPosition = endPosition + Vector3.down * 0.1f;

            yield return new WaitForSeconds(pauseDuration);
        }
    }
}
