using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Transform playerPosition;
    Transform bulletPosition;
    WalkingScript key;
    public float bulletSpeed = 10f;
    WalkingScript pos;
    GameObject director;

    Vector2 startPosition; // 총알이 생성되었을 때의 최초 위치값
    Vector2 dir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Boss")
        {
            director.GetComponent<GameDirector>().HpDecrease();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Player").GetComponent<WalkingScript>();
        pos = GameObject.Find("pos").GetComponent<WalkingScript>();

        playerPosition = GameObject.Find("Player").GetComponent<Transform>();

        bulletPosition = gameObject.GetComponent<Transform>();

        bulletPosition.transform.position = playerPosition.position;

        startPosition = playerPosition.position;

        GetComponent<Rigidbody2D>().velocity = new Vector2(key.key*bulletSpeed, 0);

        director = GameObject.Find("GameDirector");


    }
    

    // Update is called once per frame
    void Update()
    {
        if (startPosition.x + 5f < bulletPosition.position.x || startPosition.x -5f > bulletPosition.position.x)
        {
            Destroy(gameObject);
        }
    }
}
