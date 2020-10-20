using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Fade fade;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeAction());
    }

    IEnumerator FadeAction()
    {
        fade.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        fade.FadeOut(1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
