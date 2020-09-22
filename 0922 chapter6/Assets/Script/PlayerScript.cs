using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float Speed = 5f;
    float maxWalk = 2f;
    public float jump = 350f;
    Animator ani;

    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            sprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            sprite.flipX = true;
        }
        //abs = ()안에 절대값을 구함
        float speedX = Mathf.Abs(rigid2D.velocity.x);

        //플레이어의 스피드에 제한을 줌
        if(speedX < maxWalk )
        {
            rigid2D.AddForce(transform.right * key * Speed);
        }
        //움직이는 방향에 따라 스케일 변경
        //if(key != 0)
        //{
        //    transform.localScale = new Vector3(key, 1, 1);
        //}


        if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
        {
            ani.SetTrigger("JMP");
            rigid2D.AddForce(transform.up * this.jump);
        }

        //애니메이션 재생속도 관리
        ani.speed = speedX / 2.0f;

        if(rigid2D.velocity.y == 0)
        {
            ani.speed = speedX;
        }
        else
        {
            ani.speed = 1.0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="flag")
        {
            SceneManager.LoadScene("ClearScene");
            
        }
        

        
    }
}
