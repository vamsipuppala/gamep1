using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L3_Guide : MonoBehaviour
{
    public GameObject guideThreeObject;

    // Update is called once per frame
    void Update()
    {
        if (guideThreeObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE3 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE3 IS INACTIVE !!");
        }
    }
}
