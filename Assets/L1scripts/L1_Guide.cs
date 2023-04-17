using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class L1_Guide : MonoBehaviour
{
    public GameObject guideObject;

    // Update is called once per frame
    void Update()
    {
        if (guideObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE IS INACTIVE !!");
        }
    }
}