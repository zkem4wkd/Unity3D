using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using System;

public class WeightObject1 : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject[] traps;
    public Sprite weightOn;
    public Sprite weightOff;
    public PlayableDirector timeline;

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.GetComponent<WeightScript>().weight >= 1)
            {
                for (int i = 0; i < traps.Length; i++)
                {
                    traps[i].SetActive(true);
                    timeline.Play();
                }
            }
        }
        catch(NullReferenceException ie)
        {
            
        }
    }
}
