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

    public void DisplayDangerMessage(float TimeToDisplay)
    {
        ShowPopupWindow();
        Invoke("HideWindow", TimeToDisplay);

    }

    public void HideWindow()
    {
        dangerPopUpPanel.SetActive(false);
    }

    public void ShowPopupWindow()
    {
        dangerPopUpPanel.SetActive(true);
    }

    public void ChangeDangerMessageText(string newText)
    {
        dangerMessageText.text = newText;
        // Debug.Log(dangerMessageText);
    }

}