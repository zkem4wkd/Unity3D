﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindStone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wind"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Invoke("active", 15f);
        }
    }
    void active()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
