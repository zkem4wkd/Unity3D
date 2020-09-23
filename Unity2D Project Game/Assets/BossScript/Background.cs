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
    IEnumerable FadeIn()
    {
        for (float i= 1 ;i > 0.0f ;i -= 0.1f)
        {
            Color.color = new Color(0,0,0,i);
        }
        yield return new WaitForSeconds(1f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
