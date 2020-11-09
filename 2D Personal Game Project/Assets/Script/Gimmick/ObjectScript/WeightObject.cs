using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeightObject : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject[] traps;
    public Sprite weightOn;
    public Sprite weightOff;
    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        try
        {
            if (collision.GetComponent<WeightScript>().weight >= 1)
            {
                sprite.sprite = weightOn;
                for (int i = 0; i < traps.Length; i++)
                {
                    traps[i].GetComponent<Animator>().SetBool("TrapOff", true);
                    traps[i].GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        catch(NullReferenceException ie)
        {
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<WeightScript>().weight >= 1)
        {
            sprite.sprite = weightOff;   
        }
    }
}
