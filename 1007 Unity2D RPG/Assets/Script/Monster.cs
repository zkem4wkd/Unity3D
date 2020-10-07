using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    bool damaged = false;
    SpriteRenderer mst;
    public float flashSpeed = 1f;
    Color origin;
    public GameObject fire;
    public Transform player;
    float delayTime;

    Animator monAny;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        mst = GetComponent<SpriteRenderer>();
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Player")
        {
            damaged = true;
            Debug.Log("crush");
        }
    }
}
