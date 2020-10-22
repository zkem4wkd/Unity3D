using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AtkButton : MonoBehaviour
{
    private Transform tMonster;
    private Transform tPlayer;
    GameManager gManager;
    MovingScript pScript;
    DrillScript dScript;
    Animator pAni;
    // Start is called before the first frame update
    void Start()
    {
        tMonster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Transform>();
        tPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pAni = tPlayer.gameObject.GetComponent<Animator>();
        dScript = GameObject.Find("DrillGauge").GetComponent<DrillScript>();
    }

    public void Attack()
    {
        if (gManager.pCount > 0 && pScript.action == false)
        {
            pScript.Attack();
        }
        else
        {
            Debug.Log("Nope");
        }
    }
    public void Drill()
    {
        if (gManager.pCount > 0 && pScript.action == false && dScript.drillGauge < 100)
        {
            pScript.Drill();
        }
    }
}
