using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class Enemy
{
    public string name { get; set; }
    public int Maxhp { get; set; }
    public int damage { get; set; }
}
public class mMoving : MonoBehaviour
{
    GameManager gManager;
    Animator ani;
    Animator pAni;
    Transform pPosition;
    public Image hpBar;
    float dis;
    public float eHp;
    float maxEHp;
    bool action = false;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        Enemy pineapple = new Enemy();
        pineapple.Maxhp = 50;
        maxEHp = pineapple.Maxhp;
        eHp = maxEHp;
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ani = GetComponent<Animator>();
        pAni = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        color = this.GetComponent<Color>();
        
    }
    public void EnemyHit()
    {
        ani.SetBool("Hit", true);
        eHp -= 10;
        StartCoroutine(AniDelay());
        if(eHp <= 0)
        {
            StartCoroutine(DeadEnemy());
        }
    }
    IEnumerator DeadEnemy()
    {
        float a = 1;
        ani.SetBool("Die", true);
        while (a <= 1f)
        {
            color = new Color(255, 255, 255, a);
            a -= 0.2f;
            ani.SetBool("die", false);
            yield return new WaitForSeconds(0.5f);
            if (a <= 0.1f)
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

    IEnumerator DrillAttack()
    {
        action = true;
        pPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        yield return new WaitForSeconds(1f);
        ani.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
        ani.SetBool("Attack", false);
        gManager.DrillDamaged();
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
            else if(dis > 1f && action == false && gManager.eCount > 0)
            {
                StartCoroutine(DrillAttack());
            }
        }
        hpBar.fillAmount = eHp / 50f;
    }
}
