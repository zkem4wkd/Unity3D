using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject fire;
    Vector3 mousePos;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("Fire", 3f);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

        }else
        {
            Fire();
            Destroy(this.gameObject);
        }
    }

    void Fire()
    {
        GameObject Fire = Instantiate(fire, new Vector2(transform.position.x,transform.position.y + 0.5f), Quaternion.identity);
        Destroy(Fire, 15f);
    }
    private void Update()
    {
        this.transform.Translate(dir.normalized * 8f * Time.deltaTime);
    }
}
