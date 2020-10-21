using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    protected Animator avatar;
    // Start is called before the first frame update
    void Start()
    {
        avatar = GetComponent<Animator>();
    }
    float h, v;
    public void OnStickChanged(Vector2 stickPos)
    {
        h = stickPos.x;
        v = stickPos.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(avatar)
        {
            avatar.SetFloat("Speed", (h * h + v * v));
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if(rigidbody)
            {
                if(h != 0f && v!= 0f)
                {
                    transform.rotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
                }
            }
        }
    }
}
