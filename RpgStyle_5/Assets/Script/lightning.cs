using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    Character player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);

        player = GameObject.Find("Player").GetComponent<Character>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.pHp -= 10;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
