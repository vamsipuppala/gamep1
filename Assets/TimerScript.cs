using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static float TimeValue = 60;
    public Text TimerText;

    // Update is called once per frame
    void Update()
    {
        if (TimeValue > 0)
        {
            TimeValue -= Time.deltaTime;
        }

        else
        {
            TimeValue = 0;
        }

        DisplayTime(TimeValue);
    }

    void DisplayTime(float TimeToDisplay)
    {

        if (TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}