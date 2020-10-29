using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class SaveTest : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        List<RecItem> itemList = new List<RecItem>();
        for(int i = 0; i < 10; i++)
        {
            RecItem item = new RecItem();
            item.Name = "아이템";
            item.Level = 1;
            item.Critical = Random.Range(0.1f, 1.0f);
            itemList.Insert(i, item);
        }
        ItemIO.Write(itemList,Application.dataPath + "ItemList_Attributes.xml");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
