using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform playerPosition;
    Transform bulletPosition;

    public float bulletSpeed = 10f;

    Vector2 startPosition; // 총알이 생성되었을 때의 최초 위치값
    // Start is called before the first frame update
    void Start()
    {
        bulletPosition = gameObject.GetComponent<Transform>();

        bulletPosition.transform.position = playerPosition.position;

        startPosition = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        bulletPosition.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        if(startPosition.y + 10f < bulletPosition.position.y)
        {
            Destroy(gameObject);
        }
    }
}
