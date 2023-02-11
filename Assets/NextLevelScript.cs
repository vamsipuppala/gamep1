using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelScript : MonoBehaviour
{
    public GameObject NextLevel;
    public string levelName;
    private int nextSceneToLoad;
    private bool loadScene = false;
    public int thresholdScore = 3;

    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
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

        if (ScoreScript.PlayerScore >= thresholdScore & TimerScript.TimeValue > 0)
        {
            loadScene = true;
            resetValues();
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    private void resetValues()
    {
        ScoreScript.PlayerScore = 0;
        TimerScript.TimeValue = 60;
    }
}