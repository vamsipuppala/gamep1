using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MessageManagerScript : MonoBehaviour
{
    public Text dangerMessageText;
    public GameObject dangerPopUpPanel;


    // Update is called once per frame
    void Update()
    {

    }

    // Define the DisplayDangerMessage() function, which shows the danger pop-up panel for a specified amount of time
    public void DisplayDangerMessage(float TimeToDisplay)
    {
        ShowPopupWindow();
        // Hide the danger pop-up panel after the specified amount of time has elapsed
        Invoke("HideWindow", TimeToDisplay);

    }

    // Define the HideWindow() function, which hides the danger pop-up panel
    public void HideWindow()
    {
        dangerPopUpPanel.SetActive(false);
    }

    // Define the ShowPopupWindow() function, which shows the danger pop-up panel
    public void ShowPopupWindow()
    {
        dangerPopUpPanel.SetActive(true);
    }

    public void ChangeDangerMessageText(string newText)
    {
        dangerMessageText.text = newText;
    }

}