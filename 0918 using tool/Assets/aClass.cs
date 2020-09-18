using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aClass : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject enemy;

    //public Sprite jewel; // 유니티에서 직접 스프라이트 삽입

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        //sr.sprite = jewel;

        Debug.Log(enemy.GetComponent<EnemyScript>().Attack);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.right * 2 * Time.deltaTime);
    }
}
