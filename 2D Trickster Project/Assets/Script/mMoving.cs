using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mMoving : MonoBehaviour
{
    Astar astar;
    // Start is called before the first frame update
    void Start()
    {
        astar = GameObject.FindGameObjectWithTag("Monster").GetComponent<Astar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
