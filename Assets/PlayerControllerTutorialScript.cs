using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;

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
    public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public string wordCreated;
    public float move;
    int numberOfHits;
    int localHits = 1;
     [SerializeField] private TextMeshProUGUI  goodword;
    List<GameObject[]> nestedList;

    LogicManagerScript logic;

    public GameObject[] popUps;
    int ind=0;

    int popUpIndex = 0;
    void Start()
    {
        int ind=0;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerTutorialScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        nestedList = bs.nestedList;
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
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
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
        //HINT 3 - Press LEFT CTRL to shoot & select the letter
        else if (popUpIndex == 3)
        {
            popUps[3].SetActive(true);
            popUps[11].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[3].SetActive(false);
                popUps[11].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }

        /*
        else if(popUpIndex == 4)
        {
            //ASK USER TO SHOOT B
            //hint10 - elements 11
            popUps[11].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[11].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }*/
       
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
            //hint11 - elements 12
            popUps[12].SetActive(true);
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[12].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }

        
       else if (Input.GetKeyDown(KeyCode.Return) && popUpIndex == 6)
       {
            //incorrect letter highlighted in red 
           Debug.Log("Inside IFFFF red----");
           popUps[5].SetActive(false);
           popUpIndex++;
           Time.timeScale = 1;
       }

        else if (popUpIndex == 7)
        {
            //ASK USER TO SHOOT X TO DESELECT
            popUps[6].SetActive(true);
            Time.timeScale = 0;
            
        }

        else if(Input.GetKeyDown(KeyCode.LeftControl) && popUpIndex == 8)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                popUps[6].SetActive(false);
                popUpIndex++;
            }
            Time.timeScale = 1;
        }

        /*
      else if (Input.GetKeyDown(KeyCode.Return) && popUpIndex == 6)
      {
          Debug.Log("Inside IFFFF deselect");
          popUps[6].SetActive(false);
          popUpIndex++;
          Time.timeScale = 1;
      }
      */

        //HINT 3.2 - SHOOT AT LETTER P -- DANGER LETTER (RED)

        //TO DO - add shoot at letter this n all prompts        

        //HINT 5 - MAX NUMBER OF SELECTION

        //HINT 6 - REACH THRESHOLD SCORE



        //HINT 8 - SCORE WILL INCREASE

        //HINT 9 - TIMER


        //ADD GREAT GOING WHEN USER HITS CORRECT LETTER, OOPS WHEN USER HITS INCORRECT LETTER



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
                                //HINT 4 - DESELECT LETTER
                                if (popUpIndex == 7 && "X".Equals(text.text.ToString()))
                                {
                                    popUps[6].SetActive(false);
                                    popUpIndex++;
                                    Time.timeScale = 1;
                                }

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
                                    {
                                        //HINT 3.3 - SHOOT AT LETTER X -- INCORRECT LETTER (GRAY)
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                        
                                        if (popUpIndex == 6 && "X".Equals(text.text.ToString()))
                                        {
                                            popUps[5].SetActive(true);
                                            Time.timeScale = 0;
                                            Debug.Log("TIme scale 0");
                                            if (Input.GetKeyDown(KeyCode.Return))
                                            {
                                                Debug.Log("Inside IFFFF red");
                                                popUps[5].SetActive(false);
                                                popUpIndex++;
                                                Time.timeScale = 1;
                                            }

                                        }
                                        
                                    }
                                    else if (givenWord.Contains(text.text.ToString()))
                                    {
                                        //HINT 3.1 - SHOOT CORRECT LETTER - GREEN
                                        
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.green;

                                        if (popUpIndex == 4 && "B".Equals(text.text.ToString()))
                                        {
                                            popUps[4].SetActive(true);
                                            Time.timeScale = 0;
                                            Debug.Log("TIme scale 0");
                                            if (Input.GetKeyDown(KeyCode.Return))
                                            {
                                                Debug.Log("Inside IFFFF");
                                                popUps[4].SetActive(false);
                                                popUpIndex++;
                                                Time.timeScale = 1;
                                            }
                                           
                                        }

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
                                                //HINT 7 - DESTROY ROW

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