using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class L1_NextLevel : MonoBehaviour
{
    public GameObject NextLevelObject;
    public string levelName;
    //private int nextSceneToLoad;
    private bool loadScene = false;
    [SerializeField] private TextMeshProUGUI targetScore;
    public int thresholdScoree = 16;
    public SendToGoogle sc;
    public L1_PlayerControllerOne pc;
    public float blinkTime = 0.5f;
        

    private void Start()
    {
        targetScore.text = ""+thresholdScoree;
        sc = GameObject.FindGameObjectWithTag("Logic").GetComponent<SendToGoogle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<L1_PlayerControllerOne>();
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
        if (ScoreScript.PlayerScore >= thresholdScoree && L1_TimerOne.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            // sc.EndOfGame(PlayerControllerOne.timeTargetWordWasHit.ToString(), "1", PlayerControllerOne.numberOfTimeDeselectionsOccurred.ToString() , "1",
            //      PlayerControllerOne.numberOfTimesWordHitInOrder.ToString(), PlayerControllerOne.numberOfTimesWordHitInReverse.ToString());
            // loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevelOne");
        }

        if (ScoreScript.PlayerScore < thresholdScoree && L1_TimerOne.TimeValue <= 0)
        {
            // sc.EndOfGame(PlayerControllerOne.timeTargetWordWasHit.ToString(), "1", PlayerControllerOne.numberOfTimeDeselectionsOccurred.ToString(), "1",
            //     PlayerControllerOne.numberOfTimesWordHitInOrder.ToString(), PlayerControllerOne.numberOfTimesWordHitInReverse.ToString());
            //game over screen
            GameOver("noTime");
        }
    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        L1_TimerOne.TimeValue = 150;
        //L1_TimerOne.TimeValue = 300; // time used for testing collision.
        //L1_TimerOne.TimeValue = 10; // time used for testing timeout.
    }

    public void GameOver(string gameOverReason)
    {
        sc.EndOfGameDueToGameOver( "1", gameOverReason);

        if (gameOverReason.Equals("noTimeLeft"))
        {
            PlayerPrefs.SetString("GameOverReason", "Game terminated due to timeout!");

        }
        else
        {
            PlayerPrefs.SetString("GameOverReason", "Game terminated due to collision with blocks!");
        }

        // Set the game over reason on the GameOver scene. 
        

        SceneManager.LoadScene("GameOver");
    }
}
