using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public Slider playerHpBar;

    public int maxPlayerHp = 10000;
    public int playerHp;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = maxPlayerHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(playerHp > 0)
            {
                playerHp -= 250;
                playerHpBar.value = playerHp / (maxPlayerHp / 100);
            }
            if(playerHp <= 0)
            {
                playerHp = 10000;
                playerHpBar.value = playerHp / (maxPlayerHp / 100);
            }
        }
    }
}
