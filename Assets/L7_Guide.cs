using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L7_Guide : MonoBehaviour
{
    public GameObject guideSevenObject;

    // Update is called once per frame
    void Update()
    {
        if (guideSevenObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE7 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE7 IS INACTIVE !!");
        }
    }
}
