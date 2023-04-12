using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L8_Guide : MonoBehaviour
{
    public GameObject guideEightObject;

    // Update is called once per frame
    void Update()
    {
        if (guideEightObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE8 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE8 IS INACTIVE !!");
        }
    }
}
