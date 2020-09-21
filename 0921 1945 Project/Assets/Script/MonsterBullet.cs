using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    public float Speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Speed * Time.deltaTime);


        //if(gameObject.transform.position.y < -8f)
        //{
        //    Destroy(gameObject);
        //}
    }

    //화면에 안보이는 상태일 때 처리할 함수
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
