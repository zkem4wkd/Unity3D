using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingScript : MonoBehaviour
{
    Animator playerWalking;
    GameObject gameOver;
    public Rigidbody2D player;
    GameObject Ground;
    public int JumpCount;
    public float pSpeed = 5f;
    public int key = 0;
    public GameObject bullet;

    public Transform pos;

    private void OnDisable()
    {
        gameOver.GetComponent<SpriteRenderer>().color = new Vector4(255, 255, 255, 255);
    }
    private void OnEnable()
    {
        Destroy(gameOver.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerWalking = GetComponent<Animator>();
        JumpCount = 0;
        gameOver = GameObject.Find("GameOver");
        
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
            key = 1;
            player.transform.Translate(Vector2.right * pSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            player.transform.Translate(Vector2.left * pSpeed * Time.deltaTime);
        }
        if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }

            if (JumpCount < 2)
            {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.AddForce(Vector2.up * 6f, ForceMode2D.Impulse);
                JumpCount++;
            }
            
        }

        if(Input.GetKeyDown("z") || Input.GetKeyDown("ㅋ"))
        {
            Instantiate(bullet, pos.position, transform.rotation);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        JumpCount = 0;
    }
}
