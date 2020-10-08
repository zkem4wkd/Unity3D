using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public Transform target;
    public float Speed = 2f;
    Vector3 dir;
    int playerHp;
    Character player;

    float angle;
    Vector3 dirNo;
    // Start is called before the first frame update
    void Start()
    {
        //바라보는 벡터 방향구하기
        dir = target.position - transform.position;
        

        //바라보는 각도구하기 일반적인각도는 0~360 디그리 라디안
        //Mathf.Atan2(dir.y, dir.x) -> 라디안값이 나온다.
        //53.7 ->1(라디안) ->디그리
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //normalized 단위 벡터
        dirNo = new Vector3(dir.x, dir.y, 0).normalized;
        player = GameObject.Find("Player").GetComponent<Character>();

        Destroy(gameObject, 10f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.pHp -= 10;
            //pHp.fillAmount = playerHp * 0.1f;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //회전적용
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        //이동적용
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}
