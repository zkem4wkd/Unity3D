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
    public GameObject[] tiles;
    DrillScript drill;
    TextMeshProUGUI turnText;
    TextMeshProUGUI pHpText;
    TextMeshProUGUI wCountText;
    public CinemachineVirtualCamera vCam;
    public bool pTurn = false;
    public bool eTurn = false;
    public int pCount;
    public int eCount;
    int worldCount;
    public Image Hp;
    public float pHp;
    mMoving eScript;
    MovingScript pScript;
    public GameObject loading;
    Button endBtn;
    bool turnEnd = false;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        worldCount = 5;
        pTurn = true;
        pCount = 3;
        turnText = GameObject.Find("TurnText").GetComponent<TextMeshProUGUI>();
        wCountText = GameObject.Find("WorldCount").GetComponent<TextMeshProUGUI>();
        pHpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
        pHp = 100;
        eScript = GameObject.FindGameObjectWithTag("Monster").GetComponent<mMoving>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>();
        endBtn = GameObject.Find("EndButton").GetComponent<Button>();
        drill = GameObject.Find("DrillGauge").GetComponent<DrillScript>();
    }
    void PlayerDamaged()
    {
        pHp -= 10;
    }
    public void DrillDamaged()
    {
        drill.drillGauge -= 10;
    }
    // Update is called once per frame
    void Update()
    {
        wCountText.text = "World Count : " + worldCount;
        pHpText.text = pHp + "/ 100";
        Hp.fillAmount = pHp / 100f;
        StartCoroutine(ChangeTurn());
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }
    public void EndTurn()
    {
            if (pCount >= 0 && pTurn == true && pScript.action == false)
            {
                pTurn = false;
                eTurn = true;
                pCount = 0;
                eCount = 3;
                vCam.Follow = null;
                worldCount -= 1;
            }
        
        }
    IEnumerator TurnEnd()
    {
        worldCount -= 1;
        i = 0;
        yield return null;
    }
        IEnumerator ChangeTurn()
        {
            if(pTurn == true)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            vCam.Follow = player;
            turnText.text = "Player Turn : " + pCount;
        }
            else if (eTurn == true)
            {
                Transform monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Transform>();
                vCam.Follow = monster;
                turnText.text = "Enemy Turn : " + eCount;
            i = 1;
                if (eCount == 0)
                {
                    yield return new WaitForSeconds(2f);
                    pTurn = true;
                    eTurn = false;
                    pCount = 3;
                    vCam.Follow = null;
                if (i > 0)
                {
                    StartCoroutine(TurnEnd());
                }
            }
            }
        }

}
