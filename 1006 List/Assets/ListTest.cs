using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    public int lv;
    public int hp;
    public float mp;
    // Start is called before the first frame update
    void Start()
    {
        List<int> num = new List<int>();
        num.Add(1);
        num.Add(2);
        num.Add(3);

        //for(int i = 0; i < num.Count; i ++)
        //{
        //    print(num[i]); 
        //}

        //if(num.Contains(1))
        //{
        //    Debug.Log("true");
        //}

        //num.Reverse();

        //num.Clear();

        List<string> name = new List<string>();

        name.Add("K");
        name.Add("L");
        name.Add("P");

        //if (name.Contains("K")) 
        //{
        //    Debug.Log("True");
        //}
        //else
        //{
        //    Debug.Log("False");
        //}


        //Dictionary<int, float> key = new Dictionary<int, float>();

        //key.Add(5, 10.5f);
        //key.Add(10, 23.4f);
        //Debug.Log(key[5]);
        //Debug.Log(key[10]);

        //key.Remove(5);
        //if(key.ContainsKey(5))
        //{
        //    Debug.Log("true");
        //}
        //else
        //{
        //    Debug.Log("false");
        //}

        //if(key.ContainsValue(23.4f))
        //{
        //    Debug.Log("true");
        //}
        //else
        //{
        //    Debug.Log("false");
        //}

        //Dictionary<string, int> item = new Dictionary<string, int>();
        //item.Add("Sword", 1);
        //item.Add("Gun", 2);
        //item.Add("knife", 3);

        //if(item.ContainsKey("Sword"))
        //{
        //    Debug.Log("I have Sword");
        //}
        //else
        //{
        //    Debug.Log("I don't have Sword");
        //}
        //if(item.ContainsValue(2))
        //{
        //    Debug.Log("I have Gun");
        //}
        //else
        //{
        //    Debug.Log("I don't have Gun");
        //}

        List<int> mList = new List<int>();

        mList.Add(TestMethod(1,50,20));
        mList.Add(TestMethod(2,70,30));



    }
    public int TestMethod(int a , int b, float c)
    {
        lv = a;
        hp = b;
        mp = c;
        print("Lv = " + lv + "Hp = " + hp + "Mp = " + mp);

        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
