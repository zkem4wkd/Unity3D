using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    SpriteRenderer Color;
    // Start is called before the first frame update
    void Start()
    {
        Color = GetComponent<SpriteRenderer>();
        StartCoroutine("FadeIn");
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1f);
        for (float i= 1 ;i > 0.0f; )
        {
            Color.color = new Color(255,255,255,i);

            yield return new WaitForSeconds(0.2f);
            i -= 0.1f;

        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
