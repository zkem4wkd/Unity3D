using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeView : MonoBehaviour
{
    TextMeshProUGUI text;
    GameController gC;
    private void Start()
    {
        gC = GameObject.Find("GameController").GetComponent<GameController>();
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        text.text = (gC.worldTime).ToString();
    }

}
