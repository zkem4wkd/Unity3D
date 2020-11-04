using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : PlayerAttack
{
    float i = 2;
    float j = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMove>().jumpCount++;
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        if(j < i)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1.2f * Time.deltaTime);
            j += Time.deltaTime;
        }
    }
}
