using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    bool damaged = false;
    SpriteRenderer mst;
    public float flashSpeed = 1f;
    Color origin;
    public GameObject fire;
    public Transform player;
    float delayTime;

    public Animator monAny;
    float angle;
    Vector2 dir;

    public Image monHp;
    float currentHp = 50;
    float monmaxHp = 50;
    // Start is called before the first frame update
    void Start()
    {
        mst = GetComponent<SpriteRenderer>();
        monAny = GetComponent<Animator>();
        origin = mst.color;
        delayTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged == true)
        {
            mst.color = Color.red;
        }
        else
        {
            mst.color = Color.Lerp(mst.color ,origin,flashSpeed * Time.deltaTime);
        }
        
        damaged = false;

        float dis = Vector3.Distance(player.position, transform.position);

        if(dis < 5f)
        {
            if(Time.time >= delayTime + 2)
            {
                delayTime = Time.time;

                GameObject gFire = Instantiate(fire, transform.position,Quaternion.identity);
                gFire.GetComponent<Fire>().target = player;
            }

        }
        //if (player.position.y < transform.position.y - 0.5f)
        //{
        //    monAny.SetFloat("y", -1);
        //    monAny.SetFloat("x", 0);
        //}
        //else if (player.position.x < transform.position.x && player.position.y < transform.position.y + 0.3f)
        //{
        //    monAny.SetFloat("x", -1);
        //    monAny.SetFloat("y", 0);
        //}
        //else if (player.position.x > transform.position.x && player.position.y < transform.position.y + 0.3f)
        //{
        //    monAny.SetFloat("x", 1);
        //    monAny.SetFloat("y", 0);
        //}
        //else if (player.position.y > transform.position.y + 0.5f)
        //{
        //    monAny.SetFloat("y", 1);
        //    monAny.SetFloat("x", 0);
        //}
        Bland();


    }

    void Bland()
    {
        dir = player.position - transform.position;
        monAny.SetFloat("x", dir.x);
        monAny.SetFloat("y", dir.y);
    }
    void AngleAnimation()
    {
        dir = player.position - transform.position;

        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(angle > -45 && angle <= 45)
        {
            monAny.SetFloat("x", 1);
            monAny.SetFloat("y", 0);
        }
        else if (angle > 45 && angle <= 135)
        {
            monAny.SetFloat("x", 0);
            monAny.SetFloat("y", 1);
        }
        else if (angle > 135 && angle <= 180 || angle <=-135)
        {
            monAny.SetFloat("x", -1);
            monAny.SetFloat("y", 0);
        }
        else if (angle > -135 && angle <= -45)
        {
            monAny.SetFloat("x", 0);
            monAny.SetFloat("y", -1);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            damaged = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerSkill")
        {
            damaged = true;
            float Damage = 1;
            if(currentHp > 0)
            {
                currentHp -= Damage;
                monHp.fillAmount = currentHp / monmaxHp;
            }
            Destroy(collision.gameObject);
        }
    }
}
