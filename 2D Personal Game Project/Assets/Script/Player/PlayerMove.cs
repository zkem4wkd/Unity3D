using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerScript
{
    public int maxJumpCount;
    public int jumpCount;
    public int playerNumber;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        maxJumpCount = playerStatus.JumpCount;
        jumpCount = maxJumpCount;
        playerNumber = playerStatus.PlayerNumber;
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 3f * Time.deltaTime, transform.position.y);
            base.playerAni.SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 3f * Time.deltaTime, transform.position.y);
            base.playerAni.SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            base.playerAni.SetBool("Walk", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0)
        {
            jumpCount--;
            action = true;
            base.playerAni.SetBool("Jump", true);
            playerRigid.velocity = new Vector2(0, 5);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            jumpCount = maxJumpCount;
            base.playerAni.SetBool("Jump", false);
            action = false;
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        Move();
    }
}
