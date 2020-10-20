using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class mMoving : MonoBehaviour
{
    Astar astar;
    GameManager gManager;
    Animator ani;
    Animator pAni;
    Transform pPosition;
    IEnumerator eMoving;
    float dis;
    bool action = false;
    SpriteRenderer mAlpha;
    float a = 255;
    // Start is called before the first frame update
    void Start()
    {
        astar = GameObject.FindGameObjectWithTag("Monster").GetComponent<Astar>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ani = GetComponent<Animator>();
        pAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        eMoving = EnemyMoving();
        mAlpha = GetComponent<SpriteRenderer>();

    }
    IEnumerator EnemyMoving()
    {
        if(gManager.eTurn == true && gManager.eCount > 0)
        {
            action = true;
            
            for (int i = 0; i < astar.FinalNodeList.Count; i++)
            {
                Vector2 targetPos = new Vector2(astar.FinalNodeList[i].x, astar.FinalNodeList[i].y);
                //this.transform.position = Vector3.MoveTowards(this.transform.position,targetPos , 0.1f * Time.deltaTime); 
                this.transform.position = new Vector2(astar.FinalNodeList[i].x, astar.FinalNodeList[i].y);
                ani.SetBool("Moving", true);
            }
            yield return new WaitForSeconds(2f);
        }
    }
    //IEnumerator rayCoroutine()
    //{
    //    Ray2D ray = new Ray2D(this.transform.position, Vector2.down);
    //    Debug.DrawRay(ray.origin, ray.direction * 1, Color.red);
    //    RaycastHit2D eHit;
    //    eHit = Physics2D.Raycast(new Vector2(transform.position.x + 2, transform.position.y), transform.right, 1, 1);
    //    if (eHit != null && eHit.transform.gameObject.CompareTag("Tile"))
    //    {
    //        Debug.Log(eHit.transform.gameObject.name);
    //    }
    //    yield return null;
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gManager.eTurn == true &&collision.CompareTag("Tile"))
        {
            Debug.Log(collision.gameObject.name);
            this.transform.position = collision.transform.position;
            ani.SetBool("Moving", false);
            gManager.eCount--;
            StartCoroutine(MovingDelay());
        }
    }
    IEnumerator MovingDelay()
    {
        yield return new WaitForSeconds(1f);
        action = false;
        StopCoroutine(eMoving);
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Tile"))
    //    {
    //        collision.enabled = true;
    //    }
    //}
    public void EnemyHit()
    {
        ani.SetBool("Hit", true);
        gManager.eHp -= 10;
        StartCoroutine(AniDelay());
        if(gManager.eHp <= 0)
        {
            ani.SetBool("Die", true);
            StartCoroutine(DeadEnemy());
        }
    }
    IEnumerator DeadEnemy()
    {
        while (mAlpha.color.a >= 1f)
        {
            yield return new WaitForSeconds(0.05f);
            if (mAlpha.color.a <= 0.1f)
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator AniDelay()
    {
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("Hit", false);
    }

    IEnumerator EnemyAttack()
    {
        action = true;
        pPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        yield return new WaitForSeconds(1f);
        ani.SetBool("Attack", true);
        pAni.SetBool("Hit", true);
        yield return new WaitForSeconds(1f);
        ani.SetBool("Attack", false);
        pAni.SetBool("Hit", false);
        gManager.pHp -= 10;
        gManager.eCount--;
        yield return new WaitForSeconds(1.5f);
        action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.eTurn == true)
        {
            dis = Vector2.Distance(this.transform.position, pPosition.transform.position);
            StartCoroutine(EnemyMoving());
            if (dis < 1f && action == false && gManager.eCount > 0)
            {
                StartCoroutine(EnemyAttack());
            }
        }
    }
}
