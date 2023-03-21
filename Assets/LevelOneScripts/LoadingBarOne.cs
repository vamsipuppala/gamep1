using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class LoadingBarOne : MonoBehaviour
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
        SceneManager.LoadScene("LevelScenes/LevelTwo");
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
        SceneManager.LoadScene("LevelScenes/LevelTwo");
    }
    */
}
