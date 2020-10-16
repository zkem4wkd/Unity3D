using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDamage : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(explosion,transform.position,Quaternion.identity);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,3.0f);
        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
