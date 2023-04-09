using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class L4_SetGuidePrefs : MonoBehaviour
{
    // Guidance panel
    public GameObject guideFourObject;

    // Start is called before the first frame update
    public void Start()
    {
        guideFourObject = GameObject.FindGameObjectWithTag("GuidePop4"); // Popup panel test

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
        StartLevelFour("check");
    }

    public void StartLevelFour(string checkStringThree)
    {
        // Check if pop-up panel is closed
        if (!guideFourObject.activeSelf)
        {
            Debug.Log("POP-UP PANEL (LEVEL - 4) INACTIVE!!!!!");
            Time.timeScale = 1;
            //SceneManager.LoadScene("L1");
            //guideOneObject.SetActive(false);
            //Debug.Log("CHECK ==> " + checkString);
        }

    }
}
