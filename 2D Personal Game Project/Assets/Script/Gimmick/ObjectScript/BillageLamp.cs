using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BillageLamp : MonoBehaviour
{
    public GameObject lights;
    GameController gC;
    // Start is called before the first frame update
    void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gC.Am == false)
        {
            lights.SetActive(true);
        }
        else
        {
            lights.SetActive(false);   
        }
    }
}
