using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelTwo : MonoBehaviour
{
    public GameObject NextLevel;
    public string levelName;
    //private int nextSceneToLoad;
    private bool loadScene = false;
    [SerializeField] private TextMeshProUGUI targetScore;
    public int thresholdScoree = 6;
    public SendToGoogle sc;
    public PlayerControllerTwo pc;
   


    private void Start()
    {
        targetScore.text = "Target Score:  " + thresholdScoree;
        sc = GameObject.FindGameObjectWithTag("Logic").GetComponent<SendToGoogle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerTwo>();
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
        if (ScoreScript.PlayerScore >= thresholdScoree && TimerTwo.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            sc.EndOfGame(PlayerControllerTwo.timeTargetWordWasHit.ToString(), "2", PlayerControllerTwo.numberOfTimeDeselectionsOccurred.ToString(), "1");
            loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevelTwo");
        }

        if (ScoreScript.PlayerScore < thresholdScoree && TimerTwo.TimeValue <= 0)
        {
            sc.EndOfGame(PlayerControllerTwo.timeTargetWordWasHit.ToString(), "2", PlayerControllerTwo.numberOfTimeDeselectionsOccurred.ToString(), "0");
            //game over screen
            GameOver("noTimeLeft");
        }
    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        TimerTwo.TimeValue = 100;
    }

    public void GameOver(string gameOverReason)
    {
        sc.EndOfGameDueToGameOver("2", gameOverReason);
        SceneManager.LoadScene("GameOver");
    }
}