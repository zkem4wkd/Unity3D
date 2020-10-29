using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillSave : MonoBehaviour
{
    void Start()
    {
        List<RecItem> itemList = new List<RecItem>();
        for (int i = 0; i < 10; i++)
        {
            RecItem item = new RecItem();
            item.DrillGauge = 1;
            itemList.Insert(i, item);
        }
        DrillIO.Write(itemList, Application.dataPath + "DrillGauge.xml");
    }
}
