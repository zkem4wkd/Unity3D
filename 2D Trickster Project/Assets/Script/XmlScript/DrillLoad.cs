using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillLoad : MonoBehaviour
{
    void Start()
    {
        List<RecItem> itemList = DrillIO.Read(Application.dataPath + "DrillGauge.xml");
        for (int i = 0; i < itemList.Count; i++)
        {
            RecItem item = itemList[i];
        }
    }
}
