using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class MovingScript : MonoBehaviour
{
    GameManager gManager;
    public float speed = 3f;
    Camera camera;
    Vector2 mousePosition;
    Animator ani;
    Transform player;
    Vector2 pos;
    RaycastHit2D hit;
    bool mBool;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        player = GetComponent<Transform>();
        mBool = false;
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            if (mBool == false && gManager.pTurn == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    hit = Physics2D.Raycast(pos, Vector2.zero);
                    float dis = Vector2.Distance(player.transform.position, hit.collider.transform.position);
                    if (hit.collider.GetComponent<TileScript>().roadOn == true && dis > 0.1f)
                    {
                        mBool = true;
                    }
                }
            }
        
        if (mBool == true)
        {
            Move();
        }
    }
    void Move()
    {
      this.transform.position = Vector3.MoveTowards(player.transform.position, hit.collider.transform.position, speed * Time.deltaTime);
      ani.SetBool("Moving", true);
      if (hit.collider.transform.position.x > transform.position.x)
      {
          player.localScale = new Vector3(-3, 3, 1);
      }
      else
      {
          player.localScale = new Vector3(3, 3, 1);
        }
        float dis = Vector2.Distance(player.transform.position, hit.collider.transform.position);
        if (dis < 0.1f)
        {
            ani.SetBool("Moving", false);
            mBool = false;
            gManager.pCount--;
        }
    }
}
// Update is called once per frame




