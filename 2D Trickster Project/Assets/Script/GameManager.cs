using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    GameObject player;
    public GameObject empty;
    Astar astar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        astar = GameObject.Find("Player").GetComponent<Astar>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
