using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;
using UnityEngine.Tilemaps;

public class MovingScript : MonoBehaviour
{
    GameManager gManager;
    mMoving mScript;
    public float speed = 3f;
    Camera camera;
    Vector2 mousePosition;
    Animator ani;
    Transform player;
    Transform tMonster;
    Vector2 pos;
    RaycastHit2D hit;
    bool mBool;
    public bool action = false;
    public GameObject atkBtn;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        player = GetComponent<Transform>();
        tMonster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Transform>();
        mScript = GameObject.FindGameObjectWithTag("Monster").GetComponent<mMoving>();
        mBool = false;
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        atkBtn.SetActive(false);
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
                    if (hit.collider.GetComponent<TileScript>().roadOn == true && dis > 0.5f)
                    {
                        mBool = true;
                    }
                }
            }
        
        if (mBool == true)
        {
            Move();
        }

        float dis1 = Vector2.Distance(this.transform.position, tMonster.transform.position);
        if(gManager.pTurn == true && dis1 < 1f)
        {
            atkBtn.SetActive(true);
        }
        else
        {
            atkBtn.SetActive(false);
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

    public void Attack()
    {
        action = true;
        ani.SetBool("Attack", true);
        gManager.pCount--;
        mScript.EnemyHit();
        StartCoroutine(AniDelay());
    }
    IEnumerator AniDelay()
    {
        yield return new WaitForSeconds(1f);
        ani.SetBool("Attack", false);
        action = false;
    }
}
// Update is called once per frame




