using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : MonoBehaviour
{
    GameObject player;
    public bool roadOn = false;
    public Tilemap tile;
    public TilemapCollider2D[] roads = new TilemapCollider2D[5];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].enabled = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].enabled = false;
            }
        }
    }


    private void OnMouseOver()
    {
        if (roadOn == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue, 3.5f);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Vector3.zero);


            if (this.tile = hit.transform.GetComponent<Tilemap>())
            {
                this.tile.RefreshAllTiles();
                int x, y;
                x = this.tile.WorldToCell(ray.origin).x;
                y = this.tile.WorldToCell(ray.origin).y;
                Vector3Int v3int = new Vector3Int(x, y, 0);

                this.tile.SetTileFlags(v3int, TileFlags.None);
                //this.tile.SetColor(v3int, new Color(255,0,0));
                tile.color = new Color(255, 0, 0);
            }
        }
    }
    private void OnMouseExit()
    {
        tile.color = new Color(255, 255, 255);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
