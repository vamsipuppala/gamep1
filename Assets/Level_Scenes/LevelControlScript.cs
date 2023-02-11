using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject NextLevel;
    public string levelName;
    private int nextSceneToLoad;
    private bool loadScene = false;

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

    private void changeScene() {

        if (ScoreScript.PlayerScore >= 1 & TimerScript.TimeValue > 0)
        {
            loadScene = true;
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }
}
