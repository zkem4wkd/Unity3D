using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    GameObject monster;
    public float Speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster");
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Speed * Time.deltaTime);


        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }


    }
}
