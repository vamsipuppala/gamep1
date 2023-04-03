using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenScript : MonoBehaviour
{

    public NextLevelScript nextLevelScript;


    void Start()
    {
        //  loadMainScreen();
       // nextLevelScript = GameObject.FindGameObjectWithTag("NextLevelManager").GetComponent<NextLevelScript>();

    }
    public void loadTutorialScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("Tutorial_Level1");
    }

    public void loadLevelOneScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("L1");
    }

    public void loadMainScreen()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("MainScreen");
    }

    public void loadLevelTwoScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/L2");
    }

    public void loadLevelThreeScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/LevelThree");
    }

    public void loadLevelFourScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/LevelFour");
    }

    public void loadLevelFiveScene()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("LevelScenes/LevelTwo");
    }


}
