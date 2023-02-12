using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int PlayerScore = 0;
    public Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = PlayerScore.ToString();

    }

    /*
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        PlayerScore += 1;
        ScoreText.text = PlayerScore.ToString();
    }
    */
}