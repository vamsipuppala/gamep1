using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L2_SetGuidePrefs : MonoBehaviour
{
    // Guidance panel
    public GameObject guideTwoObject;

    // Start is called before the first frame update
    public void Start()
    {
        guideTwoObject = GameObject.FindGameObjectWithTag("GuidePop2"); // Popup panel test

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
        StartLevelTwo("check");
    }

    public void StartLevelTwo(string checkStringThree)
    {
        // Check if pop-up panel is closed
        if (!guideTwoObject.activeSelf)
        {
            Debug.Log("POP-UP PANEL (LEVEL - 2) INACTIVE!!!!!");
            Time.timeScale = 1;
            //SceneManager.LoadScene("L1");
            //guideOneObject.SetActive(false);
            //Debug.Log("CHECK ==> " + checkString);
        }

    }
}
