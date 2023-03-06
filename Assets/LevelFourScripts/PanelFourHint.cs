using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFourHint : MonoBehaviour
{
    public GameObject PanelFour;
    int counter = 0;

    public void provideHintFour()
    {
        counter++;

        if (counter % 2 == 1)
        {
            PanelFour.SetActive(false);
        }
        else
        {
            PanelFour.SetActive(true);
        }
    }
}
