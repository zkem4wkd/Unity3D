﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadScript : MonoBehaviour
{
    GameManager gManager;
    GameObject loading;
    public GameObject gObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            collision.gameObject.GetComponent<TileScript>().roadOn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            collision.gameObject.GetComponent<TileScript>().roadOn = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TilemapCollider2D>().enabled = false;
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

}
