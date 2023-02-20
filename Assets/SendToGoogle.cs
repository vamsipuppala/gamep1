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
    private string _testScore;
    private string _DangerWordsHit;
    GameObject myObject;
    ScoreScript sc;
     
    // Start is called before the first frame update

    private void Awake()
    {
         myObject = GameObject.Find("ScoreText");
         sc = myObject.GetComponent<ScoreScript>();
        _sessionID = DateTime.Now.Ticks;
        // Assign sessionID to identify playtests

    }

    public void Send()
    {
        // Assign variables
        // _testInt = 0; // yeh yahaan initialize hoga         
        Debug.Log("_________________" + _testScore);
        //ScoreScript sc = myObject.GetComponent<ScoreScript>();
        Debug.Log("+++++++++++" + _sessionID);
        StartCoroutine(Post(_sessionID.ToString(),_testScore, _DangerWordsHit));
    }

    private IEnumerator Post( string _sessionID,string testInt, string dangerWords)
    {
        Debug.Log("////////////////////////" + testInt);
        WWWForm form = new WWWForm();
        form.AddField("entry.199825233", _sessionID);
        form.AddField("entry.1486365924", testInt);
        form.AddField("entry.83745425", dangerWords);

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

    public void EndOfGame(string score, string dangerWordsHit) // this has to be called when the game ends .... to send the data ... for example I will be sending the data of how many times the space bar is clicked 
    {        
        Debug.Log("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" + score);
        _testScore = score;
        _DangerWordsHit = dangerWordsHit;
        _sessionID = DateTime.Now.Ticks;
        Send();
    }
}



