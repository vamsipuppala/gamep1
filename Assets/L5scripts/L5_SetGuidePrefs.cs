using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L5_SetGuidePrefs : MonoBehaviour
{
    // Guidance panel
    public GameObject guideFiveObject;

    // Start is called before the first frame update
    public void Start()
    {
        guideFiveObject = GameObject.FindGameObjectWithTag("GuidePop5"); // Popup panel test

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

        // Bogus string sent to StartLevel because it needs at least 1 parameter
        StartLevelFive("check");
    }

    public void StartLevelFive(string checkStringThree)
    {
        // Check if pop-up panel is closed
        if (!guideFiveObject.activeSelf)
        {
            Debug.Log("POP-UP PANEL (LEVEL - 5) INACTIVE!!!!!");
            Time.timeScale = 1;
            //SceneManager.LoadScene("L1");
            //guideOneObject.SetActive(false);
            //Debug.Log("CHECK ==> " + checkString);
        }

    }
}
