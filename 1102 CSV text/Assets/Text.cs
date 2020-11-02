using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("TextFile");

        for (var i = 0; i < data.Count; i++)
        {
            print("name " + data[i]["name"] + " " +
                   "text " + data[i]["text"]);
        }

    }
}
