using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

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
    public string[] words = { "BIN", "BRO", "MAT", "FIND", "MAD", "TEXT", "DOLL", "DAZE", "MAP", "TENT" , "BLUE" , "PINK", "RED" ,"FIX" , "BALL" };
    public string[] dangerWordss = {"SIN", "FRO" ,"RAT", "MIND", "DAD", "NEXT", "TOLL" , "MAZE" , "PAP" ,"RENT", "GLUE" ,"SINK" , "BED", "SIX", "MALL"};

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
           //10 blocks in a row
        float width = 1;
        float offset = 0.1f;
        
        for (int j = 0; j < 15; j++) // this is for the total number of rows
        {
            HashSet<char> hs = new HashSet<char>();
            
            blocks = new GameObject[10];
            string word = words[j];
            string dangerword = dangerWordss[j];
            foreach (char c in word)
            {
                hs.Add(c);
            }
            foreach(char c in dangerword)
            {
                hs.Add(c);
            }
            Debug.Log("WORD: " + word);
            int numOfRandomLetters = 10 - hs.Count;
            string randomLetters = generateRandomLetters(numOfRandomLetters);
            string shuffleLetters = "";
            string finalWord = string.Join("", hs.ToArray());
            shuffleLetters += randomLetters + finalWord;

            var shuffledString = shuffleAllLetters(shuffleLetters);
            float posy = transform.position.y + 1.1f * j; // this is for making the rows come one below the other
            for (int i = 0; i < 10; i++) // this is for the 10 blocks in a single row 
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                block.transform.position = new Vector3(transform.position.x + (i * width) + (i * offset), posy, 0);
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
        Debug.Log("Shuffled String: " + shuffledString);

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
            Debug.Log("Random letter: " + chr);
            randomChar += Char.ToString(chr);
            allCharsTemp.Remove(index);
        }

        //return randomLetters;
        Debug.Log("randomletter str: " + randomChar);
        return randomChar;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("*****");
    }

}

