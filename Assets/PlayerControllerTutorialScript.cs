using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerControllerTutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    // Line OF Renderer
    public LineRenderer LineOfSight;
    int j = 0;
    public BlockSpawnerTutorialScript bs;
    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    [SerializeField] private Rigidbody2D rb;
    public LogicManagerScript logic;
    public NextLevelScript nextLevel;
    public GameObject NextLevelScreen;
    public string wordCreated;
    public string lol1;
    public string dangerWordCreated;
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
    [SerializeField] private LayerMask groundLayer;

    public GameObject[] popUps;

    //public NextLevelScript nextLevelScript;

    int ind=0;

    int popUpIndex = 0;
    private bool isMatch = true;
    //, isLetterX = false, isLetterB = false, isLetterS = false;
    void Start()
    {
        int ind=0;
        st = Time.time;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerTutorialScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>();
        nestedList = bs.nestedList;
       // nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<NextLevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //HINT 0 - Shoot blocks of letters  to form target word. Press enter to Begin
        if (popUpIndex == 0)
        {
            popUps[0].SetActive(true);
            Debug.Log("HELLOOOOO");
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Inside hint0 if");
                popUps[0].SetActive(false);
                //Time.timeScale = 1;
                popUpIndex++;
            }
        }
        //HINT 1 - Press LEFT & RIGHT Arrow Key to Move
        else if (popUpIndex == 1)
        {
            popUps[1].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUps[1].SetActive(false);
                popUpIndex++;
            }

        }
        //HINT 2 - Use UP & DOWN Arrow Key to change direction of laser beam
        else if (popUpIndex == 2)
        {
            popUps[2].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                popUps[2].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }
        //HINT 3 - Press LEFT CTRL to shoot & select the letter, ask to shoot B
        else if (popUpIndex == 3)
        {
            popUps[3].SetActive(true);
            popUps[13].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[3].SetActive(false);
                popUps[13].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }

        //HINT 4: correct letter green
        else if (Input.GetKeyDown(KeyCode.Return) && popUpIndex == 4)
        {
            Debug.Log("Inside IFFFF green----");
            popUps[4].SetActive(false);
            popUpIndex++;
            Time.timeScale = 1;
        }

        else if (popUpIndex == 5)
        {
            //ASK USER TO SHOOT X
            popUps[14].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[14].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }

        //INCORRECT LETTER GRAY
        else if (Input.GetKeyDown(KeyCode.Return) && popUpIndex == 6)
        {
            //incorrect letter highlighted in gray
            Debug.Log("Inside IFFFF gray----");
            popUps[5].SetActive(false);
            popUpIndex++;
            Time.timeScale = 1;
        }
       
        else if (popUpIndex == 7)
        {
            //ASK USER TO SHOOT X again & deselect
            popUps[6].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[6].SetActive(false);
                popUpIndex++;           //popUpIndex=8
            }
            Time.timeScale = 1;
        }

        else if (popUpIndex == 8)
        {
            //ASK USER TO SHOOT S
            popUps[15].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[15].SetActive(false);
                popUpIndex++;   //popUpIndex=9
            }
            Time.timeScale = 1;
        }

        //DANGER LETTER RED
        else if (Input.GetKeyDown(KeyCode.Return) && popUpIndex == 10)
        {
            //incorrect letter highlighted in gray
            Debug.Log("Inside IFFFF red----");
            popUps[10].SetActive(false);
            popUps[18].SetActive(true);
            popUpIndex++;   //popUpIndex=11
            Time.timeScale = 1;
        }

        else if(!isMatch && popUps[7].activeSelf == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            popUps[7].SetActive(false);
            Time.timeScale = 1;
            isMatch = true;
        }

        else if(popUps[9].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            popUps[9].SetActive(false);
            popUps[11].SetActive(true);
        }

        else if (popUps[11].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            popUps[11].SetActive(false);
            popUps[17].SetActive(true);
        }

        else if (popUps[17].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            popUps[17].SetActive(false);
            popUps[12].SetActive(true);
        }

        else if (popUps[12].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            popUps[12].SetActive(false);
            popUps[16].SetActive(true);
        }

        else if(popUps[16].activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            //switch to level 1
           // nextLevelScript.resetValues();
            SceneManager.LoadScene("LevelOne");
        }


        /*
         -------------------------------------------------
         */

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }
        goodword.text = "Target:" + bs.words[ind];
         dangerWord.text = "Danger:" + bs.dangerWordss[ind];
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      
        float move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2((moveSpeed) * move, rb.velocity.y);
        float move2 = Input.GetAxis("Vertical");
        if (move2 < 0 && !(transform.localEulerAngles.z > 300))
        {
            transform.Rotate(0, 0, move2 * (5f));
        }
        else if (move2 > 0 && !(transform.localEulerAngles.z >= 180 && transform.localEulerAngles.z <= 270))
        {
            transform.Rotate(0, 0, move2 * (5f));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            st = Time.time;
            LineOfSight.positionCount = 1;
            LineOfSight.SetPosition(0, transform.position);

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, MaxRayDistance, LayerDetection);
            // Ray
            Ray2D ray = new Ray2D(transform.position, transform.right);

            bool isMirror = false;
            Vector2 mirrorHitPoint = Vector2.zero;
            Vector2 mirrorHitNormal = Vector2.zero;

            move = Input.GetAxisRaw("Horizontal");
            String givenWord = bs.words[j];
            string givenDangerWord = bs.dangerWordss[j];
            

            for (int i = 0; i < reflections; i++)
            {
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    if (hitInfo.collider.name.Contains("LetterSquare"))
                    {
                        nestedList = bs.nestedList;
                        GameObject gameObject = hitInfo.collider.gameObject;
                        
                        Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                        numberOfHits = givenWord.Length;
                        Debug.Log("now the numberOfHits is " + numberOfHits);
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

                                if (popUpIndex == 7 && "X".Equals(text.text.ToString()))
                                {
                                    popUps[6].SetActive(false);
                                    popUpIndex++;
                                    Time.timeScale = 1;
                                }

                                Debug.Log("hurrrrrayyyyy" + localHits);
                            }
                            else
                            {

                                if (localHits > numberOfHits)
                                {
                                    Debug.Log("no shooting");
                                    //Time.timeScale = 0;
                                    isMatch = false;
                                    popUps[7].SetActive(true);
                                }
                                else
                                {
                                    localHits++;
                                    if (givenDangerWord.Contains(text.text.ToString()))
                                    {
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                        if (popUpIndex == 9 && "S".Equals(text.text.ToString()))
                                        {
                                            popUps[10].SetActive(true);
                                            popUpIndex++;
                                            Time.timeScale = 0;
                                            Debug.Log("TIme scale 0 popupindex 9");
                                         }
                                        dangerWordCreated += text.text;
                                        Debug.Log("the danger word created till now is" + dangerWordCreated);
                                    }

                                    if (!givenWord.Contains(text.text.ToString()) && !givenDangerWord.Contains(text.text.ToString()))
                                    {
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
                                        if (popUpIndex == 6 && "X".Equals(text.text.ToString()))
                                        {
                                            popUps[5].SetActive(true);
                                            Time.timeScale = 0;
                                            Debug.Log("TIme scale 0 popupindex 6");
                                        }
                                    }
                                    else if (givenWord.Contains(text.text.ToString()))
                                    {
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

                                        if (popUpIndex == 4 && "B".Equals(text.text.ToString()))
                                        {
                                            popUps[4].SetActive(true);
                                            Time.timeScale = 0;
                                            Debug.Log("TIme scale 0 popupindex 4");
                                        }
                                        else if (popUps[18].activeSelf == true)
                                        {
                                            popUps[18].SetActive(false);
                                        }

                                        //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);
                                        wordCreated += text.text;

                                    }
                                   
                                   
                                    if(dangerWordCreated.Length == bs.dangerWordss[j].Length)
                                    {
                                        
                                        if(findMatch(dangerWordCreated, bs.dangerWordss[j]))
                                        {
                                            Debug.Log("dangerrrrrr");
                                            ScoreScript.PlayerScore -= 1;

                                        }
                                    }

                                    if (wordCreated.Length == bs.words[j].Length)
                                    {

                                        Debug.Log("the word is       " + wordCreated);
                                        if (findMatch(wordCreated, bs.words[j]))
                                        {
                                            Debug.Log(bs);
                                            GameObject[] gs = bs.nestedList[j];
                                            ScoreScript.PlayerScore += 1;
                                            for (int k = 0; k < gs.Length; k++)
                                            {
                                                Destroy(gs[k]);

                                                //prompt
                                                popUps[9].SetActive(true);

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
            {
                LineOfSight.SetVertexCount(0);
            }
        }
    }

    private void FixedUpdate()
    {      
        

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
}