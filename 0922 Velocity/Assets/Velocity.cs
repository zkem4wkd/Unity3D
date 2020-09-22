using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        //player의  절대속도 설정
        //player.velocity = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        player.AddForce(Vector2.right * 3);
        Debug.Log(player.velocity.x);

        if(player.velocity.x > 2)
        {
            Debug.Log("deceleration");
            player.velocity = new Vector2(2, 0);
        }
    }
}
