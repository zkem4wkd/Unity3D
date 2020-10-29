using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<RecItem> itemList = ItemIO.Read(Application.dataPath + "ItemList_Attributes.xml");
        for(int i = 0; i < itemList.Count; i++)
        {
            RecItem item = itemList[i];
            Debug.Log(string.Format("Item[{0}] : ({1},{2},{3})",i,item.Name,item.Level,item.Critical));
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
