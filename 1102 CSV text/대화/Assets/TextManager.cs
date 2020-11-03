using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text dasa;
    int dasaCount = 0;
    List<Dictionary<string, object>> data;

    private void Start()
    {
        data = CSVReader.Read("story");
        dasa.text = data[dasaCount]["이름"] + " : " + data[dasaCount]["대사"];
        dasaCount++;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(dasaCount<data.Count)
            {
                dasa.text = data[dasaCount]["이름"] + " : " + data[dasaCount]["대사"];
                dasaCount++;
            }
            else
            {
                //페이드인페이드아웃
                //다음씬넘어가라~
            }
        }
    }





}
