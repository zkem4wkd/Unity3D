using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    //싱글톤 디자인패턴 
    //싱글톤 하나의 객체만 가질수 있고
    //다른 클래스에서 쉽게 참조해서 가져다 쓸수있다.
    public static ItemDatabase instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public List<Item> itemDB = new List<Item>();

    public GameObject fieldItemPrefab;

    public void ItemDrop(Vector3 pos)
    {
        GameObject go = Instantiate(fieldItemPrefab,
            pos, Quaternion.identity);

        go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
