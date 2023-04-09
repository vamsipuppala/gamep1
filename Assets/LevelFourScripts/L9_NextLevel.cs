using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L9_NextLevel : MonoBehaviour
{
    public GameObject NextLevel;
    public string levelName;
    //private int nextSceneToLoad;
    private bool loadScene = false;
    [SerializeField] private TextMeshProUGUI targetScore;
    public int thresholdScoree = 5;
    public SendToGoogle sc;
    public L9_PlayerController pc;



    private void Start()
    {
        targetScore.text = thresholdScoree.ToString();
        sc = GameObject.FindGameObjectWithTag("Logic").GetComponent<SendToGoogle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<L9_PlayerController>();
        //nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void Update()
    {
        if (!loadScene)
        {
            changeScene();
        }
    }

    private void changeScene()
    {
        //Debug.Log("hurrrrrrrrayyyyyyyyy"+ ScoreScript.PlayerScore);
        //Debug.Log("the danger word score is " + PlayerController.timesDangerWordWasHit);
        // SendToGoogle sc = new SendToGoogle();
        //Debug.Log("threshold score is " + thresholdScoree);
        if (ScoreScript.PlayerScore >= thresholdScoree && L9_Timer.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            //sc.EndOfGame(L4_PlayerController.timeTargetWordWasHit.ToString(), "2", L2_PlayerController.numberOfTimeDeselectionsOccurred.ToString(), "1",
            //L4_PlayerController.numberOfTimesWordHitInOrder.ToString(), L4_PlayerController.numberOfTimesWordHitInReverse.ToString());
            //sc.endGameWithZHitCount("2", L2_PlayerController.zHit.ToString());
            loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevel9");
        }

        if (ScoreScript.PlayerScore < thresholdScoree && L9_Timer.TimeValue <= 0)
        {
            // sc.EndOfGame(L2_PlayerController.timeTargetWordWasHit.ToString(), "2", L2_PlayerController.numberOfTimeDeselectionsOccurred.ToString(), "0",
            //L2_PlayerController.numberOfTimesWordHitInOrder.ToString(), L2_PlayerController.numberOfTimesWordHitInReverse.ToString());
            //game over screen
            //sc.endGameWithZHitCount("2", L2_PlayerController.zHit.ToString());
            GameOver("noTimeLeft");
        }
    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        L7_Timer.TimeValue = 240;
        //L2_Timer.TimeValue = 300; // time used for testing collision.
        //L2_Timer.TimeValue = 10; // time used for testing timeout.
    }

    public void GameOver(string gameOverReason)
    {
        //sc.EndOfGameDueToGameOver("2", gameOverReason);

        // Set the game over reason on the GameOver scene. 
        PlayerPrefs.SetString("GameOverReason", "Game terminated due to timeout!");

        SceneManager.LoadScene("GameOver");
    }
}