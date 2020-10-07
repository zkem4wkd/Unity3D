using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textmanager : MonoBehaviour
{
    public Text title;
    public Text gameStart;
    public Text option;
    public Text gameEnd;
    // Start is called before the first frame update
    void Start()
    {
        title.text = "Kerbal Space Program";
        title.fontSize = 46;
        title.alignment = TextAnchor.MiddleCenter;
        gameStart.text = "게임 시작";
        option.text = "옵션";
        gameEnd.text = "게임 종료";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
