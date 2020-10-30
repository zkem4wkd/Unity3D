﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = player.position - transform.position;
    }
    //카메라 가 플레이어 움직임에 한템포 늦게 움직임을 준다.
    private void LateUpdate()
    {
        //플레이어의 위치와 카메라의 위치를 최초 저장한 위치 
        //차이만큼 자동으로 유지시켜주게 됨
        transform.position = player.position - offset;
    }
}
