using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject hpGauge;
    void Start()
    {
        hpGauge = GameObject.Find("HpGauge");
    }

    public void DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hpGauge.GetComponent<Image>().fillAmount == 0)
        {
            Debug.Log("Lose");
        }
    }
}
