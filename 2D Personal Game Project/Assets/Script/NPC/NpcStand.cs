using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStand : MonoBehaviour
{
    Transform player;
    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(transform.position.x < player.transform.position.x)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
