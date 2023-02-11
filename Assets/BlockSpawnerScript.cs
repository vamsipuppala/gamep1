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

    public GameObject[] blocks;
    public List<GameObject[]> nestedList = new List<GameObject[]>();
    public string[] letters = { "A", "Q", "F", "E", "C", "V", "P", "I", "H", "L" };
    string allChars = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
    public string[] wordsss = { "BIN", "BRO", "GREAT", "FIND", "UNITY", "TEXT", "DOLL", "PHOTO", "LAMP" };

    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        float width = 1;
        float offset = 0.1f;
        float blockScale = 2f;
        int numOfBlocks = 7;
        for (int j = 0; j < 5; j++)
        {
            blocks = new GameObject[numOfBlocks];
            string word = wordsss[j];
            Debug.Log("WORD: " + word);
            int numOfRandomLetters = numOfBlocks - word.Length;
            string randomLetters = generateRandomLetters(numOfRandomLetters);
            string shuffleLetters = "";
            shuffleLetters += word + randomLetters;

            var shuffledString = shuffleAllLetters(shuffleLetters);
            float posy = transform.position.y + 1.1f * j*blockScale;
            for (int i = 0; i < numOfBlocks; i++)
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
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

