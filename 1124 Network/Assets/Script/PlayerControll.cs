using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerControll : MonoBehaviourPunCallbacks
{
    float h, v, r;
    Transform tr;
    Animator anim;
    public float speed = 10.0f;
    public float rotSpeed = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");

            Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
            tr.Translate(moveDir * speed * Time.deltaTime);

            r = Input.GetAxis("Mouse X");
            tr.Rotate(Vector3.up * Time.deltaTime * r * rotSpeed);

            if(Input.GetMouseButton(0))
            {
                anim.SetTrigger("Attack");
            }

        }
    }
}
