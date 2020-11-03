using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//빌보드는 카메라를 바라보게 한다.
public class Billbord : MonoBehaviour
{
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //항상 카메라를 정면으로 바라볼 수 있도록 로테이션 값이 조정되게 함
        transform.LookAt(transform.position
            + cam.rotation * Vector3.forward, cam.rotation * Vector3.up);
    }
}
