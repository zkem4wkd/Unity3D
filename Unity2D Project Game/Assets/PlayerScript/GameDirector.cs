using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    // Start is called before the first frame update
    void Start()
    {
        hpGauge = GameObject.Find("BossHp");
    }
    public void HpDecrease()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
