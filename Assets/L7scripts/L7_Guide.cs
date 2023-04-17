using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L7_Guide : MonoBehaviour
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
