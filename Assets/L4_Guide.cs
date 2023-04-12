using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4_Guide : MonoBehaviour
{
    public GameObject guideFourObject;

    // Update is called once per frame
    void Update()
    {
        if (guideFourObject.activeSelf)
        {
            Time.timeScale = 0;
            Debug.Log("GUIDE4 IS ACTIVE !!");
        }

        else
        {
            Time.timeScale = 1;
            Debug.Log("GUIDE4 IS INACTIVE !!");
        }
    }
}
