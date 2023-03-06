using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelThreeHint : MonoBehaviour
{
    public GameObject PanelThree;
    int counter = 0;

    public void provideHintThree()
    {
        counter++;

        if (counter % 2 == 1)
        {
            PanelThree.SetActive(false);
        }
        else
        {
            PanelThree.SetActive(true);
        }
    }
}
