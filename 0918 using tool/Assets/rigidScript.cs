using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidScript : MonoBehaviour
{
    Rigidbody2D rg;

    public Vector2 v2;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();

        v2 = new Vector2(1,0);
       
        rg.AddForce(v2 * 10,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
