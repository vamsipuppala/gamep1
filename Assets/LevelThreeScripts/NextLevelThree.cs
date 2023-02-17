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
    public int thresholdScoree = 2;
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
        if (ScoreScript.PlayerScore == thresholdScoree && TimerThree.TimeValue > 0)
        {
            //Debug.Log("It should now change the scene" +ScoreScript.PlayerScore);
            sc.EndOfGame(ScoreScript.PlayerScore.ToString(), PlayerControllerThree.timesDangerWordWasHit.ToString());
            loadScene = true;
            resetValues();
            SceneManager.LoadScene("LevelScenes/CompleteLevelThree");
        }

        if (TimerThree.TimeValue <= 0)
        {
            sc.EndOfGame(ScoreScript.PlayerScore.ToString(), PlayerControllerThree.timesDangerWordWasHit.ToString());
            //game over screen
        }
    }

    public void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        TimerThree.TimeValue = 180;
    }
}
