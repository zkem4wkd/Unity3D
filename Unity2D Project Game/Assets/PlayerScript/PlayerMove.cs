using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Player;
    public Transform Ground;
    public float playerSpeed = 5f;
    public float playerJump = 3f;
    public bool SetJump = false;
    public float playerG;
    //총알 관리 변수
    public GameObject bulletPrefab;
    public GameObject[] bulletNum;
    //게임 내 총알들을 찾아 최대 갯수에 제한을 주거나 객체를 찾음

    public int maxBullet = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletNum = GameObject.FindGameObjectsWithTag("Bullet");

        playerG = Player.position.y - Ground.position.y;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.Translate(Vector2.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
        }



        if (playerG > 0.8f)
        {
            SetJump = true;
        }
        else
        {
            SetJump = false;
        }
        if (SetJump == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            }



        }
        if (Input.GetKeyDown("z") && bulletNum.Length < maxBullet)
        {
            Instantiate(bulletPrefab, new Vector2(Player.position.x,Player.position.y+1),Quaternion.identity);
        }

    }
    }
