using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject monster;
    public float encount = 2f;
    public float StartTime = 1;
    public float SpawnStop = 10;
    PlayerBullet pBullet;
    public GameObject gPlayer;
    Player player;
    public bool live;
    public int Hp = 2;
    public Text text;
    bool swi = true;
  

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RandomSpawn");
        
    }

    IEnumerator RandomSpawn()
    {
        

        while (swi)
        {
            float randomX = Random.Range(-5.6f, 5.6f);
            yield return new WaitForSeconds(StartTime);
            Vector2 r = new Vector2(randomX, transform.position.y);
            Instantiate(monster, r, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //if (Hp > 0)
        //{
        //    if (live == false)
        //    {
        //        Instantiate(gPlayer);
        //        live = true;
        //        Hp--;
        //    }
        //}
        text.text = "Hp : " + Hp;

        if (Hp > 0)
        {
            if (live == false)
            {
                Instantiate(gPlayer);
                live = true;
                Hp--;
            }
        }

        if (Hp < 0)
        {
            Debug.Log("Game Over");
        }

        //float randomX = Random.Range(-5.6f, 5.6f);

        //if (encount <= 2 && encount >= 0)
        //{
        //    Instantiate(monster, new Vector3(randomX, 5.5f, 0), Quaternion.identity);
        //    encount--;
        //}


        //Transform tBullet = pBullet.GetComponent<Transform>();
        //Transform tMonster = monster.GetComponent<Transform>();

        //float vDistance = Vector2.Distance(tBullet.position, tMonster.position);

        //if (vDistance < 1f)
        //{
        //    Destroy(monster.gameObject);
        //    Destroy(pBullet.gameObject);
        //}

    }

}
