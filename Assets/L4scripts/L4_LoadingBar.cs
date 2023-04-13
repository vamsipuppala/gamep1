using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L4_LoadingBar : MonoBehaviour
{
    public GameObject bar;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        animateBar();
        //StartCoroutine(ChangeAfter5SecondsCoroutine());
        Invoke(nameof(startNextLevel), 5);
    }

    public void animateBar()
    {
        LeanTween.scaleX(bar, 1, time * 2);
    }

    public void startNextLevel()
    {
        //SceneManager.LoadScene("LevelScenes/L5");
        loadLevelFiveScene();
    }

    public void loadLevelFiveScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneFive());
    }

    IEnumerator LoadSceneFive()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L5");

        //Don't let the Scene activate until you allow it to
        asyncOperationFive.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENEFIVE:" + asyncOperationFive.progress);

        //Wait till the load is still in progress
        while (!asyncOperationFive.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperationFive.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperationFive.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    /*
    IEnumerator ChangeAfter5SecondsCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        //And load the scene
        Debug.Log("IN LOADING BAR TWO == ENTERING LEVEL 3");
        SceneManager.LoadScene("LevelScenes/LevelThree");
        //SceneManager.LoadScene(6);
    }
    */

}
