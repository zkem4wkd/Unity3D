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
    public bool myTurn = false;
    SpriteRenderer color;
    float a = 1;
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
        color = this.GetComponent<SpriteRenderer>();
        gManager.Enemies.Add(this.gameObject);
        myTurn = false;
    }
    public void EnemyHit()
    {
        ani.SetBool("Hit", true);
        eHp -= 10;
        StartCoroutine(AniDelay());
        if (eHp <= 0)
        {
            StartCoroutine(DeadEnemy());
        }
    }
    IEnumerator DeadEnemy()
    {
        ani.SetTrigger("Die");
        while (a <= 1f)
        {
            color.color = new Color(255, 255, 255, a);
            a -= 0.2f;
            yield return new WaitForSeconds(0.5f);
            if (a <= 0.1f)
            {
                Destroy(this.gameObject);
                gManager.Enemies.Remove(this.gameObject);
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
        myTurn = false;
        gManager.EnemyRandomTurn();
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
        myTurn = false;
        gManager.EnemyRandomTurn();
    }
    // Update is called once per frame
    void Update()
    {
        if (gManager.eTurn == true && myTurn == true)
        {
            dis = Vector2.Distance(this.transform.position, pPosition.transform.position);
            if (dis < 1f && action == false && gManager.eCount > 0)
            {
                StartCoroutine(EnemyAttack());
            }
            else if (dis > 1f && action == false && gManager.eCount > 0)
            {
                StartCoroutine(DrillAttack());
            }
        }
        hpBar.fillAmount = eHp / 50f;
        if (pPosition.position.x < this.transform.position.x)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
        if(gManager.eTurn == true && myTurn == true)
        {
            gManager.vCam.Follow = this.transform;
        }
    }
}
