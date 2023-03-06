using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTwoHint : MonoBehaviour
{
    public GameObject PanelTwo;
    int counter = 0;

    public void provideHint()
    {
        counter++;

        if (counter % 2 == 1)
        {
            PanelTwo.SetActive(false);
        }
        else
        {
            PanelTwo.SetActive(true);
        }
    }
}
