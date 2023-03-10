using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject NextLevelObject;
    public string levelName;
    //private int nextSceneToLoad;
    private bool loadScene = false;
    [SerializeField] private TextMeshProUGUI targetScore;
    public int thresholdScoree = 5;
    public SendToGoogle sc;
    public PlayerControllerOne pc;


    private void Start()
    {
        targetScore.text = "Target Score:  " + thresholdScoree;
        sc = GameObject.FindGameObjectWithTag("Logic").GetComponent<SendToGoogle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerOne>();
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
        if (ScoreScript.PlayerScore >= thresholdScoree && TimerOne.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            sc.EndOfGame(PlayerController.timeTargetWordWasHit.ToString(), "1", PlayerController.numberOfTimeDeselectionsOccurred.ToString() , "1");
            loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevelOne");
        }

        if (ScoreScript.PlayerScore < thresholdScoree && TimerOne.TimeValue <= 0)
        {
            sc.EndOfGame(PlayerController.timeTargetWordWasHit.ToString(), "1", PlayerController.numberOfTimeDeselectionsOccurred.ToString(), "0");
            //game over screen
            GameOver("noTime");
        }
    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        TimerOne.TimeValue = 120;
    }

    public void GameOver(string gameOverReason)
    {
        sc.EndOfGameDueToGameOver( "1", gameOverReason);
        SceneManager.LoadScene("GameOver");
    }
}
