using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    public Image text;
    GameManager gManager;
    MovingScript pScript;
    DrillScript drill;
    public AudioClip hp, dCharge;
    AudioSource sound;

    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        drill = GameObject.Find("DrillGauge").GetComponent<DrillScript>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>();
        sound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    public void TextOn()
    {
        text.gameObject.SetActive(true);
    }
    public void TextOff()
    {
        text.gameObject.SetActive(false);
    }
    public void HpCharge()
    {
        if (gManager.pTurn == true && gManager.pCount > 0 && gManager.pHp < 100 && gManager.pMp >= 20 && pScript.action == false)
        {
            gManager.pHp += 20;
            gManager.pMp -= 10;
            sound.clip = hp;
            sound.Play();
            if(gManager.pHp > 100)
            {
                gManager.pHp = 100;
            }
            gManager.pCount--;
        }
    }
    public void DrillCharge()
    {
        if (gManager.pTurn == true && gManager.pCount > 0  && gManager.pMp >= 50 && drill.drillGauge < 100 && pScript.action == false)
        {
            drill.drillGauge += 30;
            sound.clip = dCharge;
            sound.Play();
            if(drill.drillGauge > 100)
            {
                drill.drillGauge = 100;
            }
            gManager.pMp -= 50;
            gManager.pCount--;
        }
    }
}
