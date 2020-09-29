using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    public int pLevel;
    public int pHp;
    public float pMp;
    // Start is called before the first frame update
    void Start()
    {
        List<int> list = new List<int>();
        //list.Add(1);
        //list.Add(2);
        //list.Add(3);

        //list.Reverse(); // 요소들의 순서를 반대로 뒤집음
        //list.Clear(); //배열안에 있는 모든 값을 지움

        //for (int a = 0; a < list.Count; a++)
        //{
        //    print(list[a]);
        //}
        //if (list.Contains(2))
        //{
        //    print("222");
        //}
        //else
        //{
        //    print("?");
        //}

        //List<string> sList = new List<string>();



        //sList.Add("하루");
        //sList.Add("이틀");

        //print(sList[0]);
        //print(sList[1]);

        //if(sList.Contains("하루"))
        //{
        //    print("One");
        //}
        //else
        //{
        //    print("nothing");
        //}
        //Dictionary<int, float> dict = new Dictionary<int, float>();

        //dict.Add(3, 5.1f);
        //dict.Add(9, 20.5f);
        //dict.Remove(3); // 입력된 key값과 values값 모두 삭제

        //print(dict[3]);

        var Dict = new List<float>();
        Dict.Add(testMethod(1,50,30));
        Dict.Add(testMethod(2,70,35));

        var Var = 10;
        var Var2 = "name";
        var Var3 = 3.3;

        print(Var);
        print(Var2);
        print(Var3);

        Var = new int();
        Var3 = new float();
        Var2 = null;

    }
    public float testMethod(int a , int b, float c)
    {
        pLevel = a;
        pHp = b;
        pMp = c;

        print("Lv : " + pLevel + " Hp : " + pHp + "Mp : " + pMp);

        return 0;
    }
}
