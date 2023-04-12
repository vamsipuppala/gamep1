using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L6_Guide : MonoBehaviour
{
    public GameObject guideSixObject;

    // Update is called once per frame
    void Update()
    {
        if (guideSixObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE6 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE6 IS INACTIVE !!");
        }
    }
}
