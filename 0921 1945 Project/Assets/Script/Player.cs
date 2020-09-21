using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator ani;
    public float moveSpeed = 5;
    public GameObject bullet;
    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); //왼쪽키 오른쪽키 입력시 1의 값 반환
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }

        if (Input.GetAxis("Vertical") >= 0.5f)
        {
            ani.SetBool("up", true);
        }
        else 
        {
            ani.SetBool("up", false);
        }

        // 미사일 발사


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, pos.position, Quaternion.identity);
        }


        transform.Translate(moveX, moveY, 0);

    }
}
