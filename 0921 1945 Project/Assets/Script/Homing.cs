using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target;
    Vector2 dir; //벡터의 방향을 구할 변수
    Vector2 dirNo; // 벡터의 normarlize 정규화 단위벡터

    // Start is called before the first frame update
    void Start()
    {
        //유도 1단계 한번만 방향구하고 그 방향으로 날라가기
        dir = target.transform.position - transform.position;

        dirNo = dir.normalized; // 방향이 1인 벡터로 만듬
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * 3f * Time.deltaTime);
    }
}
