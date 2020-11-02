using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    GameObject Player;
    protected Animator playerAni;
    Rigidbody2D playerRigid;
    [SerializeField]
    protected PlayerStatus playerStatus;
    PlayerStatus pStatus { set { playerStatus = value; } }
    int maxJumpCount;
    int jumpCount;
    bool action = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = this.GetComponent<GameObject>();
        playerAni = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
        maxJumpCount = playerStatus.JumpCount;
        jumpCount = maxJumpCount;
        Debug.Log(playerStatus.PlayerName);
    }
    void Move()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 3f * Time.deltaTime, transform.position.y);
            playerAni.SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 3f * Time.deltaTime, transform.position.y);
            playerAni.SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            playerAni.SetBool("Walk", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && jumpCount != 0)
        {
            jumpCount--;
            playerAni.SetBool("Jump", true);
            playerRigid.velocity = new Vector2(0, 5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Land"))
        {
            jumpCount = maxJumpCount;
            playerAni.SetBool("Jump", false);
        }
    }

    public void ElementAttack()
    {
        switch (playerStatus.PlayerElement)
        {
            case 0:
                playerAni.SetTrigger("Attack");
                
                Debug.Log("땅");
                break;
            case 1:
                playerAni.SetTrigger("Attack");
                Debug.Log("바람");
                break;
            case 2:
                playerAni.SetTrigger("Attack");
                Debug.Log("물");
                break;
            case 3:
                playerAni.SetTrigger("Attack");
                Debug.Log("불");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
