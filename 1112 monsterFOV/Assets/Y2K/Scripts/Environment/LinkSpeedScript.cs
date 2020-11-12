﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LinkSpeedScript : MonoBehaviour
{

    public NavMeshAgent agent;
    public bool linking;
    public float origSpeed;

    // just change linkspeed to alter off mesh link traverse speed;
    public float linkSpeed;

    void Start()
    {
        origSpeed = agent.speed;
        linking = false;
    }

    void FixedUpdate()
    {
        if (agent.isOnOffMeshLink && linking == false)
        {
            linking = true;
            agent.speed = agent.speed * linkSpeed;
        }
        else if (agent.isOnNavMesh && linking == true)
        {
            linking = false;
            agent.velocity = Vector3.zero;
            agent.speed = origSpeed;
        }
    }
}