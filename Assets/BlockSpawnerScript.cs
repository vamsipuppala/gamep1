using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class BlockSpawnerScript : MonoBehaviour
{

    public GameObject blockPrefab;
    public Vector3 position;
    public string text1="M";
    public TextMesh textComponent;
    //public float pauseDuration = 1f;
    //public Vector3 moveDirection = Vector3.down;

    public float fallSpeed = 1.0f;
   
    public float speed = 1.0f;
     

    public GameObject[] blocks; // this is one row of blocks 
    public List<GameObject[]> nestedList = new List<GameObject[]>(); // this is the entire set of rows 
    public string[] letters = { "A", "Q", "F", "E", "C", "V", "P", "I", "H", "L", "Z", "X", "S", "K" , "J", "N", "M", "T"};
    string allChars = "ABCDEFGHIJKLMNOPQRSTUVWYZ";

    // public string[,] words = { {}};
    // public string[,] dangerWordss = { {}};

    public string[][] L1_block_of_words =  {
                                            new string[] {"TUFFSSETPT"}, 
                                            new string[] {"APPECOPPEE"}, 
                                            };

    public string[][] L2_block_of_words ={new string[] {"FEST"},
                                new string[] {"COPE"},
                                new string[] {"DARE"},
                                new string[] {"CAT"},
                                new string[] {"ICE"},
                                new string[] {"ABLE"},
                                new string[] {"HEAT"},
                                new string[] {"LAMP"},
                                new string[] {"BEAR"},
                                new string[] {"SILK"},
                                new string[] {"TREE"},
                                new string[] {"COW"}
                                };


    public string[][] wordsL2 ={new string[] {"FEST"}, 
                                new string[] {"COPE"}, 
                                new string[] {"DARE"}, 
                                new string[] {"CAT"}, 
                                new string[] {"ICE"}, 
                                new string[] {"ABLE"}, 
                                new string[] {"HEAT"}, 
                                new string[] {"LAMP"}, 
                                new string[] {"BEAR"}, 
                                new string[] {"SILK"} };
    public string[][] dangerWordsL2 = {
                                        new string[] {"FS", "FT", "ET"}, 
                                        new string[] {"CO","CE", "PE"}, 
                                        new string[] {"BA", "DE", "ER"}, 
                                        new string[] {"T", "AC", "TC"},
                                        new string[] {"I", "CE", "IC"}, 
                                        new string[] {"AB", "E", "EL"}, 
                                        new string[] {"H", "EA", "TA"}, 
                                        new string[] {"A", "AL","MP"}, 
                                        new string[] {"BE", "BA", "AR"}, 
                                        new string[] {"S", "IL","SI"} };
    public string[][] L2_block_of_wordsL2 =  {
                                            new string[] {"TUXFSNEMCC"},
                                            new string[] {"ZDBECOPQJJ"},
                                            new string[] {"DCARKELMKK"},
                                            new string[] {"TXAFENCKOO"},
                                            new string[] {"LCBFGHEIWW"},
                                            new string[] {"AIKLEOZNPP"},
                                            new string[] {"TUOBAHZEDD"},
                                            new string[] {"DMCPLAZHQQ"},
                                            new string[] {"ABAXRIZEUU"},
                                            new string[] {"AVLKEIZSII"},
                                            new string[] {"RBEALTZERR"},
                                            new string[] {"BNCRTODWDD"}
                                             };



    public string[][] block_of_wordsL2 =  {
                                            new string[] {"TUFFSSETZT"}, 
                                            new string[] {"ZPPECOPPEE"}, 
                                            new string[] {"DBARDERRRZ"}, 
                                            new string[] {"TTZTTACACT"}, 
                                            new string[] {"ICEIIIEIZE"}, 
                                            new string[] {"ABABLLZLLE"}, 
                                            new string[] {"HEAHHHZHTA"}, 
                                            new string[] {"AZALMPMPAM"}, 
                                            new string[] {"BEBEBAARAZ"}, 
                                            new string[] {"ZSSSSILKIL"} };

    public string[][] block_of_wordsL3 =  {
                                             new string[] {"TUXJSNAMTY"},
                                            new string[] {"ZABSCOPQTT"},
                                            new string[] {"HCARKYLMTT"},
                                            new string[] {"LOBFSHEWTT"},
                                            new string[] {"WIKLEOZNTT"},
                                            new string[] {"TUINAFZETT"},
                                            new string[] {"DFCPLOZGTT"},
                                            new string[] {"ABAXLTZETT"},
                                            new string[] {"ADLKEIZTTT"},
                                            new string[] {"ADLKEIZTTT"},
                                             };


    
    public string[][] wordsL3 = {new string[] {"JAM"}, 
                                 new string[] {"SOAP"}, 
                                 new string[] {"HAY"}, 
                                 new string[] {"SHOW"}, 
                                 new string[] {"NEW"}, 
                                 new string[] {"FIN"}, 
                                 new string[] {"GOLF"}, 
                                 new string[] {"BELT"}, 
                                 new string[] {"DIET"}, 
                                 new string[] {"KIT"}
    };

    

    public string[][] dangerWordsL3 = { 
                                       new string[]  {"AU"}, 
                                       new string[] {"ZBA"}, 
                                       new string[] {"HC"}, 
                                      new string[] {"LOB"}, 
                                       new string[] {"NO"}, 
                                       new string[] {"F"}, 
                                       new string[] {"GZ"}, 
                                       new string[] {"T"}, 
                                       new string[] {"DE"}, 
                                       new string[] {"K"} 
    };
    public string[][] L4_block_of_wordsL4 =  {
                                            new string[] {"FIUCOSREVF"},
                                            new string[] {"KRARKCPEFD"},
                                            new string[] {"PLOVKEEEVC"},
                                            new string[] {"PXRGNIECAA"},
                                            new string[] {"EXMMELPSIS"},
                                            new string[] {"GLIOWQZWOA"},
                                            new string[] {"DPLOXMDKSI"},
                                            new string[] {"RCOAEDPOLE"},
                                            new string[] {"ADLKETZTII"},
                                            new string[] {"BBPIUYZSOM"},
                                             };
    public string[][] L4_wordsL4 = {new string[] {"FOUR"},
                                    new string[] {"DARK"},
                                    new string[] {"KEEP"},
                                 new string[] {"RING"},
                                 new string[] {"MISS"},
                                 new string[] {"GOAL"},
                                 new string[] {"DISK"},
                                 new string[] {"READ"},
                                 new string[] {"DIET"},
                                 new string[] {"BOMB"}
    };
    public string[][] L4_dangerWordsL4 = {
                                       new string[]  {"OU" , "OS"},
                                       new string[] {"DA" , "EF"},
                                       new string[] {"KA" , "KC" },
                                      new string[] {"RIN", "AA"},
                                       new string[] {"EX" , "SS"},
                                       new string[] {"I" , "GL"},
                                       new string[] {"DIK" , "DX"},
                                       new string[] {"EA", "PO"},
                                       new string[] {"DA", "K"},
                                       new string[] {"BP", "BU"}
    };




    public string[][] block_of_wordsL5 = {        new string[] {"FERPOISVEI"},
                                            new string[] {"LOCURYTEWD"},
                                            new string[] {"REROPIREYT"},
                                            new string[] {"TSBMCXZWOO"},
                                            new string[] {"STROVPLSIL"},
                                            new string[] {"EAXETHROPE"},
                                            new string[] {"RDTRENRRWY"},
                                            new string[] {"ADIBIEWQXE"},
                                            new string[] {"GIPOIWDDUE"},
                                            new string[] {"FAOPLOSSMU"}};

    public string[][] wordsL5 = {

                                    new string[] {"FIVE"},
                                    new string[] { "CLOUD" },
                                    new string[] { "RETRY" },
                                    new string[] { "BOOST" },
                                    new string[] { "LIST" },
                                    new string[] { "EARTH" },
                                    new string[] { "ENTRY" },
                                    new string[] { "ABIDE" },
                                    new string[] { "GUIDE" },
                                    new string[] { "FAMOUS" } };

    public string[][] dangerWordsL5 = {
                                        new string[] {"VE", "FE", "FR"},
                                        new string[] {"CLO", "CLD", "CUO"},
                                        new string[] {"RE", "RP", "POI"},
                                        new string[] {"OO", "OST", "ZOO"},
                                        new string[] {"IST", "P", "V"},
                                        new string[] {"EAT", "EAR", "ROP"},
                                        new string[] {"TRY", "RED", "YEN"},
                                        new string[] {"BID", "Q", "XA"},
                                        new string[] {"GUI", "POD", "PIE"},
                                        new string[] { "FAM", "MU", "MOSS" } };



    public string[][] block_of_wordsL6 =  {
                                            new string[] {"CRBEASXRAY"},
                                            new string[] {"DOLSIKOLAD"},
                                            new string[] {"SPOPCIERHA"},
                                            new string[] {"XLOKEXEART"},
                                            new string[] {"RAPQZXGEWT"},
                                            new string[] {"ELCPERTETE"},
                                            new string[] {"CGTBORAOIT"},
                                            new string[] {"KABDEIEANR"},
                                            new string[] {"TBMOIYILEE"},
                                            new string[] {"YTTBESRLFE"} };
    public string[][] wordsL6 =
    {
                                    new string[] {"CARRY"},
                                    new string[] {"SOLID"},
                                    new string[] {"SHARP"},
                                    new string[] {"EXTRA"},
                                    new string[] {"WATER"},
                                    new string[] {"ELECT"},
                                    new string[] {"CARGO"},
                                    new string[] {"DRINK"},
                                    new string[] {"ELITE"},
                                    new string[] {"FLYER"}
    };
    public string[][] dangerWordsL6 = {
                                        new string[] {"CAB", "CAR", "RY"},
                                        new string[] {"SOIL", "LID", "SAD"},
                                        new string[] {"PAR", "SIP", "SHO"},
                                        new string[] {"EX", "RAT", "TAX"},
                                        new string[] {"GET", "WE", "EAT"},
                                        new string[] {"PR", "EC", "PEL"},
                                        new string[] {"CAT", "CAR", "RIG"},
                                        new string[] {"INK", "DIN", "RIN"},
                                        new string[] {"LIT", "LIE", "LEE"},
                                        new string[] {"FLY", "LES", "YET"} };

    public string[][] block_of_wordsL7 =  {
                                            new string[] {"NPOXICOCIT"},
                                            new string[] {"APOSXEMXIO"},
                                            new string[] {"VAPPLIEOKD"},
                                            new string[] {"CKALOKEEHC"},
                                            new string[] {"FPOLICTHIA"},
                                            new string[] {"SSOSSETOEL"},
                                            new string[] {"ILEPOLECAD"},
                                            new string[] {"OSODAISEGO"},
                                            new string[] {"VPOQWXLUEA"},
                                            new string[] {"NICPIRCKAP"} };


    public string[][] wordsL7 =
  {
         new string[] {"TONIC"},
                                    new string[] {"AXIOM"},
                                    new string[] {"VODKA"},
                                    new string[] {"CHECK"},
                                    new string[] {"FAITH"},
                                    new string[] {"STOLE"},
                                    new string[] {"IDEAL"},
                                    new string[] {"GOOSE"},
                                    new string[] {"VALUE"},
                                    new string[] {"PANIC"}
    };
    public string[][] dangerWordsL7 = {
                                        new string[] {"TON", "TIN", "TIME"},
                                        new string[] {"XI", "MIO", "AXIS"},
                                        new string[] {"KAP", "K", "POD"},
                                        new string[] {"CC", "HACK", "KECK"},
                                        new string[] {"FAT", "HA", "FIL"},
                                        new string[] {"SS", "TOE", "LET"},
                                        new string[] {"ID", "EE", "LEAD"},
                                        new string[] {"SAD", "SOD", "GO"},
                                        new string[] {"VAL", "XUE", "VP"},
                                        new string[] {"P", "NICK", "CARP"} };


    public string[][] block_of_wordsL8 =  {
                                            new string[] {"VTARIVRSUI"},
                                            new string[] {"FRERCOELIC"},
                                            new string[] {"ABPOIMEMRE"},
                                            new string[] {"YLOICEOGUN"},
                                            new string[] {"ESLOKEINEC"},
                                            new string[] {"TRAHUIRVEC"},
                                            new string[] {"IDPTNICENX"},
                                            new string[] {"UETDNWITRS"},
                                            new string[] {"LAHALELOHE"},
                                            new string[] {"EMPLICEILS"} };
    public string[][] wordsL8 =
{
                                    new string[] {"VIRUS"},
                                    new string[] {"FORCE"},
                                    new string[] {"AMBER"},
                                    new string[] {"YOUNG"},
                                    new string[] {"SINCE"},
                                    new string[] {"HEART"},
                                    new string[] {"INDEX"},
                                    new string[] {"TRUST"},
                                    new string[] {"HELLO"},
                                    new string[] {"SLIME"}
    };

    public string[][] dangerWordsL8 = {
                                        new string[] {"VIT", "RIT", "RIS"},
                                        new string[] {"FORE", "COR", "EE"},
                                        new string[] {"AB", "MEM", "RAB"},
                                        new string[] {"GUN", "YOG", "GE"},
                                        new string[] {"SIN", "INK", "EE"},
                                        new string[] {"HIR", "TRACE", "HEAR"},
                                        new string[] {"DEX", "INT", "DEN"},
                                        new string[] {"UN", "UT", "RUST"},
                                        new string[] {"LLL", "HEL", "ALO"},
                                        new string[] {"SLIM", "LIP", "SEM"} };
    public string[][] block_of_wordsL9 =  {
                                            new string[] {"VOXIVAREIP"},
                                            new string[] {"BEAEYNFUNY"},
                                            new string[] {"UPEORGLEEA"},
                                            new string[] {"PLABSCITEL"},
                                            new string[] {"SEITLEURYF"},
                                            new string[] {"KGOETSISME"},
                                            new string[] {"ATBOPVGNRE"},
                                            new string[] {"NLOIVRIESG"},
                                            new string[] {"MRTRMEASSI"},
                                            new string[] {"PARRRROTRR"} };

    public string[][] wordsL9 =
{
                                    new string[] {"VIPER"},
                                    new string[] {"FUNNY"},
                                    new string[] {"GLARE"},
                                    new string[] {"BLAST"},
                                    new string[] {"SURFY"},
                                    new string[] {"KISMET"},
                                    new string[] {"ARGENT"},
                                    new string[] {"RIVING"},
                                    new string[] {"MAREIS"},
                                    new string[] {"PARROT"}
    };

    public string[][] dangerWordsL9 = {
                                        new string[] {"VIP", "PAR", "RIP"},
                                        new string[] {"FUN", "FAN", "NAN"},
                                        new string[] {"EAR", "LURE", "GOR"},
                                        new string[] {"LAST", "PLAT", "BAT"},
                                        new string[] {"SUR", "FLY", "YET"},
                                        new string[] {"KISS", "MEET", "SET"},
                                        new string[] {"ANT", "GEN", "BAR"},
                                        new string[] {"RING", "SIV", "ROI"},
                                        new string[] {"MARS", "MEAT", "RISE"},
                                        new string[] {"POT", "RRR", "PAR"} };


    public static string[][] wordsL10 = {
                                        new string[] {"ABIDE"},
                                        new string[] {"ANVIL"}, 
                                        new string[] {"BRISK"}, 
                                        new string[] {"CLASP"} , 
                                        new string[] {"DECOR"}, 
                                        new string[]  {"FABLE"}, 
                                        new string[]  {"GLEAN"}, 
                                        new string[]  {"DEALT"}, 
                                        new string[]  {"INEPT"}, 
                                        new string[]  {"JOUST"}, 
                                        new string[]  {"MERIT"}, 
                                        new string[]  {"PLUSH"}, 
                                        new string[]  {"LURID"},
                                        new string[]  {"GIDDY"} , 
                                        new string[]  {"WINCE"},
                                    

    };
    public static string[][] dangerWordsL10 = {
                                        new string[] {"AB", "E", "ABI"},
                                        new string[] {"LI", "LIV", "AN"},
                                        new string[] {"RISK", "K", "ISK"},
                                        new string[] {"CL", "AS", "LASP"},
                                        new string[] {"DE", "DEC", "DECO"},
                                        new string[] {"F", "FA", "FABLE"},
                                        new string[] {"GE", "LE", "An"},
                                        new string[] {"DEA", "TLA", "EAL"},
                                        new string[] {"IN", "EP", "T"},
                                        new string[] {"JO", "US", "OU"}, 
                                        new string[] {"M", "E", "R"},
                                        new string[] {"H", "PL", "S"} ,
                                        new string[] {"U", "RI", "D"} ,
                                        new string[] {"D", "GID", "ID"} ,
                                        new string[] {"W", "IN", "CE"}  };
    public string[][] block_of_wordsL10 =  {
                                            new string[] {"ABIDEEEEEZ"},
                                            new string[] {"ANVILLLLLZ"}, 
                                            new string[] {"BRISKLLLLZ"}, 
                                            new string[] {"CLASPLLLLZ"} , 
                                            new string[] {"DECORLLLZX"}, 
                                            new string[] {"FABLELLLZX"}, 
                                            new string[] {"GLEANLLLZX"}, 
                                            new string[] {"DEALTLLLZX"}, 
                                            new string[] {"INEPTLLLZX"}, 
                                            new string[] {"JOUSTLLLZX"}, 
                                            new string[] {"MERITLLLZX"}, 
                                            new string[] {"PLUSHLLLZX"}, 
                                            new string[] {"LURIDLLLZX"},
                                            new string[] {"GIDDYLLLZX"} , 
                                            new string[] {"WINCELLLZX"}};
    public static string[][] wordsL1 = {new string[] {"BOLD"},
                                        new string[] {"DALE"}, 
                                        new string[] {"MAP"}, 
                                        new string[] {"DENT"} , 
                                        new string[] {"BLUE"}, 
                                        new string[]  {"BIN"}, 
                                        new string[]  {"BRO"}, 
                                        new string[]  {"MAT"}, 
                                        new string[]  {"FIND"}, 
                                        new string[]  {"MAD"}, 
                                        new string[]  {"HIP"}, 
                                        new string[]  {"PINK"}, 
                                        new string[]  {"RED"},
                                        new string[]  {"FIX"} , 
                                        new string[]  {"BALD"} };
    public static string[][] dangerWordsL1 = {new string[] {"FO"},
                                             new string[]  {"DA"}, 
                                             new string[]  {"P"},
                                             new string[] {"MP"}, 
                                             new string[] {"D"},
                                             new string[]  {"IN"}, 
                                             new string[] {"O"}, 
                                             new string[] {"A"}, 
                                             new string[] {"MI"}, 
                                             new string[] {"D"}, 
                                             new string[] {"P"},  
                                             new string[] {"INK"},
                                             new string[]  {"ED"}, 
                                             new string[] {"I"}, 
                                             new string[] {"BA"}};
    public string[][] words = wordsL1;
    public string[][] dangerWordss = dangerWordsL1;
    // Start is called before the first frame update
    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "L2")

        {
            Debug.Log("0000000000111111111");
            words = L2_block_of_words;
            //blocks_row_count = L2_block_of_words.Length;
        }

    }
    void Start()
    {
           //10 blocks in a row
        float width = 1;
        float offset = 0.1f;
        float blockScale = 1.5f;

        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "LevelOne")
        {  Debug.Log("here");
            words = wordsL1;
            dangerWordss = dangerWordsL1;
        }
        else if (scene.name == "LevelTwo")
        {
            words = wordsL2;
            dangerWordss = dangerWordsL2;
        }
        else if (scene.name == "LevelThree")
        {
            words = wordsL3;
            dangerWordss = dangerWordsL3;
        }
        else if (scene.name == "LevelFour")
        {
            //words = wordsL4;
            //dangerWordss = dangerWordsL4;
        }
        int blocks_row_count = words.Length;
         if(scene.name == "L1")
         {
            blocks_row_count=L1_block_of_words.Length;
         }

        if (scene.name == "L2")

        {
            Debug.Log("0000000000");
            words = L2_block_of_words;
            blocks_row_count = L2_block_of_words.Length;
        }

        if(scene.name == "L3")
        {
            blocks_row_count = wordsL3.Length;
            words = wordsL3;
            dangerWordss = dangerWordsL3;
        }

        if(scene.name == "L4")
        {
            blocks_row_count = L4_wordsL4.Length;
            words = L4_wordsL4;
            dangerWordss = L4_dangerWordsL4;
        }

        if(scene.name== "L5")
        {
            blocks_row_count = wordsL5.Length;
            words = wordsL5;
            dangerWordss = dangerWordsL5;
        }

        if (scene.name == "L6")
        {
            blocks_row_count = wordsL6.Length;
            words = wordsL6;
            dangerWordss = dangerWordsL6;
        }

        if (scene.name == "L7")
        {
            blocks_row_count = wordsL7.Length;
            words = wordsL7;
            dangerWordss = dangerWordsL7;
        }

        if (scene.name == "L8")
        {
            blocks_row_count = wordsL8.Length;
            words = wordsL8;
            dangerWordss = dangerWordsL8;
        }

        if (scene.name == "L9")
        {
            blocks_row_count = wordsL9.Length;
            words = wordsL9;
            dangerWordss = dangerWordsL9;
        }
        if (scene.name == "L10")
        {
            blocks_row_count = wordsL10.Length;
            words = wordsL10;
            dangerWordss = dangerWordsL10;
        }

        for (int j = 0; j < blocks_row_count; j++) // this is for the total number of rows
        {
            
            
            blocks = new GameObject[10];
            if (j == 0)
            {
                Debug.Log("j is 0");

            }
            string word = words[j][0];
            var shuffledString="AAAAAAAAAA";
            string dangerword = dangerWordss[j][0];
            if (scene.name == "LevelTwo")
            {   
                shuffledString = block_of_wordsL2[j][0];
            }
            else if(scene.name == "LevelThree")
            {
                shuffledString = block_of_wordsL3[j][0];
            }
            
            else if(scene.name == "LevelFour")
            {
                shuffledString = block_of_wordsL5[j][0];
            }
            else if(scene.name == "L1")
            {
                shuffledString = L1_block_of_words[j][0];
            }
            else if(scene.name== "L2")
            {
                shuffledString = L2_block_of_wordsL2[j][0];
            }
            else if(scene.name == "L3")
            {
                shuffledString = block_of_wordsL3[j][0];
            }
            else if(scene.name == "L4")
            {
                shuffledString = L4_block_of_wordsL4[j][0];
            }
            else if(scene.name == "L5")
            {
                shuffledString = block_of_wordsL5[j][0];
            }else if (scene.name == "L6")
            {
                shuffledString = block_of_wordsL6[j][0];
            }
            else if (scene.name == "L7")
            {
                shuffledString = block_of_wordsL7[j][0];
            }
            else if (scene.name == "L8")
            {
                shuffledString = block_of_wordsL8[j][0];
            }
            else if (scene.name == "L9")
            {
                shuffledString = block_of_wordsL9[j][0];
            }
            else if (scene.name == "L10")
            {
                shuffledString = block_of_wordsL10[j][0];
            }

            else
            {
                HashSet<Char> hs = new HashSet<Char>();
            foreach (char c in word)
            {
                hs.Add(c);
            }
            foreach(char c in dangerword)
            {
                hs.Add(c);
            }
            // foreach(char c in dangerword)
            // {
            //     hs.Add(c);
            // }
            // Debug.Log("WORD: " + word);
            int numOfRandomLetters = 10 - hs.Count;
            string randomLetters = generateRandomLetters(numOfRandomLetters);
            string shuffleLetters = "";
            string finalWord = string.Join("", hs.ToArray());
            shuffleLetters += randomLetters + finalWord;

            shuffledString = shuffleAllLetters(shuffleLetters);}
            
            // char[] shuffledString1 = block_of_words[j].ToCharArray();
            float posy = transform.position.y + 1.1f * j*blockScale; // this is for making the rows come one below the other
            for (int i = 0; i < 10; i++) // this is for the 10 blocks in a single row 
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                // block.transform.position = new Vector3(transform.position.x + (i * width) + (i * offset), posy, 0);
                block.transform.position = new Vector3(transform.position.x + (i * width*blockScale) + (i * offset*blockScale), posy, 0);
                block.GetComponentInChildren<TextMesh>().fontSize = 18; 
                block.GetComponentInChildren<TextMesh>().characterSize = 0.5F;
                block.GetComponentInChildren<TextMesh>().alignment = TextAlignment.Right;
                block.GetComponentInChildren<TextMesh>().text = Char.ToString(shuffledString[i]);               
                blocks[i] = block;

            }
            nestedList.Add(blocks);
        }
    }

    // Update is called once per frame  
    void Update()
    {
        
    }

    public string shuffleAllLetters(string str)
    {

        char[] charArray = str.ToCharArray();

        // Shuffle the array of characters
        System.Random random = new System.Random();
        charArray = charArray.OrderBy(x => random.Next()).ToArray();

        // Convert the shuffled array of characters back to a string
        string shuffledString = new string(charArray);
        // Debug.Log("Shuffled String: " + shuffledString);

        return shuffledString;
    }

    public string generateRandomLetters(int n)
    {
        //char[] randomLetters = new char[n];
        string allCharsTemp = allChars;
        string randomChar = "";

        for (int i = 0; i < n; i++)
        {
            int index = UnityEngine.Random.Range(0, allCharsTemp.Length);
            char chr = allCharsTemp[index];
            // Debug.Log("Random letter: " + chr);
            randomChar += Char.ToString(chr);
            allCharsTemp.Remove(index);
        }

        //return randomLetters;
        // Debug.Log("randomletter str: " + randomChar);
        return randomChar;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("*****");
    }

}

