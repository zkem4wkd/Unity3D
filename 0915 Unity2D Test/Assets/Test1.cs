using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    //Transform
    public Transform Player;
    public Transform Destination_i;

    public float Distance; // 객체간의 거리를 구할 변수
    public float Speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destination_i = GameObject.Find("Destination").GetComponent<Transform>();

        print("Destination Position = " + Destination_i.position);

        print(Player.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(Player.position, Destination_i.position);

        print(Distance);

        //if (Destination_i.position.x > Player.position.x)
        //{
        //    Player.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        //}
        //if (Destination_i.position.x < Player.position.x)
        //{
        //    Player.transform.position = Destination_i.transform.position;
        //}

        if(Distance >= 0.1f)
        {
            Player.transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        if(Distance < 0.1f)
        {
            Player.transform.position = Destination_i.transform.position;
        }


        //Vector2.right = (1,0)
        
    }
}
