using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform target;
    public float Speed = 2f;
    Vector3 dir;

    float angle;
    Vector3 dirNo;
    // Start is called before the first frame update
    void Start()
    {
        //바라보는 벡터 방향 
        dir = target.position - transform.position;
        //바라보는 각도
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}
