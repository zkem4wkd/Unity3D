using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    public float jumpForce;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetBool("On", true);
            if (collision.gameObject.GetComponent<PlayerMove>().jumpCount != collision.gameObject.GetComponent<PlayerMove>().maxJumpCount)
            {
                this.GetComponent<Animator>().SetTrigger("Go");
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<Animator>().SetBool("On", false);
        }
    }
}
