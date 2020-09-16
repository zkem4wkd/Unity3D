using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public float pSpeed = 15f;

    //[SerializeField]//인스펙터에 표시해주는 필드
    //private float mSpeed = 3f;
    //protected float eSpeed = 4;


    //public Transform Player; // 인스펙터에 직접 받는 방법
    Transform Player;

    float AngleMax = 60f;
    // Start is called before the first frame update
    void Start()
    {
        //Player = gameObject.GetComponent<Transform>();
        //Player = GameObject.Find("Player").GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("pPlayer").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //오브젝트 회전
        //Rotate() = vector값을 사용하여 단순한 회전값을 줄때 사용하는 친구
        //rotation = Quaternion 값을 사용하며 , 원하는 회전값을 대입해서 회전을 시킬수가 있다.

        //Player.transform.Rotate(0,45,0);

        float HorizonR = Input.GetAxis("Horizontal") * AngleMax;
        float VerticalR = Input.GetAxis("Vertical") * AngleMax;

        Quaternion Destination = Quaternion.Euler(VerticalR,HorizonR,0);
        //Euler(x,y,z) x,y,z축을 기준으로 x,y,z만큼 회전 할 값을 반환

        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation,Destination,pSpeed*Time.deltaTime);
        //Quaternion.Slerp(start,end,speed)
        //start = 플레이어 현재 로테이션 값을 시작점으로 받고
        //end = 쿼터니언 형태로 입력받은 최종 목적지를 설정
        //speed = start 부터 end 까지 speed의 속도로 회전








        //if(Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Player.transform.Translate(Vector2.left*pSpeed*Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    Player.transform.Translate(Vector2.right * pSpeed * Time.deltaTime);
        //}

        //float Horizon = Input.GetAxis("Horizontal");
        //float Vertical = Input.GetAxis("Vertical");
        ////왼쪽 화살표 = -1 반환
        ////오른쪽 화살표 = -1 반환
        //Player.transform.Translate(Vector2.right * Horizon * pSpeed * Time.deltaTime);
        //Player.transform.Translate(Vector2.up * Vertical * pSpeed * Time.deltaTime);




        //Player.transform.Translate(Vector2.right*pSpeed*Time.deltaTime);



    }
}
