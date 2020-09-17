using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float enemySpeed = 10f;

    Transform enemyObject;

    PlayerMove playermove; //총알의 정보를 받음

    EnemyManager enemyMgr;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyObject = gameObject.GetComponent<Transform>();

        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();

        enemyMgr = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyObject.transform.Translate(Vector2.down * enemySpeed * Time.deltaTime);

        if(enemyObject.position.y <= -5f)
        {
            Destroy(gameObject);
        }

        for (int a = 0; a < playermove.bulletNum.Length; a++)
        {
            for(int b=  0; b<enemyMgr.enemyNum.Length; b++)
            {
                float distance = Vector2.Distance(playermove.bulletNum[a].transform.position,enemyMgr.enemyNum[b].transform.position);

                if(distance <= 0.5f)
                {
                    Destroy(playermove.bulletNum[a]);
                    Destroy(enemyMgr.enemyNum[b]);
                }
            }
        }


    }
}
