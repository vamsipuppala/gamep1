using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    //public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public LogicManagerScript logic;
    public NextLevelScript nextLevel;
    public GameObject NextLevelScreen;
    public string wordCreated;
    public string lol1;
    public string dangerWordCreated;
    //public float move;
    int numberOfHits;
    int localHits = 1;
    [SerializeField]  private TextMeshProUGUI  goodword;
    [SerializeField]  public TextMeshProUGUI dangerWord;
    public string dummy;
    public Text text1 ;
    public Text text2;
    List<GameObject[]> nestedList;
    public string final;
    public float moveSpeed;
    public float st, ct;
    public GameObject c;
    public static int timesDangerWordWasHit = 0;
    
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public NextLevelScript nextLevelScript;


    int ind=0;
    void Start()
    {
        ind=0;
        st = Time.time;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        //nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>();
        nestedList = bs.nestedList;
        //final = "Aim: " + bs.words[ind];
        nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<NextLevelScript>();
        nextLevelScript.resetValues();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("finalllllllllllllll" + final);
        //goodword.text = final;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
        goodword.text = "Target:  " + bs.words[ind];
        dangerWord.text = "Danger:  " + bs.dangerWordss[ind];
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //Vector2 direction = new Vector2(
            //mousePosition.x - transform.position.x,
          //  mousePosition.y - transform.position.y);
        //transform.up = direction;
        // move = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);
        float move = Input.GetAxis("Horizontal");

        //rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);
        rb.velocity = new Vector2((moveSpeed) * move, rb.velocity.y);
        float move2 = Input.GetAxis("Vertical");
        if (move2 < 0 && !(transform.localEulerAngles.z > 300))
        {
            //  Debug.Log("inside move2"+transform.localEulerAngles+ transform.localRotation.eulerAngles.y);
            transform.Rotate(0, 0, move2 * (2f));
        }
        else if (move2 > 0 && !(transform.localEulerAngles.z >= 180 && transform.localEulerAngles.z <= 270))
        {
            //    Debug.Log("inside move1"+transform.position.x+ transform.position.y );
            transform.Rotate(0, 0, move2 * (2f));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            st = Time.time;
            LineOfSight.positionCount = 1;
            LineOfSight.SetPosition(0, transform.position);

            //Debug.Log(transform.position);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
            // Ray
            Ray2D ray = new Ray2D(transform.position, transform.right);

            bool isMirror = false;
            Vector2 mirrorHitPoint = Vector2.zero;
            Vector2 mirrorHitNormal = Vector2.zero;

            move = Input.GetAxisRaw("Horizontal");
            String givenWord = bs.words[j];
            string givenDangerWord = bs.dangerWordss[j];
            

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
                        
                       // Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                        numberOfHits = givenWord.Length;
                       // Debug.Log("now the numberOfHits is " + numberOfHits);
                        TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                        if(j==GetIndexOfGameObject(gameObject, nestedList))
                        {

                            if (gameObject.GetComponent<SpriteRenderer>().color == Color.gray || gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                            {
                                localHits--;
                                if (gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                                {
                                                                     
                                    wordCreated = wordCreated.Replace(text.text.ToString(), "");
                                                          

                                }
                                if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                                {
                                    dangerWordCreated = dangerWordCreated.Replace(text.text.ToString(), "");
                                }

                                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                                
                               // Debug.Log("hurrrrrayyyyy" + localHits);
                            }
                            else
                            {

                                if (localHits > numberOfHits)
                                {
                                   // Debug.Log("no shooting");
                                }
                                else
                                {
                                    localHits++;
                                    if (givenDangerWord.Contains(text.text.ToString()))
                                    {
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                        dangerWordCreated += text.text;
                                        //Debug.Log("the danger word created till now is" + dangerWordCreated);
                                    }
                                    
                                        if (!givenWord.Contains(text.text.ToString()) && !givenDangerWord.Contains(text.text.ToString()))
                                            gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                                        else if (givenWord.Contains(text.text.ToString()))
                                        {
                                            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                                            //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);
                                        wordCreated += text.text;
                                       /* if (wordCreated.Length != bs.words[j].Length && goodword.text.IndexOf(wordCreated)!=-1)
                                        {
                                            Debug.Log("word createeeeeeddddddd" + wordCreated);
                                            string s = goodword.text.Substring(goodword.text.IndexOf(wordCreated), wordCreated.Length + 1);
                                            dummy = goodword.text;
                                            string s1 = dummy.Replace(s, "");
                                            final = s1 + "<u>" + s + "</u>";
                                            goodword.text = final;
                                        }*/
                                            
                                      
                                        //Debug.Log("GIVEN WORD: " + givenWord);
                                    }
                                   
                                   
                                    if(dangerWordCreated.Length == bs.dangerWordss[j].Length)
                                    {
                                        
                                        if(findMatch(dangerWordCreated, bs.dangerWordss[j]))
                                        {
                                            //Debug.Log("dangerrrrrr");
                                            timesDangerWordWasHit += 1;
                                            ScoreScript.PlayerScore -= 1;

                                        }
                                    }

                                    if (wordCreated.Length == bs.words[j].Length)
                                    {

                                       // Debug.Log("the word is       " + wordCreated);
                                        if (findMatch(wordCreated, bs.words[j]))
                                        {
                                            //Debug.Log(bs);
                                            GameObject[] gs = bs.nestedList[j];
                                            ScoreScript.PlayerScore += 1;
                                            for (int k = 0; k < gs.Length; k++)
                                            {
                                                Destroy(gs[k]);
                                            }
                                            wordCreated = "";
                                            dangerWordCreated = "";                                            
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
        else
        {
            if (Time.time - st > (float)0.5)
            {//Debug.Log("************");
                //LineOfSight.SetVertexCount(0);
                LineOfSight.positionCount = 0;
            }
        }
    }

    //private void FixedUpdate()
    //{      
        //rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        

    //}

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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  Debug.Log("oncollision - ");
    // logic.gameOver();
    //}
}