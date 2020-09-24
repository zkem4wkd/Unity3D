using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    GameObject thunder;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        thunder = GameObject.FindGameObjectWithTag("Thunder");
        StartCoroutine("dropThunder");
        laser = GameObject.FindGameObjectWithTag("LaserPoint");
    }
    
    IEnumerator dropThunder()
    {
        while (true)
        {
            float thunderX = Random.Range(-5.6f, 1.4f);
            for (int i = 10; i >= 0; i--)
            {
                thunder.transform.position = new Vector3(thunderX, i, 0);
                yield return new WaitForSeconds(0.08f);
            }
            Destroy(thunder.gameObject);
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
    }
}
