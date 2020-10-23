﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    NavMeshAgent nav;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.enabled)
        {
            nav.SetDestination(player.position);
        }
    }
}
