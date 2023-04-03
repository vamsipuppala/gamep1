using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelThree : MonoBehaviour
{
    public GameObject NextLevelObject;
    public string levelName;
    //private int nextSceneToLoad;
    private bool loadScene = false;
    [SerializeField] private TextMeshProUGUI targetScore;
    public int thresholdScoree = 4;
    public SendToGoogle sc;
    public PlayerControllerThree pc;


    private void Start()
    {
        targetScore.text = "Target Score:  " + thresholdScoree;
        sc = GameObject.FindGameObjectWithTag("Logic").GetComponent<SendToGoogle>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerThree>();
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
        if (ScoreScript.PlayerScore >= thresholdScoree && TimerThree.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            sc.EndOfGame(PlayerControllerThree.timeTargetWordWasHit.ToString(), "3", PlayerControllerThree.numberOfDeselections.ToString(), "1", PlayerControllerThree.numberOfTimesWordHitInOrder.ToString(),
                PlayerControllerThree.numberOfTimesWordHitInReverse.ToString());
            sc.endGameWithZHitCount("3", PlayerControllerThree.zHit.ToString());
            loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevelThree");
        }

        if (ScoreScript.PlayerScore < thresholdScoree && TimerThree.TimeValue <= 0)
        {
            sc.EndOfGame(PlayerControllerThree.timeTargetWordWasHit.ToString(), "3", PlayerControllerThree.numberOfDeselections.ToString(), "0",
                PlayerControllerThree.numberOfTimesWordHitInOrder.ToString(),PlayerControllerThree.numberOfTimesWordHitInReverse.ToString());
            //game over screen
            sc.endGameWithZHitCount("3", PlayerControllerThree.zHit.ToString());
            GameOver("noTimeLeft");
        }

        /*
        if ((PlayerPrefs.GetInt("IndexOutBounds") == 1) && ScoreScript.PlayerScore < thresholdScoree && TimerThree.TimeValue > 0)
        {
            // Set the game over reason on the GameOver scene.
            Debug.Log("Game terminated - BLOCK SPAWN STOP! --- INSIDE NL3");
            PlayerPrefs.SetString("GameOverReason", "Game terminated - BLOCK SPAWN STOP!");
            //SceneManager.LoadScene("GameOver");
        }*/

    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        TimerThree.TimeValue = 330; // OG
        //TimerThree.TimeValue = 120; // time used for testing collision.
        //TimerThree.TimeValue = 10; // time used for testing timeout.
    }

    public void GameOver(string gameOverReason)
    {
        sc.EndOfGameDueToGameOver("3", gameOverReason);

        // Set the game over reason on the GameOver scene. 
        PlayerPrefs.SetString("GameOverReason", "Game terminated due to timeout!");

        SceneManager.LoadScene("GameOver");
    }
}
