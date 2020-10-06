using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

    }

    public void pHpUp()
    {
        if (Player.GetComponent<PlayerStatus>().pGold >= 100)
        {
            Player.GetComponent<PlayerStatus>().pMaxHp += 50;
            Player.GetComponent<PlayerStatus>().pHp += 50;
            Player.GetComponent<PlayerStatus>().pGold -= 100;
            Player.GetComponent<PlayerStatus>().SetPlayerStatus();
        }
    }

    public void pAtkUp()
    {
        if (Player.GetComponent<PlayerStatus>().pGold >= 100)
        {
            Player.GetComponent<PlayerStatus>().pAtk += 5;
            Player.GetComponent<PlayerStatus>().pGold -= 100;
            Player.GetComponent<PlayerStatus>().SetPlayerStatus();
        }
    }
    
    public void pSpdUp()
    {
        if (Player.GetComponent<PlayerStatus>().pGold >= 100)
        {
            Player.GetComponent<PlayerStatus>().pAtkSp += 3;
            Player.GetComponent<PlayerStatus>().pGold -= 100;
            Player.GetComponent<PlayerStatus>().SetPlayerStatus();
        }
    }
}
