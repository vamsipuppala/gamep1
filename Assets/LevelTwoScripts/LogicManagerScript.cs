using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //to access more UI functionalities - used to make reference to text
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        //restart the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        // Debug.Log("");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
