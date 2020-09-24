using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public float cSpeed = 2f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
        this.gameObject.tag = "uCannon";
        Transform player = GameObject.Find("Player").GetComponent<Transform>();
        
    }
    void Start()
    {
        GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * cSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
