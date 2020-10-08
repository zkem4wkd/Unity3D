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

    //미사일 
    public GameObject fire;
    public Transform player;
    float delayTime = 0;

    Animator monAny;
    float angle;
    Vector3 dir;

    //체력
    public Image Monhp;

    float CurrentHp = 50;
    float MonMaxHp = 50;


    // Start is called before the first frame update
    void Start()
    {

        monAny = GetComponent<Animator>();
        mst = GetComponent<SpriteRenderer>();
        origin = mst.color;
        delayTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            mst.color = Color.red;
        }
        else
        {
            mst.color = Color.Lerp(mst.color, origin
                , flashSpeed * Time.deltaTime);
        }

        damaged = false;

        float dis = Vector3.Distance(player.position, transform.position);

        //거리 5이상 벗어나면 파이어를 안씀
        if(dis <5f)
        {
            if(Time.time >= delayTime + 2)
            {
                delayTime = Time.time;

                GameObject gFire = Instantiate(fire,
                    transform.position, Quaternion.identity);
                gFire.GetComponent<fire>().target = player;
            }
        }

        //AngleAnimation();
        Bland();
    }

    void Bland()
    {
        //각도에따른 애니메이션 구현
        dir = player.position - transform.position;
        monAny.SetFloat("x", dir.x);
        monAny.SetFloat("y", dir.y);
    }



    void AngleAnimation()
    {
        //각도에따른 애니메이션 구현
        dir = player.position - transform.position;

        //바라보는 각도구하기
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(angle > -45 && angle <=45) //right
        {
            monAny.SetFloat("x", 1);
            monAny.SetFloat("y", 0);
        }
        else if(angle >45 && angle <=135) //up
        {
            monAny.SetFloat("x", 0);
            monAny.SetFloat("y", 1);
        }
        else if (angle > 135 && angle <= 180 || angle <=-135) //left
        {
            monAny.SetFloat("x", -1);
            monAny.SetFloat("y", 0);
        }
        else if (angle > -135 && angle <= -45) //down
        {
            monAny.SetFloat("x", 0);
            monAny.SetFloat("y", -1);
        }


    }






    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            damaged = true;           
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("충돌");
        if (col.tag == "PlayerSkill")
        {
            damaged = true;
            float Damege = 1;
            if(CurrentHp >0)
            {
                CurrentHp -= Damege;
                Monhp.fillAmount = CurrentHp / MonMaxHp; //50/50
            }
            Destroy(col.gameObject);
        }
    }







}
