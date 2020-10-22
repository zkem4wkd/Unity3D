using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;
using UnityEngine.Tilemaps;
using System.Runtime.ExceptionServices;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tiles;
    public List<GameObject> monsters;
    public List<GameObject> Enemies = new List<GameObject>();
    public int monsterCount;
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
    bool res = false;
    int i;
    Transform tPlayer;
    Transform tMonster;
    // Start is called before the first frame update
    void Start()
    {
        worldCount = 5;
        pTurn = true;
        pCount = 5;
        turnText = GameObject.Find("TurnText").GetComponent<TextMeshProUGUI>();
        wCountText = GameObject.Find("WorldCount").GetComponent<TextMeshProUGUI>();
        pHpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
        pHp = 100;
        eScript = GameObject.FindGameObjectWithTag("Monster").GetComponent<mMoving>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>();
        endBtn = GameObject.Find("EndButton").GetComponent<Button>();
        drill = GameObject.Find("DrillGauge").GetComponent<DrillScript>();
        tPlayer = pScript.GetComponent<Transform>();
        tMonster = eScript.GetComponent<Transform>();
        Respawn();
    }
    void PlayerDamaged()
    {
        pHp -= 10;
    }
    void Respawn()
    {
        if (worldCount % 2 == 0 && res == false && monsterCount < 2)
        {
            int random = Random.Range(0, tiles.Count);
            int mRandom = Random.Range(0, monsters.Count);
            float pDis = Vector2.Distance(tPlayer.position, tiles[random].transform.position);
            float mDis = Vector2.Distance(tMonster.position, tiles[random].transform.position);
            for (int i = 0; i < Enemies.Count; i++)
            {
                float mDis2 = Vector2.Distance(Enemies[i].transform.position, tiles[random].transform.position);
                if (pDis > 1f && mDis > 1f && mDis2 > 1f)
                {
                    monsterCount++;
                    GameObject eClone = Instantiate(monsters[mRandom], new Vector2(tiles[random].transform.position.x - 0.5f, tiles[random].transform.position.y), Quaternion.identity) as GameObject;
                    res = true;
                    break;
                    //Enemies.Add(monsters[mRandom]);
                }
                else
                {
                    Respawn();
                }
            }
        }
        else if (worldCount % 2 == 1)
        {
            res = false;
        }
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
    }

    public void EnemyRandomTurn()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            Enemies[i].GetComponent<mMoving>().myTurn = false;
        }
        int random = Random.Range(0, Enemies.Count);
        Enemies[random].GetComponent<mMoving>().myTurn = true;
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
            endBtn.gameObject.SetActive(false);
            EnemyRandomTurn();
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
        Respawn();
        if (pTurn == true)
        {
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            vCam.Follow = player;
            turnText.text = "Player Turn : " + pCount;
        }
        else if (eTurn == true)
        {
            turnText.text = "Enemy Turn : " + eCount;
            i = 1;
            if (eCount == 0)
            {
                yield return new WaitForSeconds(0.8f);
                pTurn = true;
                eTurn = false;
                pCount = 5;
                vCam.Follow = null;
            endBtn.gameObject.SetActive(true);
                if (i > 0)
                {
                    StartCoroutine(TurnEnd());
                }
            }
        }
    }

}
