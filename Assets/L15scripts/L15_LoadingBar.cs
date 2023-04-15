using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L15_LoadingBar : MonoBehaviour
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
        //SceneManager.LoadScene("LevelScenes/L3");
        loadLevelThreeScene();
    }

    public void loadLevelThreeScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneThree());
    }

    IEnumerator LoadSceneThree()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationThree = SceneManager.LoadSceneAsync("L9");

        //Don't let the Scene activate until you allow it to
        asyncOperationThree.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENETWO:" + asyncOperationThree.progress);

        //Wait till the load is still in progress
        while (!asyncOperationThree.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperationThree.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperationThree.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 3) from starting. 
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
