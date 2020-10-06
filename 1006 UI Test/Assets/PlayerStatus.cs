using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float pHp;
    public float pMaxHp = 1000f;
    public float pAtk = 50;
    public float pAtkSp = 1;
    public int pGold = 0;
    public TextMeshProUGUI pHpText;
    public TextMeshProUGUI pMaxHpText;
    public TextMeshProUGUI pAtkText;
    public TextMeshProUGUI pSpdText;
    public TextMeshProUGUI pGoldText;
    // Start is called before the first frame update
    void Start()
    {
        pHp = pMaxHp;
        SetPlayerStatus();
        StartCoroutine(SetGold());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SetGold()
    {
        for (int a = 0; a < 100; a++)
        {
            pGold += 50;
            pGoldText.text = "Gold : " + pGold.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    public void SetPlayerStatus()
    {
        pHpText.text = pHp.ToString("N0");
        pMaxHpText.text = "/ " + pMaxHp.ToString("N0");
        pAtkText.text = "ATK : " + pAtk.ToString("N0");
        pSpdText.text = "SPD : " + pAtkSp.ToString("N0");

        pGoldText.text = "Gold : " + pGold.ToString();
        pGoldText.faceColor = Color.yellow;
        pGoldText.outlineColor = Color.green;
        pGoldText.outlineWidth = 0.1f;
    }
}
