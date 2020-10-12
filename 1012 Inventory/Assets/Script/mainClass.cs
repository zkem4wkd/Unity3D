using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;

class Enemy
{
    public int level { set; get; }
    public string name { set; get; }
    public float atk { set; get; }
    public float spd { set; get; }
}
public class mainClass : MonoBehaviour
{
    private void Start()
    {
        Enemy slime = new Enemy();

        slime.level = 1;
        slime.name = "Slime";
        slime.atk = 5;
        slime.spd = 0.1f;

        Debug.Log(slime.level);
    }

    
}


