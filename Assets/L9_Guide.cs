using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L9_Guide : MonoBehaviour
{
    public GameObject guideNineObject;

    // Update is called once per frame
    void Update()
    {
        if (guideNineObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE9 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE9 IS INACTIVE !!");
        }
    }
}
