using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    WalkingScript jumpcount;
    Rigidbody2D player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            player.velocity = new Vector2(0,5);
            jumpcount.JumpCount = 1;
            this.transform.Translate(new Vector2(-100, 0));
            StartCoroutine("delay");
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(3f);
        this.transform.Translate(new Vector2(+100, 0));
        StopCoroutine("delay");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        jumpcount = GameObject.Find("Player").GetComponent<WalkingScript>();
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
