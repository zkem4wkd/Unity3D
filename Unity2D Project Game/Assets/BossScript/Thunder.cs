using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    GameObject thunder;
    public GameObject laser;
    Transform tLaser;
    // Start is called before the first frame update
    void Start()
    {
        thunder = GameObject.FindGameObjectWithTag("Thunder");
        StartCoroutine("dropThunder");
        laser = GameObject.FindGameObjectWithTag("LaserPoint");
        tLaser = laser.GetComponent<Transform>();
        tLaser.transform.rotation = Quaternion.Euler(0, 0, 14.6f);
    }
    
    IEnumerator dropThunder()
    {
        while (true)
        {
            float thunderX = Random.Range(-5.6f, 1.4f);
            Instantiate(laser.gameObject, new Vector3(thunderX, 0, 0), Quaternion.identity);
            for (int i = 10; i >= -2; i--)
            {
                if(i == 9)
                {
                    Destroy(laser.gameObject);
                }
                thunder.transform.position = new Vector3(thunderX, i, 0);
                if(i == -2)
                {
                    Destroy(thunder.gameObject);
                }
                yield return new WaitForSeconds(0.08f);
            }
            yield return new WaitForSeconds(1.5f);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name == "Ground Collider")
        {
            Destroy(gameObject);
        }
    }
}
