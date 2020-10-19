using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    TextMeshProUGUI turnText;
    TextMeshProUGUI pHpText;
    public CinemachineVirtualCamera vCam;
    public bool pTurn = false;
    public bool eTurn = false;
    public int pCount;
    public int eCount;
    public Image Hp;
    public float pHp;
    public float eHp;
    public GameObject loading;
    // Start is called before the first frame update
    void Start()
    {
        pTurn = true;
        pCount = 3;
        turnText = GameObject.Find("TurnText").GetComponent<TextMeshProUGUI>();
        pHpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
        pHp = 100;
        eHp = 100;
    }
    void PlayerDamaged()
    {
        pHp -= 10;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerDamaged();
        }
        StartCoroutine(ChangeTurn());
    }
    IEnumerator ChangeTurn()
    {
        if (pTurn == true)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            vCam.Follow = player;
            turnText.text = "Player Turn : " + pCount;
            pHpText.text = pHp + "/ 100";
            Hp.fillAmount = pHp / 100f;
            if (pCount == 0)
            {
                yield return new WaitForSeconds(2f);
                pTurn = false;
                eTurn = true;
                eCount = 3;
                vCam.Follow = null;
            }
        }
        else if (eTurn == true)
        {
            Transform monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Transform>();
            vCam.Follow = monster;
            turnText.text = "Enemy Turn : " + eCount;
            if (eCount == 0)
            {
                yield return new WaitForSeconds(2f);
                pTurn = true;
                eTurn = false;
                pCount = 3;
                vCam.Follow = null;
            }
        }
    }
}
