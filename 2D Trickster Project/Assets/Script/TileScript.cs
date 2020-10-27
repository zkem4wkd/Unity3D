using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileScript : MonoBehaviour
{
    GameObject player;
    GameManager gManager;
    GameObject loading;
    public bool roadOn = false;
    bool delay = true;
    Tilemap tile;
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
            if (roadOn == true && gManager.pTurn == true)
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
        if (gManager.pTurn == true)
        {
            tile.color = new Color(255, 255, 255);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        loading = GameObject.Find("GameManager").GetComponent<GameManager>().loading;
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.pTurn == true && roadOn == true && delay == true)
        {
            StartCoroutine(TilePoint());
        }
        else
        {
            StopCoroutine(TilePoint());
        }
    }
    IEnumerator TilePoint()
    {
        delay = false;
        GameObject gObject = (GameObject)Instantiate(loading, this.transform.position, quaternion.identity);
        gObject.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        Destroy(gObject, 1f);
        yield return new WaitForSeconds(1f);
        delay = true;
    }
}
