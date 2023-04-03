using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject PanelTwo;
    // Start is called before the first frame update
    void Start()
    {
        if (PanelTwo != null)
        {
            PanelTwo.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
