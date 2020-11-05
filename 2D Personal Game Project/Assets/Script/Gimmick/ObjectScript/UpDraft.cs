using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDraft : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<WeightScript>().weight <= 1)
        {
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }
}
