using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenScript : MonoBehaviour
{

    void Start()
    {
      //  loadMainScreen();
    }
    public void loadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial_Level1");
    }

    public void loadLevelOneScene()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void loadMainScreen()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
