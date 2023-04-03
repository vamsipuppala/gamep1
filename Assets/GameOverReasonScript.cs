using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverReasonScript : MonoBehaviour
{
    public TextMeshProUGUI displayReason;

    public void Awake()
    {
        displayReason.text = PlayerPrefs.GetString("GameOverReason");
    }
}
