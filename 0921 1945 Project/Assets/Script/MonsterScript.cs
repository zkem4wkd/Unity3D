using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    public float Speed = 3.0f;
    public GameObject Bullet;
    public Transform pos;
    public Transform pos2;
    public float delay = 500f;
    GameDirector director;

    
    // Start is called before the first frame update
    void Start()
    {
        //Invoke 함수이름       초
        Invoke("CreateBullet", delay);
        director = GameObject.Find("GameDirector").GetComponent("GameDirector") as GameDirector;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    
    void CreateBullet()
    {
        Instantiate(Bullet, pos.position, Quaternion.identity);
        Instantiate(Bullet, pos2.position, Quaternion.identity);
        Invoke("CreateBullet", delay);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        director.encount += 1;
    }
}
