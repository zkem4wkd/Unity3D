using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class mMoving : MonoBehaviour
{
    Astar astar;
    GameManager gManager;
    Animator ani;
    Animator pAni;
    Transform pPosition;
    float dis;
    bool action = false;
    // Start is called before the first frame update
    void Start()
    {
        astar = GameObject.FindGameObjectWithTag("Monster").GetComponent<Astar>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ani = GetComponent<Animator>();
        pAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void EnemyMoving()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gManager.eCount -= 1;
        }
    }
    public void EnemyHit()
    {
        ani.SetBool("Hit", true);
        gManager.eHp -= 10;
        StartCoroutine(AniDelay());
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
            if (dis < 1f && action == false && gManager.eCount > 0)
            {
                StartCoroutine(EnemyAttack());
            }
        }
    }
}
