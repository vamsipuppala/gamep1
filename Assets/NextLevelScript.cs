using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelScript : MonoBehaviour
{
    public GameObject NextLevel;

    public void Update()
    {
        if (ScoreScript.PlayerScore >= 1 & TimerScript.TimeValue > 0)
        {
            NextLevel.SetActive(true);
        }
    }
}
