using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    GameDirector director;
    public float Speed = 4.0f;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            director = GameObject.Find("GameDirector").GetComponent<GameDirector>();
            director.live = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);


        //if(gameObject.transform.position.y < -8f)
        //{
        //    Destroy(gameObject);
        //}
    }

    //화면에 안보이는 상태일 때 처리할 함수
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
