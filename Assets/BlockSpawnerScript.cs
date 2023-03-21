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

string[][] jaggedStrings =  {
new string[] {"x","y","z"},
new string[] {"x","y"},
new string[] {"x"}
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
    public string[][] wordsL3 = {new string[] {"JAM"}, 
                                 new string[] {"SOAP"}, 
                                 new string[] {"HAY"}, 
                                 new string[] {"SHOW"}, 
                                 new string[] {"NEW"}, 
                                 new string[] {"FIN"}, 
                                 new string[] {"GOLF"}, 
                                 new string[] {"BELT"}, 
                                 new string[] {"DIET"}, 
                                 new string[] {"KIT"} };
    public string[][] dangerWordsL3 = { 
                                       new string[]  {"AM", "JM", "M"}, 
                                       new string[] {"SOA", "OS", "A"}, 
                                       new string[] {"HA", "YA", "A"}, 
                                       new string[] {"S", "HOW", "OW"}, 
                                       new string[] {"NO", "E", "W"}, 
                                       new string[] {"F","FI", "FF"}, 
                                       new string[] {"GOL", "LF", "OL"}, 
                                       new string[] {"T", "BE", "LT"}, 
                                       new string[] {"DE","E","P"}, 
                                       new string[] {"K","I","T"} };
    public string[][] block_of_wordsL3 =  {
                                            new string[] {"MZMMJMAJJA"}, 
                                            new string[] {"SZAAOSOAAP"}, 
                                            new string[] {"HAYAHAYAZA"}, 
                                            new string[] {"SZSHOWHOWO"}, 
                                            new string[] {"NNWWEEWEZN"}, 
                                            new string[] {"FINFINZFIN"}, 
                                            new string[] {"GOYLFLFFLZ"}, 
                                            new string[] {"BELBELBTZT"}, 
                                            new string[] {"DEBIEEEZPT"}, 
                                            new string[] {"KALLILZLLT"} };

    public string[][] wordsL4 = { 
                                    new string[] {"VAMSI"}, 
                                    new string[] {"AMOGHA"}, 
                                    new string[] {"GURPREET"}, 
                                    new string[] {"ANSHU"}, 
                                    new string[] {"CHAND"}, 
                                    new string[] {"HENG"}, 
                                    new string[] {"CHENG"}, 
                                    new string[] {"NAATU"}, 
                                    new string[] {"LOVE"}, 
                                    new string[] {"PYAAAAR"} };
    public string[][] dangerWordsL4 = {
                                        new string[] {"I", "VA", "ME"},
                                        new string[] {"G", "AMO", "HA"}, 
                                        new string[] {"E", "T", "PRE"}, 
                                        new string[] {"U", "AN", "SHU"},
                                        new string[] {"I", "CH", "AND"}, 
                                        new string[] {"H", "HE", "BEN"}, 
                                        new string[] {"G", "CH", "HENG"}, 
                                        new string[] {"NA", "TU", "U"}, 
                                        new string[] {"L", "VE", "HATE"}, 
                                        new string[] {"P", "YAAR", "RA"} };
    public string[][] block_of_wordsL4 =  {
                                            new string[] {"VAMSIIIEZM"}, 
                                            new string[] {"AMOAHGZIAO"}, 
                                            new string[] {"GPRETRUEZE"}, 
                                            new string[] {"UZUANPQSHU"}, 
                                            new string[] {"CHANIZIDII"}, 
                                            new string[] {"HENGHENGZH"}, 
                                            new string[] {"CENGHENGZH"},
                                            new string[] {"NUUUZUUATA"}, 
                                            new string[] {"LSHATELOVZ"},                  
                                            new string[] {"PYAAAARAZP"} };



    public static string[][] wordsL1 = {new string[] {"BOLD"},
                                        new string[] {"DAZE"}, 
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
    public static string[][] dangerWordsL1 = {new string[] {"FOLD"},
                                             new string[]  {"MAZE"}, 
                                             new string[]  {"CAP"},
                                             new string[] {"RENT"}, 
                                             new string[] {"GLUE"},
                                             new string[]  {"SIN"}, 
                                             new string[] {"FRO"}, 
                                             new string[] {"RAT"}, 
                                             new string[] {"MIND"}, 
                                             new string[] {"PAD"}, 
                                             new string[] {"LIP"},  
                                             new string[] {"INK"},
                                             new string[]  {"BED"}, 
                                             new string[] {"SIX"}, 
                                             new string[] {"AL"}};
    public string[][] words = wordsL1;
    public string[][] dangerWordss = dangerWordsL1;
    // Start is called before the first frame update
    private void Awake()
    {
        
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
            words = wordsL4;
            dangerWordss = dangerWordsL4;
        }


        for (int j = 0; j < 10; j++) // this is for the total number of rows
        {
            
            
            blocks = new GameObject[10];
            
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
                shuffledString = block_of_wordsL4[j][0];
            }
            else{
                HashSet<Char> hs = new HashSet<Char>();
            foreach (char c in word)
            {
                hs.Add(c);
            }
            foreach(char c in dangerword)
            {
                hs.Add(c);
            }
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

