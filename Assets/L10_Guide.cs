using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L10_Guide : MonoBehaviour
{
    public GameObject guideTenObject;

    // Update is called once per frame
    void Update()
    {
        if (guideTenObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE10 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE10 IS INACTIVE !!");
        }
    }
}
