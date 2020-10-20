using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public void FadeIn(float fadeOutTime)
    {
        StartCoroutine(CoFadeIn(1));
    }

    public void FadeOut(float fadeOutTime)
    {
        StartCoroutine(CoFadeOut(fadeOutTime));
    }

    IEnumerator CoFadeIn(float fadeOutTime)
    {
        Image img = GetComponent<Image>();
        Color tempColor = img.color;

        while(tempColor.a < 1f)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            img.color = tempColor;

            if(tempColor.a >= 1f)
            {
                tempColor.a = 1f;
                yield return null;
            }
            img.color = tempColor;
        }
    }
    IEnumerator CoFadeOut(float fadeOutTime)
    {
        Image img = GetComponent<Image>();
        Color tempColor = img.color;

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            img.color = tempColor;

            if (tempColor.a <= 0f)
            {
                tempColor.a = 0f;
                yield return null;
            }
            img.color = tempColor;
        }
    }
}
