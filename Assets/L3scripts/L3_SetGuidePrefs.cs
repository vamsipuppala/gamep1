using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L3_SetGuidePrefs : MonoBehaviour
{
    // Guidance panel
    public GameObject guideThreeObject;

    // Start is called before the first frame update
    public void Start()
    {
        guideThreeObject = GameObject.FindGameObjectWithTag("GuidePop3"); // Popup panel test

        /* Find tag test
        if (guideOneObject){
            Debug.Log("GUIDEONE IS  === " + guideOneObject.gameObject.name);
        }*/
    }

    // Update is called once per frame
    public void Update()
    { /*
        if (!guideOneObject.activeSelf)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("L1");
            guideOneObject.SetActive(false);

        } */

        // Bogus string sent to StartLevelOne because it needs at least 1 parameter
        StartLevelThree("check");
    }

    public void StartLevelThree(string checkStringThree)
    {
        // Check if pop-up panel is closed
        if (!guideThreeObject.activeSelf)
        {
            Debug.Log("POP-UP PANEL (LEVEL - 3) INACTIVE!!!!!");
            Time.timeScale = 1;
            //SceneManager.LoadScene("L1");
            //guideOneObject.SetActive(false);
            //Debug.Log("CHECK ==> " + checkString);
        }

    }
}
