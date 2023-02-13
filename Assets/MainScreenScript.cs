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
        SceneManager.LoadScene("LevelOne");
    }

    public void loadMainScreen()
    {
        //nextLevelScript.resetValues();
        SceneManager.LoadScene("MainScreen");
    }
}
