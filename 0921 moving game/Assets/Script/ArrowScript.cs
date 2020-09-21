using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f ,0);

        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        float pDistance = Vector2.Distance(p1, p2);
        //Vector2 dir = p1 - p2;
        //float d = dir.magnitude; // 벡터의 길이 반환
        //float r1 = 0.5f; // 화살 반경
        //float r2 = 1.0f; // 플레이어 반경
        
        if(pDistance < 1)
        {
            Destroy(gameObject);
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }
    }
}
