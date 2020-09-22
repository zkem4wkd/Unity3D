using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
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
