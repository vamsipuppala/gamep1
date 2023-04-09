using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class TextBlinkScript : MonoBehaviour
{
    public Image targetBorder;
    public Image dangerBorder;
    public float blinkDuration = 1;
    public float blinkInterval = 0.1f;

    private void Start()
    {
        targetBorder.enabled = false;
        dangerBorder.enabled = false;
    }

    public void StartBlinking(string name)
    {
        if(name == "targetBorder"){
            StartCoroutine(BlinkCoroutine(targetBorder));
        }else if(name == "dangerBorder"){
            StartCoroutine(BlinkCoroutine(dangerBorder));
        }
        
    }

    private IEnumerator BlinkCoroutine(Image border)
    {
        border.enabled = true;

        float timer = 0f;
        while (timer < blinkDuration)
        {
            border.enabled = !border.enabled;
            yield return new WaitForSeconds(blinkInterval);
            timer += blinkInterval;
        }

        border.enabled = false;
    }
}
