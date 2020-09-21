using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject monster;
    public float encount = 2f;
    PlayerBullet pBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        

        float randomX = Random.Range(-5.6f, 5.6f);

        if (encount <= 2 && encount >= 0)
        {
            Instantiate(monster, new Vector3(randomX, 5.5f, 0), Quaternion.identity);
            encount--;
        }
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
