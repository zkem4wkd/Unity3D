﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProject : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;
    // Start is called before the first frame update
    void Start()
    {
        this.car = GameObject.Find("car");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        float length = this.flag.transform.position.x - this.car.transform.position.x;
        if (length >= 0 )
        {
            this.distance.GetComponent<Text>().text = "목표 지점까지" + length.ToString("F2") + "남았습니다.";
        }
        else 
        {
            this.distance.GetComponent<Text>().text = "도착";
        }

        
    }
}
