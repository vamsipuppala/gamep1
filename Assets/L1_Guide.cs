using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1_Guide : MonoBehaviour
{
    public GameObject guideOneObject;

    // Update is called once per frame
    void Update()
    {
        if (guideOneObject.activeSelf) {
            Time.timeScale = 0;
            Debug.Log("GUIDE1 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE1 IS INACTIVE !!");
        }
    }
}
