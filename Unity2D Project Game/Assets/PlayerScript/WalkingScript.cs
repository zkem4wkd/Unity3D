using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    Animator playerWalking;
    public Rigidbody2D player;
    GameObject Ground;
    public int JumpCount;
    public float pSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerWalking = GetComponent<Animator>();
        JumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ground = GameObject.FindGameObjectWithTag("Ground");
        
        //playerWalking.SetBool("walking", false);

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    playerWalking.SetBool("wal+king", true);
        //}
        //else if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    playerWalking.SetBool("walking", true);
        //}
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Translate(Vector2.right * pSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Translate(Vector2.left * pSpeed * Time.deltaTime);
        }
        if (JumpCount < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
                JumpCount++;
            }
            
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        JumpCount = 0;
    }
}
