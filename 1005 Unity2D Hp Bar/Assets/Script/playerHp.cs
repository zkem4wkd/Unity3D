using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class playerHp : MonoBehaviour
{
    public float pMaxHp = 10000;
    public float pHp;
    public float pDownHp;
    public Slider pHpBar;

    public Text maxHpCount;
    public Text hpCount;

    // Start is called before the first frame update
    void Start()
    {
        pHp = pMaxHp;
        pHpBar.value = 100;
        hpCount.text = pHp.ToString("N0"); // N0 = 소숫점 표시x
        maxHpCount.text = "/ " + pMaxHp.ToString("N0");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            float damage = Random.Range(500, 1000);
            playerHpDown(damage);
        }
    }

    public void playerHpDown(float damage)
    {
        pDownHp = pHp;

        pHp -= damage;

        StartCoroutine(playerDamage());
    }

    IEnumerator playerDamage()
    {
        for(int a = 0; a < 1000; a++)
        {
            if(pHp < pDownHp)
            {
                pDownHp -= (pDownHp - pHp) / 25;
                pHpBar.value = pDownHp / (pMaxHp / 100);
                hpCount.text = pDownHp.ToString("N0");
            }
            if((pDownHp - pHp)< 1f)
            {
                pDownHp = pHp;
                pHpBar.value = pDownHp / (pMaxHp / 100);
                hpCount.text = pDownHp.ToString("N0");
                if (pDownHp <= 0 )
                {
                    pHp = pMaxHp;
                    pDownHp = pMaxHp;
                    pHpBar.value = pDownHp / (pMaxHp / 100);
                    hpCount.text = pDownHp.ToString("N0");
                }
                break;
            }
            yield return new WaitForSeconds(0.001f);
        }
        StopCoroutine(playerDamage());
    }
    
}
