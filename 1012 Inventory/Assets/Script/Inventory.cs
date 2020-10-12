using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public class Item
    {
        public int itemType;
        public string name { get; set; }
        public int price { get; set; }
        public int sellPrice { get; set; }

    }
    class Weapon : Item
    {
        private float atkPoint { get; set; }
        public Weapon()
        {

        }
    }
    class Armor : Item
    {
        private float defPoint { get; set; }
        public Armor()
        {

        }
    }

    class Equip : Item
    {
        private float heal { get; set;}
        public Equip()
        {

        }
    }

    Item item;
    List<Item> ItemList = new List<Item>();
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void getItem(Item it)
    {
        switch (item.itemType)
        {
            case 0:
                Debug.Log("Weapon");
                break;
            case 1:
                Debug.Log("Armor");
                break;
            case 2:
                Debug.Log("Equipment");
                break;
        }

    }
    public void getItemList(List<Item> it)
    {
        for(int i = 0; i<it.Count; i++)
        {
            switch (it[i].itemType)
            {
                case 0:
                    Debug.Log("Weapon");
                    break;
                case 1:
                    Debug.Log("Armor");
                    break;
                case 2:
                    Debug.Log("Equipment");
                    break;
            }
        }

        

    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    item = new Weapon();
                    item.itemType = 0;
                    break;
                case 1:
                    item = new Armor();
                    item.itemType = 1;
                    break;
                case 2:
                    item = new Equip();
                    item.itemType = 2;
                    break;

            }
            ItemList.Add(item);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            getItemList(ItemList);
        }
    }
}
