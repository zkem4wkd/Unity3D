using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class RouletteScript : MonoBehaviour
{
    float rSpeed = 0;//회전속도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //클릭 시 회전 속도를 설정하는 스크립트
        if(Input.GetMouseButtonDown(0))
        {
            this.rSpeed = 10f;
        }
        //회전 속도만큼 룰렛 회전
        transform.Rotate(0, 0, this.rSpeed);

        //룰렛 감속
        this.rSpeed *= 0.96f;
    }
}
