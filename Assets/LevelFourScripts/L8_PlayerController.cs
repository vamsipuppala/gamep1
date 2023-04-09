using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L8_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Line OF Renderer
    public LineRenderer LineOfSight;
    public LineRenderer LineOfSight2;

    int j = 0;
    public BlockSpawnerScript bs;
    public int reflections;
    public float MaxRayDistance;
    public LayerMask LayerDetection;
    //public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public LogicManagerScript logic;
    public NextLevelScript nextLevel;
    //mmodification
    public TextBlinkScript textBlinkScript;

    public GameObject NextLevelScreen;
    public string wordCreated;
    public string lol1;
    bool z_is = false;
    public string dangerWordCreated;
    //public float move;
    int numberOfHits;
    int localHits = 1;
    [SerializeField] private TextMeshProUGUI goodword;
    [SerializeField] public TextMeshProUGUI dangerWord;
    public string dummy;
    public Text text1;
    public Text text2;
    List<GameObject[]> nestedList;
    public string final;
    public float moveSpeed;
    public float st, ct;
    public GameObject c;
    public static int numberOfDeselections = 0;
    public static int timeTargetWordWasHit = 0;
    public static int numberOfTimesWordHitInOrder = 0;
    public static int numberOfTimesWordHitInReverse = 0;
    public static int zHit = 0;
    public Color flashColor = Color.red; // The color to set the background to
    public float flashDuration = 1f; // The duration for which to set the background color

    private Color originalColor; // The original background color
    private bool isFlashing = false;

    //[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public L8_NextLevel nextLevelScript;

    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;

    public GameObject obstacle1;
    public GameObject obstacle2;

    public GameObject hoveringPlatform;


    //record the frequency for each letter in target word
    Dictionary<char, int> targetLetterFrequency;
    //record the frequency for each colored letter in target word
    Dictionary<char, int> targetColoredLetterFrequency;

    int ind = 0;
    void Start()
    {
        ind = 0;
        st = Time.time;
        Physics2D.queriesStartInColliders = false;
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();

      //  messageManagerScript = GameObject.FindGameObjectWithTag("MessageManagerScript").GetComponent<MessageManagerScript>();
        //nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>();
        nestedList = bs.nestedList;
        //final = "Aim: " + bs.words[ind];
        nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<L8_NextLevel>();
        nextLevelScript.resetValues();

        hoveringPlatform = GameObject.FindGameObjectWithTag("HoveringPlatform");
        Debug.Log("child: " + hoveringPlatform.transform.childCount);

        obstacle1 = hoveringPlatform.transform.GetChild(0).gameObject;
        Debug.Log("OBSTACLE 1: " + obstacle1.name);
        obstacle2 = hoveringPlatform.transform.GetChild(1).gameObject;

        boxCollider1 = obstacle1.GetComponent<BoxCollider2D>();
        boxCollider2 = obstacle2.GetComponent<BoxCollider2D>();


        goodword.text = string.Join("", bs.words[ind]);
        
        //mmodification
        textBlinkScript = GameObject.FindGameObjectWithTag("TextBlinkScript").GetComponent<TextBlinkScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (nestedList[j][0].transform.position.y < 3)
        {
            nextLevelScript.GameOver("blocksTouchedPlayer");
        }

        //Debug.Log("finalllllllllllllll" + final);
        //goodword.text = final;
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 8f);
        }


        goodword.text = "Target:  \n" + changecolor(string.Join("", bs.words[ind]), 0);
        dangerWord.text = "Danger:  \n";

        for (int i = 0; i < bs.dangerWordss[ind].Length; i++)
        {
            dangerWord.text += changecolor(bs.dangerWordss[ind][i], 1) + "\n";
        }
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
        float rotateSpeed = 0.1f;
        float move2 = Input.GetAxis("Vertical") * rotateSpeed;

        if (move2 < 0 && !(transform.localEulerAngles.z > 300))
        {

            transform.Rotate(0, 0, move2 * (2f));
        }
        else if (move2 > 0 && !(transform.localEulerAngles.z >= 180 && transform.localEulerAngles.z <= 270))
        {

            transform.Rotate(0, 0, move2 * (2f));
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
            String givenWord = bs.words[j][0];
            string[] givenDangerWord = bs.dangerWordss[j];


            // rb.velocity = new Vector2(moveSpeed * move, rb.velocity.y);

            for (int i = 0; i < reflections; i++)
            {
                LineOfSight.positionCount += 1;

                if (hitInfo.collider != null)
                {
                    // if (hitInfo.collider.name.Contains("LetterSquare"))
                    // {
                    //     //Debug.Log("GIVEN WORD: " + givenWord);
                    //     nestedList = bs.nestedList;
                    //     GameObject gameObject = hitInfo.collider.gameObject;

                    //    // Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                    //     numberOfHits = givenWord.Length;
                    //    // Debug.Log("now the numberOfHits is " + numberOfHits);
                    //     TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                    //     if(j==GetIndexOfGameObject(gameObject, nestedList))
                    //     {

                    //         if (gameObject.GetComponent<SpriteRenderer>().color == Color.gray || gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                    //         {
                    //             numberOfDeselections++;
                    //             localHits--;
                    //             if (gameObject.GetComponent<SpriteRenderer>().color == Color.green)
                    //             {

                    //                 wordCreated = wordCreated.Replace(text.text.ToString(), "");


                    //             }
                    //             if (gameObject.GetComponent<SpriteRenderer>().color == Color.red)
                    //             {
                    //                 dangerWordCreated = dangerWordCreated.Replace(text.text.ToString(), "");
                    //             }

                    //             gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                    //            // Debug.Log("hurrrrrayyyyy" + localHits);
                    //         }
                    //         else
                    //         {

                    //             if (localHits > numberOfHits)
                    //             {
                    //                // Debug.Log("no shooting");
                    //             }
                    //             else
                    //             {
                    //                 localHits++;
                    //                 if (givenDangerWord.Contains(text.text.ToString()))
                    //                 {
                    //                     gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                    //                     dangerWordCreated += text.text;
                    //                     //Debug.Log("the danger word created till now is" + dangerWordCreated);
                    //                 }

                    //                     if (!givenWord.Contains(text.text.ToString()) && !givenDangerWord.Contains(text.text.ToString()))
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


                    //                 if(dangerWordCreated.Length == bs.dangerWordss[j][0].Length)
                    //                 {

                    //                     if(findMatch(dangerWordCreated, bs.dangerWordss[j][0]))
                    //                     {
                    //                         ScoreScript.PlayerScore -= 1;

                    //                     }
                    //                 }

                    //                 if (wordCreated.Length == bs.words[j][0].Length)
                    //                 {

                    //                     //IF WORD IS SPELLED IN ORDER - REWARD THE PLAYER
                    //                     if (bs.words[j][0].Equals(wordCreated))
                    //                     {
                    //                         Debug.Log("HELLO JI LEVEL 3 - pausing obstacle mvmt for few seconds");

                    //                         GameObject[] gs = bs.nestedList[j];
                    //                         ScoreScript.PlayerScore += 2;
                    //                         for (int k = 0; k < gs.Length; k++)
                    //                         {
                    //                             Destroy(gs[k]);
                    //                         }
                    //                         wordCreated = "";
                    //                         dangerWordCreated = "";
                    //                         j++;
                    //                         ind++;
                    //                         localHits = 1;

                    //                         obstacle1.GetComponent<SpriteRenderer>().color = Color.red;
                    //                         obstacle2.GetComponent<SpriteRenderer>().color = Color.red;
                    //                         boxCollider1.enabled = false;
                    //                         boxCollider2.enabled = false;
                    //                         StartCoroutine(EnableBox(10.0F));
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
                    //                         timeTargetWordWasHit += 1;
                    //                         wordCreated = "";
                    //                         dangerWordCreated = "";                                            
                    //                         j++;
                    //                         ind++;
                    //                         localHits = 1;
                    //                     }
                    //                 }
                    //             }

                    //         }
                    //     }




                    // }
                    if (hitInfo.collider.name.Contains("LetterSquare"))
                    {

                        nestedList = bs.nestedList;
                        GameObject gameObject = hitInfo.collider.gameObject;


                        numberOfHits = givenWord.Length;

                        TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                        if (text.text[0] == 'Z' && i == 0)
                        {

                        }
                        else if (j == GetIndexOfGameObject(gameObject, nestedList))
                        {

                            if (gameObject.GetComponent<SpriteRenderer>().color == Color.gray || gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.green
                                || gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
                            {
                                localHits--;
                                // numberOfTimeDeselectionsOccurred++;
                                int n = wordCreated.Length;
                                string reverse = "";
                                int k1 = 0;
                                for (k1 = n - 1; k1 >= 0; k1--)
                                {
                                    if (wordCreated[k1] != text.text[0])
                                    {
                                        reverse += wordCreated[k1];
                                    }
                                    else
                                    {
                                        k1--;
                                        break;
                                    }
                                }
                                for (int k2 = k1; k2 >= 0; k2--)
                                {

                                    reverse += wordCreated[k2];


                                }

                                wordCreated = Reverse(reverse);




                                // if (gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
                                // {
                                //     dangerWordCreated = dangerWordCreated.Replace(text.text.ToString(), "");
                                // }

                                gameObject.GetComponent<SpriteRenderer>().color = Color.white;


                            }
                            else
                            {

                                if (localHits > numberOfHits && !(z_is == true && localHits - 1 <= numberOfHits) && text.text[0] != 'Z')
                                {

                                }
                                else
                                {
                                    localHits++;
                                    int fla = 0;
                                    for (int z1 = 0; z1 < givenDangerWord.Length; z1++)
                                    {

                                        if (givenDangerWord[z1].Contains(text.text.ToString()))
                                        {
                                            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                                            //mmodification
                                            bool isTargetCompleted = (wordCreated.Length+1 == bs.words[j][0].Length) && findMatch(wordCreated+text.text, bs.words[j][0]);
                                            if (!isTargetCompleted)
                                                textBlinkScript.StartBlinking("dangerBorder");
                                                
                                            // dangerWordCreated += text.text;
                                            fla++;
                                            break;

                                        }
                                    }

                                    if (!givenWord.Contains(text.text.ToString()) && fla == 0)
                                        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;

                                    else if (givenWord.Contains(text.text.ToString()))
                                    {
                                        //mmodification
                                        bool isTargetCompleted = (wordCreated.Length+1 == bs.words[j][0].Length) && findMatch(wordCreated+text.text, bs.words[j][0]);
                                        if (!isTargetCompleted)
                                            textBlinkScript.StartBlinking("targetBorder");
                                        
                                        if (fla > 0)
                                            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                                        else
                                            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                                        //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);

                                        /* if (wordCreated.Length != bs.words[j].Length && goodword.text.IndexOf(wordCreated)!=-1)
                                         {

                                             string s = goodword.text.Substring(goodword.text.IndexOf(wordCreated), wordCreated.Length + 1);
                                             dummy = goodword.text;
                                             string s1 = dummy.Replace(s, "");
                                             final = s1 + "<u>" + s + "</u>";
                                             goodword.text = final;
                                         }*/



                                    }
                                    wordCreated += text.text;

                                }
                                bool dest = false;
                                if (wordCreated.Contains('Z'))
                                {
                                    z_is = true;


                                    wordCreated = wordCreated.Replace("Z", "");
                                    Debug.Log("Z deleted" + wordCreated);
                                }
                                else
                                {
                                    z_is = false;
                                }
                                if (wordCreated.Length == bs.words[j][0].Length && findMatch(wordCreated, bs.words[j][0]))
                                {

                                    //IF WORD IS SPELLED IN ORDER - REWARD THE PLAYER
                                    if (bs.words[j][0].Equals(wordCreated) || Reverse(bs.words[j][0]).Equals(wordCreated))
                                    {
                                        if (bs.words[j][0].Equals(wordCreated))
                                        {
                                            numberOfTimesWordHitInOrder++;
                                        }
                                        if (Reverse(bs.words[j][0]).Equals(wordCreated))
                                        {
                                            numberOfTimesWordHitInReverse++;
                                        }

                                        ScoreScript.PlayerScore += 2;
                                        for (int d = 0; d < 2; d++)
                                        {
                                            if (d < nestedList.Count)
                                            {
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
                                        dest = true;
                                        obstacle1.GetComponent<SpriteRenderer>().color = Color.red;
                                        obstacle2.GetComponent<SpriteRenderer>().color = Color.red;
                                        boxCollider1.enabled = false;
                                        boxCollider2.enabled = false;
                                        StartCoroutine(EnableBox(15.0F));

                                    }


                                    else
                                    {

                                        GameObject[] gs = bs.nestedList[j];
                                        ScoreScript.PlayerScore += 1;
                                        for (int k = 0; k < gs.Length; k++)
                                        {
                                            Destroy(gs[k]);
                                        }
                                        dest = true;
                                        wordCreated = "";
                                        timeTargetWordWasHit += 1;
                                        dangerWordCreated = "";
                                        j++;
                                        ind++;
                                        localHits = 1;



                                    }
                                    if (z_is == true)
                                    {
                                        zHit++;
                                        ScoreScript.PlayerScore += 1;
                                    }
                                }
                                else
                                {
                                    for (int z1 = 0; z1 < bs.dangerWordss[j].Length; z1++)
                                    {

                                        if (wordCreated.Length == bs.dangerWordss[j][z1].Length)
                                        {

                                            if (findMatch(wordCreated, bs.dangerWordss[j][z1]))
                                            {
                                                
                                                ScoreScript.PlayerScore -= 1;
                                                Debug.Log(ScoreScript.PlayerScore);
                                                if (!isFlashing)
                                                {
                                                    StartCoroutine(FlashCoroutine());
                                                }

                                            }
                                        }
                                    }
                                }
                                if (!dest && z_is)
                                    wordCreated += "Z";


                            }
                            Debug.Log(wordCreated);
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
                //Debug.Log("SET VERTEXT COUNT - OBSOLETE");
                //LineOfSight.SetVertexCount(0);
                LineOfSight.positionCount = 0;
            }
        }
    }

    //private void FixedUpdate()
    //{      
    //rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);


    //}

    IEnumerator EnableBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        obstacle1.GetComponent<SpriteRenderer>().color = Color.white;
        obstacle2.GetComponent<SpriteRenderer>().color = Color.white;
        boxCollider1.enabled = true;
        boxCollider2.enabled = true;
    }

    IEnumerator FlashCoroutine()
    {
        isFlashing = true;
        //Vector3 originalPosition = transform.position;
        //float elapsed = 0f;
        Camera.main.backgroundColor = flashColor;
        yield return new WaitForSeconds(flashDuration);
        Camera.main.backgroundColor = originalColor;
        /*while (elapsed < shakeDuration)
        {
            float x = originalPosition.x + UnityEngine.Random.Range(-1f, 1f) * 0.1f;
            float y = originalPosition.y + UnityEngine.Random.Range(-1f, 1f) * 0.1f;
            transform.position = new Vector3(x, y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }*/
        //transform.position = originalPosition;

        isFlashing = false;
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
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
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

    /*receive a word and return a map. The keys are letters in word
the value is frequency of letter
*/



    /*receive a word and return a map. The keys are letters in word
       The value is set to 0 which represents 0 colored frequency
    */



    /* change the frequency of a given letter in the map by delta
    */




    /* use rich text to color letters. For each letter in the given word, take the minimum of the frequency from two maps as colored times.
       The times of each letter to be colored cannot exceed its frequency of two map which means cannot exceed the frequency in given word
       and the frequency of colored blocks which include the same letter.
    */

    public string changecolor(string word, int c)
    {
        int n = word.Length;
        string res = "";
        int n1 = wordCreated.Length, i, j;
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n1; j++)
            {
                if (word[i] == wordCreated[j])
                {
                    break;
                }
            }
            if (j == n1)
            {
                res += word[i];
            }
            else
            {
                if (c == 0)
                    res += "<color=green>" + word[i] + "</color>";
                else
                {
                    res += "<color=red>" + word[i] + "</color>";
                }
            }

        }
        return res;
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  Debug.Log("oncollision - ");
    // logic.gameOver();
    //}
}