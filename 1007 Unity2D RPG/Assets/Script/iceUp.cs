﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceUp : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed *Time.deltaTime);   
    }
}
