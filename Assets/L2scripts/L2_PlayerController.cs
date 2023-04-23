using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L2_PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    // Line OF Renderer
    public Transform canvasTransform; 
    public GameObject mini_score_red_instance;
    public GameObject mini_score_green_instance;
    public GameObject mini_score_green2_instance;
    public LineRenderer LineOfSight;
    public LineRenderer LineOfSight2;
    float rotateSpeed = 50f;
    public Animator animator;

    int j = 0;
    public BlockSpawnerScript bs;
    public int reflections;
    public float MaxRayDistance;
    public GameObject canvas;
    
    public LayerMask LayerDetection;
    //public float moveSpeed = 16f;
    [SerializeField] private Rigidbody2D rb;
    public LogicManagerScript logic;
    //mmodification
    public TextBlinkScript textBlinkScript;
    
    public GameObject NextLevelScreen;
    public string wordCreated;
    public string lol1;
    // public string dangerWordCreated;
    //public float move;
    int numberOfHits;
    int localHits = 1;
    bool z_is = false;
    [SerializeField] private TextMeshProUGUI goodword;
    //[SerializeField] public TextMeshProUGUI dangerWord;
    public string dummy;
    public Text text1;
    public Text text2;
    List<GameObject[]> nestedList;
    public string final;
    public float moveSpeed;
    public float st, ct;
    public GameObject c;
    public static int timeTargetWordWasHit = 0;
    public static int numberOfTimeDeselectionsOccurred = 0;
    //public static int numberOfDeselections = 0;
    //[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public L2_NextLevelTwo nextLevelScript;
    public static int numberOfTimesWordHitInOrder = 0;
    public static int numberOfTimesWordHitInReverse = 0;
    public static int zHit = 0;

    //record the frequency for each letter in target word
    Dictionary<char, int> targetLetterFrequency;
    //record the frequency for each colored letter in target word
    Dictionary<char, int> targetColoredLetterFrequency;

    public int levelTwoTargetScore = 5;

    int ind = 0;

    //Color greenColor = new Color(60,121,0,255);
    //Color greenColor = Color.HSVToRGB(90.248f, 1.98f, 0.24f);
    static string greenHexCode = "#56a500";
    Color greenColor = new Color(
        (float)System.Convert.ToInt32(greenHexCode.Substring(1, 2), 16) / 255f,
        (float)System.Convert.ToInt32(greenHexCode.Substring(3, 2), 16) / 255f,
        (float)System.Convert.ToInt32(greenHexCode.Substring(5, 2), 16) / 255f,
        1f
    );

    static string yellowHexCode = "#ecbd00";
    Color yellowColor = new Color(
        (float)System.Convert.ToInt32(yellowHexCode.Substring(1, 2), 16) / 255f,
        (float)System.Convert.ToInt32(yellowHexCode.Substring(3, 2), 16) / 255f,
        (float)System.Convert.ToInt32(yellowHexCode.Substring(5, 2), 16) / 255f,
        1f
    );

    static string redHexCode = "#b90200";
    Color redColor = new Color(
        (float)System.Convert.ToInt32(redHexCode.Substring(1, 2), 16) / 255f,
        (float)System.Convert.ToInt32(redHexCode.Substring(3, 2), 16) / 255f,
        (float)System.Convert.ToInt32(redHexCode.Substring(5, 2), 16) / 255f,
        1f
    );

    static string grayHexCode = "#69675E";
    Color grayColor = new Color(
        (float)System.Convert.ToInt32(grayHexCode.Substring(1, 2), 16) / 255f,
        (float)System.Convert.ToInt32(grayHexCode.Substring(3, 2), 16) / 255f,
        (float)System.Convert.ToInt32(grayHexCode.Substring(5, 2), 16) / 255f,
        1f
    );


    void Start()
    {

        string folderName = "Videos";
        string fileName = "L2-Final";

        string fileFormat = ".mp4";

        UnityEngine.Video.VideoPlayer videoPlayer;

        // Find the VideoPlayer component in the Canvas hierarchy
        videoPlayer = canvas.GetComponentInChildren<UnityEngine.Video.VideoPlayer>();
        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
        //string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName + fileFormat);
        string filePath = Application.streamingAssetsPath + "/" + fileName + fileFormat;
        Debug.Log("Filepath: " + filePath);
        videoPlayer.url = filePath;

        //int ind=0;
        st = Time.time;
        Physics2D.queriesStartInColliders = false;
       Physics2D.IgnoreCollision(canvas.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("BlockSpawnerScript").GetComponent<BlockSpawnerScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        //nextLevel = GameObject.FindGameObjectWithTag("NextLevel").GetComponent<NextLevelScript>();
        nestedList = bs.nestedList;
        //final = "Aim: " + bs.words[ind];
        nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<L2_NextLevelTwo>();
        //nextLevelScript.resetValues();

        goodword.text = string.Join("", bs.words[ind]);
        targetLetterFrequency = InitiateLetterFrequency(goodword.text);
        targetColoredLetterFrequency = InitiateLetterFrequencyToZero(goodword.text);

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
        if (j>=bs.words.Length || nestedList[j][0].transform.position.y < 3)
        {
            nextLevelScript.GameOver("blocksTouchedPlayer");
        }

        //Debug.Log("finalllllllllllllll" + final);
      
        // goodword.text = "Target:  \n"+UpdateTargetWordColor(string.Join("", bs.words[ind]));
        goodword.text = "Target:  \n" + changecolor(string.Join("", bs.words[ind]),0);

        
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
        float move2 = Input.GetAxis("Vertical")*rotateSpeed;
        if (move2 < 0 && !(transform.localEulerAngles.z > 300))
        {
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
            // Debug.Log("the given word is " + givenWord);           


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
                        // Debug.Log("the nested list is" + nestedList);
                        GameObject gameObject = hitInfo.collider.gameObject;

                        // Debug.Log("indexxxxxxxxxxxxx   " + GetIndexOfGameObject(gameObject, nestedList));
                        numberOfHits = givenWord.Length;
                        // Debug.Log("now the numberOfHits is " + numberOfHits);
                        TextMesh text = gameObject.GetComponentInChildren<TextMesh>();
                        // Debug.Log("the given text is " + text);
                        
                         if (j == GetIndexOfGameObject(gameObject, nestedList))
                        {
                            // Debug.Log("the index found is  " + j);

                            if (gameObject.GetComponent<SpriteRenderer>().color == grayColor || gameObject.GetComponent<SpriteRenderer>().color == redColor || gameObject.GetComponent<SpriteRenderer>().color == greenColor
                                || gameObject.GetComponent<SpriteRenderer>().color == yellowColor)
                            {
                                localHits--;
                                numberOfTimeDeselectionsOccurred++;
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
                               // if (text.text[0] == 'Z')
                                //{
                                  //  z_is = false;
                                //}                                            
                                if (gameObject.GetComponent<SpriteRenderer>().color == greenColor || gameObject.GetComponent<SpriteRenderer>().color == yellowColor)
                                {
                                    if (givenWord.Contains(text.text.ToString()))
                                    {
                                        ChangeFrequency(givenWord, char.Parse(text.text), targetColoredLetterFrequency, -1);
                                    }

                                }

                                // if (gameObject.GetComponent<SpriteRenderer>().color == Color.red || gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
                                // {
                                //     dangerWordCreated = dangerWordCreated.Replace(text.text.ToString(), "");
                                // }

                                gameObject.GetComponent<SpriteRenderer>().color = Color.white;

                                // Debug.Log("hurrrrrayyyyy" + localHits);
                            }
                            else
                            {
                                // Debug.Log("elseeeeeeeeeee");
                                if (localHits > numberOfHits)
                                {
                                    // Debug.Log("no shooting");
                                }
                                else
                                {
                                    localHits++;
                                    int fla = 0;

                                    // Debug.Log("wowowo " + givenWord);
                                    if (!givenWord.Contains(text.text.ToString()) && fla == 0)
                                        gameObject.GetComponent<SpriteRenderer>().color = grayColor;

                                    else if (givenWord.Contains(text.text.ToString()))
                                    {
                                        //mmodification
                                        bool isTargetCompleted = (wordCreated.Length+1 == bs.words[j][0].Length) && findMatch(wordCreated+text.text, bs.words[j][0]);
                                        if (!isTargetCompleted)
                                            textBlinkScript.StartBlinking("targetBorder");
                                        ChangeFrequency(givenWord, char.Parse(text.text), targetColoredLetterFrequency, 1);
                                        // Debug.Log("the fla is " + fla);
                                        if (fla > 0)
                                            gameObject.GetComponent<SpriteRenderer>().color = yellowColor;
                                        else {
                                            // Debug.Log("HELLO color");
                                            //Color greenColor = new Color(60f, 121f, 0f, 255f);
                                            gameObject.GetComponent<SpriteRenderer>().color = greenColor;
                                            // Debug.Log("HELLO green:"+ gameObject.GetComponent<SpriteRenderer>().color);
                                        }
                                        //givenWord = givenWord.Replace(text.text.ToString(), String.Empty);

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
                                    wordCreated += text.text;

                                }

                                bool dest = false;
                                // Debug.Log("the wordssssssssssssssssssss " + wordCreated);
              
                                if ((wordCreated.Length == bs.words[j][0].Length) && findMatch(wordCreated, bs.words[j][0]))
                                {
                                    // Debug.Log("THIS IS A MATCH");
                                    if (bs.words[j][0].Equals(wordCreated))
                                    {
                                        numberOfTimesWordHitInOrder++;
                                    }
                                    if (Reverse(bs.words[j][0]).Equals(wordCreated))
                                    {
                                        numberOfTimesWordHitInReverse++;
                                    }

                                    //IF WORD IS SPELLED IN ORDER - REWARD THE PLAYER

                                   // if (bs.words[j][0].Equals(wordCreated) || Reverse(bs.words[j][0]).Equals(wordCreated))
                                    //{
                                      //  Debug.Log("******");
                                    //}

                                    // Debug.Log("the word is       " + wordCreated);
                                   // if(bs.words[j][0].Equals(wordCreated))
                                    //{
                                        //Debug.Log(bs);
                                        // Debug.Log("!!!!!!!!!");
                                        GameObject[] gs = bs.nestedList[j];
                                        ScoreScript.PlayerScore += 1;
                                        animator.SetTrigger("change");
                                          GameObject cde = Instantiate(mini_score_green_instance, canvasTransform);
                                     cde.transform.position = new Vector3(nestedList[j][0].transform.position.x+570, (float)((float)(nestedList[j][0].transform.position.y*300)/(float)13.3), 0);
                                    Destroy(cde, 1.0f);
                                        for (int k = 0; k < gs.Length; k++)
                                        {
                                            Destroy(gs[k]);
                                        }
                                        dest = true;
                                        wordCreated = "";
                                        timeTargetWordWasHit += 1;

                                        j++;
                                    addCollider(j, bs.nestedList[j]);
                                    ind++;
                                        localHits = 1;
                                        targetLetterFrequency = InitiateLetterFrequency(bs.words[j][0]);
                                        targetColoredLetterFrequency = InitiateLetterFrequencyToZero(bs.words[j][0]);
                                   // }

                                }
                               
                              


                            }
                            // Debug.Log(wordCreated);
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

    void addCollider(int j, GameObject[] gs)
    {

        // Debug.Log("omgomgomgomg" + j);
        for (int i = 0; i < 8; i++)
        {
            gs[i].AddComponent<BoxCollider2D>();
        }



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
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    /*receive a word and return a map. The keys are letters in word
   the value is frequency of letter
*/
    public Dictionary<char, int> InitiateLetterFrequency(String word)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int n = word.Length;


        for (int i = 0; i < n; i++)
        {
            char key = word[i];
            if (map.ContainsKey(key))
            {
                map[key]++;
            }
            else
            {
                map.Add(key, 1);
            }
        }
        return map;
    }


    /*receive a word and return a map. The keys are letters in word
       The value is set to 0 which represents 0 colored frequency
    */
    public Dictionary<char, int> InitiateLetterFrequencyToZero(String word)
    {
        // Debug.Log("the good word is " + word);
        Dictionary<char, int> map = new Dictionary<char, int>();
        int n = word.Length;
        for (int i = 0; i < n; i++)
        {
            char key = word[i];
            if (map.ContainsKey(key))
            {
                continue;
            }
            map.Add(key, 0);
        }
        return map;
    }


    /* change the frequency of a given letter in the map by delta
    */
    public void ChangeFrequency(string word, char letter, Dictionary<char, int> map, int delta)
    {
        int n = word.Length;
        // Debug.Log("the worddddddddddd" + word);

        for (int i = 0; i < n; i++)
        {
            if (word[i] == letter)
            {
                map[letter] += delta;
                break;
            }
        }

        // Debug.Log("the map now is " + map);
    }


    /* use rich text to color letters. For each letter in the given word, take the minimum of the frequency from two maps as colored times.
       The times of each letter to be colored cannot exceed its frequency of two map which means cannot exceed the frequency in given word
       and the frequency of colored blocks which include the same letter.
    */
    public string UpdateTargetWordColor(string word)
    {
        int n = word.Length;
        string res = "";

        Dictionary<char, int> colorLeftCounter = new Dictionary<char, int>();
        foreach (var item in targetColoredLetterFrequency)
        {
            colorLeftCounter[item.Key] = item.Value;
        }
        for (int i = 0; i < n; i++)
        {
            char key = word[i];
            int x = Math.Min(colorLeftCounter[key], targetLetterFrequency[key]);

            if (colorLeftCounter[key] > 0)
            {
                colorLeftCounter[key]--;
                res += "<color=#56a500>" + key + "</color>";
            }

            if (x == 0)
            {
                res += key;
            }
        }
        return res;
    }
     public string changecolor(string word, int c)
    {
        int n = word.Length;
        string temp = wordCreated;
        string res = "";
        int n1 = wordCreated.Length, i, j;
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < temp.Length; j++)
            {
                if (word[i] == temp[j])
                {
                    break;
                }
            }

            if (j >= temp.Length)
            {
                res += word[i];
            }
            else
            {
                if (c == 0)
                    res += "<color=#56a500>" + word[i] + "</color>";
                else
                {
                    res += "<color=#b90200>" + word[i] + "</color>";
                }
                int index = temp.IndexOf(word[i]);
                temp = temp.Remove(index, 1);
            }


        }
        return res;
    }


    // When blocks collide with the player => Game over
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("PC2 --- COLLISION");
        // Debug.Log("*****************");
        // Debug.Log("COLLIDE (name) : " + collision.gameObject.name);

        if (collision.gameObject.name == "ColoredLetterSquare1(Clone)")
        {
            //Debug.Log("GAME OVER BOI !!!!!!");
            //gameOverReason = "GAME OVER DUE TO COLLISION !!!";

            // Set the game over reason on the GameOver scene.
            PlayerPrefs.SetString("GameOverReason", "Game terminated due to collision!");
            SceneManager.LoadScene("GameOver");
        }

    }


    // private void OnCollisionEnter2D(Collision2D collision)
    //{
    //  Debug.Log("oncollision - ");
    // logic.gameOver();
    //}

    // All rows annihilated - game over
    private void allRowsAnnihilated()
    {
        if (ScoreScript.PlayerScore < levelTwoTargetScore && L2_Timer.TimeValue > 0)
        {
            PlayerPrefs.SetString("GameOverReason", "Game terminated - all rows annihilated, but target score not achieved!");
            SceneManager.LoadScene("GameOver");
        }
    }
}