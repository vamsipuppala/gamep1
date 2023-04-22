using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L1_PlayerControllerOne : MonoBehaviour
{
    // Start is called before the first frame update
    // Line OF Renderer
    public LineRenderer LineOfSight;
    public LineRenderer LineOfSight2;
    public Animator animator;
    public float blinkTime = 1000.5f;
    float rotateSpeed = 50f;
    int j = 0;
    public BlockSpawnerScript bs;
    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    //public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public LogicManagerScript logic;
    public NextLevel nextLevel;
    public GameObject NextLevelScreen;
    public string wordCreated;
    public string lol1;
    //public string dangerWordCreated;
    //public float move;
    int numberOfHits;
    [SerializeField]  private TextMeshProUGUI  goodword;
    //[SerializeField]  public TextMeshProUGUI dangerWord;
    public string dummy;
    public Text text1 ;
    public Text text2;
    public GameObject canvas;
    List<GameObject[]> nestedList;
    public string final;
    public float moveSpeed;
    public float st, ct;
    public GameObject c;
    //public static int timesDangerWordWasHit = 0;
    
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public L1_NextLevel nextLevelScript;
    public static int timeTargetWordWasHit = 0;
    public static int numberOfTimeDeselectionsOccurred = 0;
    public static int numberOfTimesWordHitInOrder = 0;
    public static int numberOfTimesWordHitInReverse = 0;
    private Text textComponent;
    public TextMeshProUGUI aim;



    
    void Start()
    {
        string folderName = "Videos";
        string fileName = "L1-Guide";

        string fileFormat = ".mp4";

        UnityEngine.Video.VideoPlayer videoPlayer;

        // Find the VideoPlayer component in the Canvas hierarchy
        videoPlayer = canvas.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
        //string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName + fileFormat);
        string filePath = Application.streamingAssetsPath + "/" + fileName + fileFormat;
        Debug.Log("Filepath: " + filePath);
        videoPlayer.url = filePath;

        st = Time.time;
        Physics2D.queriesStartInColliders = false;
        Physics2D.IgnoreCollision(canvas.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        //nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>();
        nestedList = bs.nestedList;
        //final = "Aim: " + bs.words[ind];
        nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<L1_NextLevel>();
        nextLevelScript.resetValues();
        // LineOfSight2.startWidth = 0.0544548;
        Debug.Log("width: "+LineOfSight2.startWidth);

    }//0.0544548

    // Update is called once per frame
   
    void Update()
    {
        textComponent = GetComponent<Text>();
        
        LineOfSight2.positionCount = 1;
        LineOfSight2.SetPosition(0, transform.position);

        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
        // Ray
        Ray2D ray2 = new Ray2D(transform.position, transform.right);

        bool isMirror2 = false;
        Vector2 mirrorHitPoint2 = Vector2.zero;
        Vector2 mirrorHitNormal2 = Vector2.zero;

        for (int i = 0; i < reflections; i++)
        {
            LineOfSight2.positionCount += 1;

            if (hitInfo2.collider != null)
            {
                LineOfSight2.SetPosition(LineOfSight2.positionCount - 1, hitInfo2.point - ray2.direction * -0.1f);

                isMirror2 = false;
                if (hitInfo2.collider.CompareTag("Mirror"))
                {
                    mirrorHitPoint2 = (Vector2)hitInfo2.point;
                    mirrorHitNormal2 = (Vector2)hitInfo2.normal;
                    hitInfo2 = Physics2D.Raycast((Vector2)hitInfo2.point - ray2.direction * -0.1f, Vector2.Reflect(hitInfo2.point - ray2.direction * -0.1f, hitInfo2.normal), MaxRayDistance, LayerDetection);
                    isMirror2 = true;
                }
                else
                    break;
            }
            else
            {
                if (isMirror2)
                {
                    LineOfSight2.SetPosition(LineOfSight2.positionCount - 1, mirrorHitPoint2 + Vector2.Reflect(mirrorHitPoint2, mirrorHitNormal2) * MaxRayDistance);
                    break;
                }
                else
                {
                    LineOfSight2.SetPosition(LineOfSight2.positionCount - 1, transform.position + transform.right * MaxRayDistance);
                    break;
                }
            }
        }


        
        //j is the index of the last row of blocks
       // if (nestedList[j][0].transform.position.y < 3)
        //{
          //  nextLevelScript.GameOver("blocksTouchedPlayer");
        //}
        

        //Debug.Log("finalllllllllllllll" + final);
        //goodword.text = final;
       
        // goodword.text = "Target:  " + bs.words[ind][0];
        //dangerWord.text = "Danger:  " + bs.dangerWordss[ind];
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
        
        float move2 = Input.GetAxis("Vertical") * rotateSpeed;
        if (move2 < 0 && !(transform.localEulerAngles.z > 300))
        {   
            //  Debug.Log("Move2"+move2);
            //     Debug.Log("delta"+Time.deltaTime);
            //     Debug.Log("Total"+move2 * Time.deltaTime);
            //  Debug.Log("inside move2"+transform.localEulerAngles+ transform.localRotation.eulerAngles.y);
            transform.Rotate(0, 0, move2 * Time.deltaTime);
        }
        else if (move2 > 0 && !(transform.localEulerAngles.z >= 180 && transform.localEulerAngles.z <= 270))
        {
            //    Debug.Log("inside move1"+transform.position.x+ transform.position.y );
            transform.Rotate(0, 0, move2 * Time.deltaTime);
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
            String givenWord = bs.words[j][0];
            //string givenDangerWord = bs.dangerWordss[j];
            

            // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);

            for (int i = 0; i < reflections; i++)
            {
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.name.Contains("LetterSquare"))
                    {
                        //Debug.Log("GIVEN WORD: " + givenWord);
                    //     nestedList = bs.nestedList;
                        GameObject gameObject = hitInfo.collider.gameObject;
                        Destroy(gameObject);
                         ScoreScript.PlayerScore+=1;
                         animator.SetTrigger("change");
                        
                    //    // Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                    //     numberOfHits = givenWord.Length;
                    //    // Debug.Log("now the numberOfHits is " + numberOfHits);
                    //     TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                    //     if(j==GetIndexOfGameObject(gameObject, nestedList))
                    //     {
                    //         Debug.Log("INSIDE IF GetIndexOfGameObject");

                    //         if (gameObject.GetComponent<SpriteRenderer>().color == Color.gray || gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                    //         {
                    //             localHits--;
                    //             numberOfTimeDeselectionsOccurred++;
                    //             if (gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                    //             {
                                                                     
                    //                 wordCreated = wordCreated.Replace(text.text.ToString(), "");
                                                          

                    //             }
                    //             /*
                    //             if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                    //             {
                    //                 dangerWordCreated = dangerWordCreated.Replace(text.text.ToString(), "");
                    //             }
                    //             */
                    //             gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                                
                    //            // Debug.Log("hurrrrrayyyyy" + localHits);
                    //         }
                    //         else
                    //         {

                    //             if (localHits > numberOfHits)
                    //             {
                    //                 Debug.Log("no shooting");
                    //             }
                    //             else
                    //             {
                    //                 localHits++;
                    //                 /*
                    //                 if (givenDangerWord.Contains(text.text.ToString()))
                    //                 {
                    //                     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    //                     dangerWordCreated += text.text;
                    //                     //Debug.Log("the danger word created till now is" + dangerWordCreated);
                    //                 }
                    //                 */
                                    
                    //                     //if (!givenWord.Contains(text.text.ToString()) && !givenDangerWord.Contains(text.text.ToString()))
                    //                     if (!givenWord.Contains(text.text.ToString()))
                    //                         gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                    //                     else if (givenWord.Contains(text.text.ToString()))
                    //                     {
                    //                         gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                    //                         //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);
                    //                     wordCreated += text.text;
                    //                    /* if (wordCreated.Length != bs.words[j].Length && goodword.text.IndexOf(wordCreated)!=-1)
                    //                     {
                    //                         Debug.Log("word createeeeeeddddddd" + wordCreated);
                    //                         string s = goodword.text.Substring(goodword.text.IndexOf(wordCreated), wordCreated.Length + 1);
                    //                         dummy = goodword.text;
                    //                         string s1 = dummy.Replace(s, "");
                    //                         final = s1 + "<u>" + s + "</u>";
                    //                         goodword.text = final;
                    //                     }*/
                                            
                                      
                    //                     //Debug.Log("GIVEN WORD: " + givenWord);
                    //                 }

                    //                 /*
                    //                 if(dangerWordCreated.Length == bs.dangerWordss[j].Length)
                    //                 {
                                        
                    //                     if(findMatch(dangerWordCreated, bs.dangerWordss[j]))
                    //                     {
                    //                         //Debug.Log("dangerrrrrr");
                    //                         timesDangerWordWasHit += 1;
                    //                         ScoreScript.PlayerScore -= 1;

                    //                     }
                    //                 }*/

                    //                 Debug.Log("bs.words[j]: "+ bs.words[j][0]);

                    //                 if (wordCreated.Length == bs.words[j][0].Length && findMatch(wordCreated, bs.words[j][0]))
                    //                 {
                    //                     if (bs.words[j][0].Equals(wordCreated))
                    //                     {
                    //                         numberOfTimesWordHitInOrder++;
                    //                     }
                    //                     if (Reverse(bs.words[j][0]).Equals(wordCreated))
                    //                     {
                    //                         numberOfTimesWordHitInReverse++;
                    //                     }
                    //                     //IF WORD IS SPELLED IN ORDER - REWARD THE PLAYER
                    //                     if (bs.words[j][0].Equals(wordCreated) || Reverse(bs.words[j][0]).Equals(wordCreated))
                    //                     {
                    //                         Debug.Log("HELLO JI LEVEL 1- destroying 2 rows, score+2");
                    //                         ScoreScript.PlayerScore += 2;
                    //                         for (int d=0; d<2; d++)
                    //                         {
                    //                             if (d < nestedList.Count)
                    //                             {
                    //                                 GameObject[] gs = bs.nestedList[j];
                    //                                 for (int k = 0; k < gs.Length; k++)
                    //                                 {
                    //                                     Destroy(gs[k]);
                    //                                 }
                    //                                 timeTargetWordWasHit += 1;
                    //                                 wordCreated = "";
                    //                                 j++;
                    //                                 ind++;
                    //                                 localHits = 1;
                    //                             }
                    //                         }

                    //                     }

                    //                     // Debug.Log("the word is       " + wordCreated);
                    //                     else if (findMatch(wordCreated, bs.words[j][0]))
                    //                     {
                    //                         //Debug.Log(bs);
                    //                         GameObject[] gs = bs.nestedList[j];
                    //                         ScoreScript.PlayerScore += 1;
                    //                         for (int k = 0; k < gs.Length; k++)
                    //                         {
                    //                             Destroy(gs[k]);
                    //                         }
                    //                         wordCreated = "";
                    //                         //dangerWordCreated = "";                                            
                    //                         j++;
                    //                         ind++;
                    //                         localHits = 1;
                    //                     }
                    //                 }
                    //             }

                    //         }
                    //     }
                       

                       

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
                //Debug.Log("SET VERTEXT COUNT - OBSOLETE");
                //LineOfSight.SetVertexCount(0);
                
                LineOfSight.positionCount = 0;
            }

            // blinking color change effect
            /*
             if (Time.time - blinkTime > (float)0.5){
                blinkTime=Time.time;
            // aim.enabled = !aim.enabled;
            aim.color = UnityEngine.Random.ColorHSV();
             }
            */
        }
    }

    //private void FixedUpdate()
    //{      
    //rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);


    //}
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, 1f, groundLayer);

    }

    // private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  Debug.Log("oncollision - ");
    // logic.gameOver();
    //}

    // When blocks collide with the player => Game over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("PC1 --- COLLISION");
        Debug.Log("*****************");
        Debug.Log("COLLIDE (name) : " + collision.gameObject.name);

        if (collision.gameObject.name == "ColoredLetterSquare1(Clone)")
        {
            //Debug.Log("GAME OVER BOI !!!!!!");
            //gameOverReason = "GAME OVER DUE TO COLLISION !!!";

            // Set the game over reason on the GameOver scene.
            PlayerPrefs.SetString("GameOverReason", "Game terminated due to collision!");
            SceneManager.LoadScene("GameOver");
        }

    }

}