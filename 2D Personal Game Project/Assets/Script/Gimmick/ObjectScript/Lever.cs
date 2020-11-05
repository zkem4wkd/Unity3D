using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject Downlever;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<WeightScript>().weight > 1)
        {
            Downlever.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
