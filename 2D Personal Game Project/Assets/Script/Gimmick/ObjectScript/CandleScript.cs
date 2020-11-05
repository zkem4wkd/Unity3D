using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fire"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(collision.gameObject.CompareTag("Water"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
