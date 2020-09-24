using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neddle2 : MonoBehaviour
{
    GameObject niddle;
    public float dropSpeed = 3f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        //niddle = GameObject.FindGameObjectWithTag("Niddle").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * dropSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
