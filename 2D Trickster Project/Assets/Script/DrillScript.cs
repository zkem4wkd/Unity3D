using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrillScript : MonoBehaviour
{
    Image drillBar;
    TextMeshProUGUI drillText;
    public float drillGauge;

    // Start is called before the first frame update
    void Start()
    {
        drillBar = GetComponent<Image>();
        drillBar.fillAmount = 0;
        drillText = GameObject.Find("DrillText").GetComponent<TextMeshProUGUI>();
        drillGauge = 100;
    }

    // Update is called once per frame
    void Update()
    {
        drillText.text = drillGauge + "%";
        drillBar.fillAmount = drillGauge / 100f;
    }
}
