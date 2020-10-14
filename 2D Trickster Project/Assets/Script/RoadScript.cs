using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Tile")
        {
            collision.gameObject.GetComponent<TileScript>().roadOn = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RoadScript>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
