using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class MovingScript : MonoBehaviour
{
    public float speed = 3f;
    Camera camera;
    Vector2 mousePosition;
    Animator ani;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        player = GetComponent<Transform>();
    }

    //private void playerMove()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        ani.SetBool("Moving", true);
    //        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
    //        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), mousePosition, speed * Time.deltaTime);
    //        if (mousePosition.x > transform.position.x)
    //        {
    //            player.localScale = new Vector3(-3, 3, 1);
    //        }
    //        else
    //        {
    //            player.localScale = new Vector3(3, 3, 1);
    //        }
    //    }
    //    else
    //    {
    //        ani.SetBool("Moving", false);
    //    }
    //}
    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            if (hit.collider.GetComponent<TileScript>().roadOn == true)
            {
                player.transform.position = hit.collider.transform.position;
            }
    }
}
}
// Update is called once per frame




