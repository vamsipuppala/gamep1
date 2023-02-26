using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendToGoogle : MonoBehaviour
{

    [SerializeField] private string URL;
     // doosri script se le rahi hun mai data 
    

    private long _sessionID;
    //private string _testScore;
    private string _levelName;
    private string _targetWordsHit;
    GameObject myObject;
    ScoreScript sc;
    private string _gameOverReason;
    private string _numberOfDeselections;
    private string _numberofPlayersCompletedLevel;
     
    // Start is called before the first frame update

    private void Awake()
    {
         myObject = GameObject.Find("ScoreText");
         sc = myObject.GetComponent<ScoreScript>();
        _sessionID = DateTime.Now.Ticks;
        // Assign sessionID to identify playtests

    }
    public void SendForGameOver()
    {
        // Assign variables
        // _testInt = 0; // yeh yahaan initialize hoga         
        //Debug.Log("_________________" + _testScore);
        //ScoreScript sc = myObject.GetComponent<ScoreScript>();
        Debug.Log("+++++++++++" + _sessionID);
        StartCoroutine(PostForGameOver(_sessionID.ToString(), _levelName, _gameOverReason));
    }



    public void Send()
    {
        // Assign variables
        // _testInt = 0; // yeh yahaan initialize hoga         
        //Debug.Log("_________________" + _testScore);
        //ScoreScript sc = myObject.GetComponent<ScoreScript>();
        Debug.Log("+++++++++++" + _sessionID);
        StartCoroutine(Post(_sessionID.ToString(), _targetWordsHit, _levelName, _numberOfDeselections, _numberofPlayersCompletedLevel));
    }

    private IEnumerator Post( string _sessionID,string targetWordsHit, string levelName, string numberOfDeselections, string numberOfPlayersCompletedLevel)
    {
        //Debug.Log("////////////////////////" + testInt);
        WWWForm form = new WWWForm();
       
        form.AddField("entry.199825233", _sessionID);
        form.AddField("entry.83745425", levelName);
        if (levelName.Equals("1"))
        {
            form.AddField("entry.1486365924", targetWordsHit);
            form.AddField("entry.218752474", numberOfDeselections);
            form.AddField("entry.829159267", numberOfPlayersCompletedLevel);


        }
        else if (levelName.Equals("2"))
        {
            form.AddField("entry.1019126803", targetWordsHit);
            form.AddField("entry.1404675045", numberOfDeselections);
            form.AddField("entry.1113860914", numberOfPlayersCompletedLevel);


        }
        else if (levelName.Equals("3"))
        {
            form.AddField("entry.917581380", targetWordsHit);
            form.AddField("entry.856136874", numberOfDeselections);
            form.AddField("entry.2070367208", numberOfPlayersCompletedLevel);

        }
        else
        {
            form.AddField("entry.961968652", targetWordsHit);
            form.AddField("entry.409243370", numberOfDeselections);
            form.AddField("entry.1323466106", numberOfPlayersCompletedLevel);

        }
       

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            www.disposeUploadHandlerOnDispose = true;
            www.disposeDownloadHandlerOnDispose = true;
            www.Dispose();
        }
    }


    private IEnumerator PostForGameOver(string _sessionID,string levelName, string gameOverReason)
    {
        //Debug.Log("////////////////////////" + testInt);
        WWWForm form = new WWWForm();

        form.AddField("entry.199825233", _sessionID);
        form.AddField("entry.83745425", levelName);
        if (levelName.Equals("1"))
        {
            form.AddField("entry.76112985", gameOverReason);

        }
        else if (levelName.Equals("2"))
        {
            form.AddField("entry.854602805", gameOverReason);


        }
        else if (levelName.Equals("3"))
        {
            form.AddField("entry.1975042108", gameOverReason);

        }
        else
        {
            form.AddField("entry.94478399", gameOverReason);

        }


        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            www.disposeUploadHandlerOnDispose = true;
            www.disposeDownloadHandlerOnDispose = true;
            www.Dispose();
        }
    }



    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        //ScoreScript sc = myObject.GetComponent<ScoreScript>();
      //  Debug.Log("**********************************" + sc.getScore());
        //_testScore = sc.getScore();
    } 

    public void EndOfGame(string targetWordsHit, string level, string numberOfDeselections, string numberOfPlayersCompletedLevel) // this has to be called when the game ends .... to send the data ... for example I will be sending the data of how many times the space bar is clicked 
    {        
        //Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" + score);
        // _testScore = score;
        _levelName = level;
        _targetWordsHit = targetWordsHit;
        _sessionID = DateTime.Now.Ticks;
        _numberOfDeselections = numberOfDeselections;
        _numberofPlayersCompletedLevel = numberOfPlayersCompletedLevel;
        Send();
    }

    public void EndOfGameDueToGameOver(string level, string gameOverReason) // this has to be called when the game ends .... to send the data ... for example I will be sending the data of how many times the space bar is clicked 
    {
        //Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" + score);
        // _testScore = score;
        _levelName = level;
        _gameOverReason = gameOverReason;
        _sessionID = DateTime.Now.Ticks;
        SendForGameOver();
    }




}



