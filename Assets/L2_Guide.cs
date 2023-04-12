using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_Guide : MonoBehaviour
{
    public GameObject guideTwoObject;

    // Update is called once per frame
    void Update()
    {
        if (guideTwoObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE2 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE2 IS INACTIVE !!");
        }
    }
}
