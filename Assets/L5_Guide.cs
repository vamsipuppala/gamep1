using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L5_Guide : MonoBehaviour
{
    public GameObject guideFiveObject;

    // Update is called once per frame
    void Update()
    {
        if (guideFiveObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE5 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE5 IS INACTIVE !!");
        }
    }
}
