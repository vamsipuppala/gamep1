using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenScript : MonoBehaviour
{

    public NextLevelScript nextLevelScript;
    // public GameObject guideOne; // Popup panel test

    void Start()
    {
        //  loadMainScreen();
        // nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<NextLevelScript>();
        /* // Popup panel test
        guideOne = GameObject.FindGameObjectWithTag("GuidePopup1"); // Popup panel test
        if (!guideOne)
        {
            Debug.Log("GUIDEONE IS NULL === " + guideOne);
        }*/
    }
    public void loadTutorialScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("Tutorial_Level1");
    }

    /*
    public void loadLevelOneScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("L1");
    } */

    public void loadLevelOneScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneOne());
    }

    IEnumerator LoadSceneOne()
    {

        //Begin to load the Scene you specify asynchronously
        AsyncOperation asyncOperationOne = SceneManager.LoadSceneAsync("L1");

        //Don't let the Scene activate until you allow it to
        asyncOperationOne.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENEONE:" + asyncOperationOne.progress);

        //Wait till the load is still in progress
        while (!asyncOperationOne.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperationOne.progress >= 0.9f) 
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperationOne.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 1) from starting. 
                Time.timeScale = 0;
                    
            }
            yield return null;
        }
    }



    public void loadMainScreen()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("MainScreen");
    }

    /*
    public void loadLevelTwoScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/L2");
    }*/

    public void loadLevelTwoScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneTwo());
    }

    IEnumerator LoadSceneTwo()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationTwo = SceneManager.LoadSceneAsync("L2");

        //Don't let the Scene activate until you allow it to
        asyncOperationTwo.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENETWO:" + asyncOperationTwo.progress);

        //Wait till the load is still in progress
        while (!asyncOperationTwo.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperationTwo.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperationTwo.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 2) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    /*
    public void loadLevelThreeScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/L3");
    } */

    public void loadLevelThreeScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneThree());
    }

    IEnumerator LoadSceneThree()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationThree = SceneManager.LoadSceneAsync("L3");

        //Don't let the Scene activate until you allow it to
        asyncOperationThree.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENETHREE:" + asyncOperationThree.progress);

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
    public void loadLevelFourScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/L4");
    }*/

    public void loadLevelFourScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneFour());
    }

    IEnumerator LoadSceneFour()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFour = SceneManager.LoadSceneAsync("L4");

        //Don't let the Scene activate until you allow it to
        asyncOperationFour.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENEFOUR:" + asyncOperationFour.progress);

        //Wait till the load is still in progress
        while (!asyncOperationFour.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperationFour.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperationFour.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    /*
    public void loadLevelFiveScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/L5");
    }*/

    public void loadLevelFiveScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneFive());
    }

    public void loadLevelSixScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneSix());
    }


    public void loadLevelSevenScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneSeven());
    }

    public void loadLevelEightScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneEight());
    }

    public void loadLevelNineScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneNine());
    }

    public void loadLevelTenScene()
    {
        //Start loading the Scene asynchronously and show the guidance text
        StartCoroutine(LoadSceneTen());
    }

    public void loadLevel11Scene()
    {
        StartCoroutine(LoadScene11());
    }

 
    public void loadLevel12Scene()
    {
        StartCoroutine(LoadScene12());
    }
    public void loadLevel13Scene()
    {
        StartCoroutine(LoadScene13());
    }
    public void loadLevel14Scene()
    {
        StartCoroutine(LoadScene14());
    }
    public void loadLevel15Scene()
    {
        StartCoroutine(LoadScene15());
    }
    public void loadLevel16Scene()
    {
        StartCoroutine(LoadScene16());
    }

    public void loadLevel17Scene()
    {
        StartCoroutine(LoadScene17());
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


    IEnumerator LoadSceneSix()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L6");

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

    IEnumerator LoadSceneSeven()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L7");

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

    IEnumerator LoadSceneEight()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L8");

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

    IEnumerator LoadSceneNine()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L9");

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


    IEnumerator LoadSceneTen()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperationFive = SceneManager.LoadSceneAsync("L10");

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


    IEnumerator LoadScene11()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation11 = SceneManager.LoadSceneAsync("L11");

        //Don't let the Scene activate until you allow it to
        asyncOperation11.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation11.progress);

        //Wait till the load is still in progress
        while (!asyncOperation11.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation11.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation11.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene12()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation12 = SceneManager.LoadSceneAsync("L12");

        //Don't let the Scene activate until you allow it to
        asyncOperation12.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation12.progress);

        //Wait till the load is still in progress
        while (!asyncOperation12.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation12.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation12.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene13()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation13 = SceneManager.LoadSceneAsync("L13");

        //Don't let the Scene activate until you allow it to
        asyncOperation13.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation13.progress);

        //Wait till the load is still in progress
        while (!asyncOperation13.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation13.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation13.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene14()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation14 = SceneManager.LoadSceneAsync("L14");

        //Don't let the Scene activate until you allow it to
        asyncOperation14.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation14.progress);

        //Wait till the load is still in progress
        while (!asyncOperation14.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation14.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation14.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene15()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation15 = SceneManager.LoadSceneAsync("L15");

        //Don't let the Scene activate until you allow it to
        asyncOperation15.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation15.progress);

        //Wait till the load is still in progress
        while (!asyncOperation15.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation15.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation15.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene16()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation16 = SceneManager.LoadSceneAsync("Lfun");

        //Don't let the Scene activate until you allow it to
        asyncOperation16.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation16.progress);

        //Wait till the load is still in progress
        while (!asyncOperation16.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation16.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation16.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }

    IEnumerator LoadScene17()
    {
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation17 = SceneManager.LoadSceneAsync("L17");

        //Don't let the Scene activate until you allow it to
        asyncOperation17.allowSceneActivation = false;

        Debug.Log("ASYNC PROGRESS INSIDE LOADSCENE11:" + asyncOperation17.progress);

        //Wait till the load is still in progress
        while (!asyncOperation17.isDone)
        {
            Debug.Log("ASYNC INSIDE ISDONE");

            // Check if the load has finished
            if (asyncOperation17.progress >= 0.9f)
            {
                Debug.Log("ASYNC INSIDE .PROGRESS");

                //Activate the Scene
                asyncOperation17.allowSceneActivation = true;

                // Set timescale to 0 to stop the background (level 4) from starting. 
                Time.timeScale = 0;

            }
            yield return null;
        }
    }




}
