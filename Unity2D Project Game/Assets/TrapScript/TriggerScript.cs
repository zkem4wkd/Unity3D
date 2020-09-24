using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Cannon")
        {
            collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            collision.gameObject.tag = "uCannon";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
