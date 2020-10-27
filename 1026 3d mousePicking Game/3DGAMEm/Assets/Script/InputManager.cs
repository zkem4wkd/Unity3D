using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void CheckClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //카메라로부터 화면상의 좌표를 관통하는 가상의 선(레이져)
            //생성해서 리턴해주는 함수
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            //레이저와 충돌체와 충돌하면 ,true 값을 리턴하고
            //동시에 레이캐스트 히트 변수에 충돌 대상의 정보를 담아온다.
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.name == "Terrain")
                {
                    //마우스 클릭 지점의 좌표를 플레이어가 전달받은뒤
                    //상태를 이동상태로 바꿈
                    player.transform.position = hit.point;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        CheckClick();
    }
}
