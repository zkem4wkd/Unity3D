using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<WeightScript>().weight >= 1)
        {
            Debug.Log("over");
        }
        else
        {
            Debug.Log("not over");
        }
    }
}
