using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void lButtonDown()
    {
        transform.Translate(-2, 0, 0);
    }
    public void rButtonDown()
    {
        transform.Translate(2, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    transform.Translate(-2, 0, 0);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    transform.Translate(2, 0, 0);
        //}

        
        
    }

}
