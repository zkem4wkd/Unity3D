using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;
using UnityEngine.Tilemaps;
using System.Runtime.ExceptionServices;
using System.IO;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tiles;
    public List<GameObject> monsters;
    public List<GameObject> Enemies = new List<GameObject>();
    int monsterCount;
    public int maxMonsterCount;
    DrillScript drill;
    [SerializeField]
    StageSelect stageSelect;
    TextMeshProUGUI turnText;
    TextMeshProUGUI pHpText;
    TextMeshProUGUI pMpText;
    TextMeshProUGUI wCountText;
    public CinemachineVirtualCamera vCam;
    public bool pTurn = false;
    public bool eTurn = false;
    public int pCount;
    public int eCount;
    [SerializeField]
    int worldCount;
    public Image Hp;
    public float pHp;
    public Image Mp;
    public float pMp;
    mMoving eScript;
    MovingScript pScript;
    public GameObject loading;
    Button endBtn;
    bool turnEnd = false;
    bool res = false;
    bool pause = false;
    int i;
    Transform tPlayer;
    Transform tMonster;
    public Image clear;
    public Image failed;
    int StageNumber;
    string path = "";
    public int lDrillGauge;
    DrillGaugeSave dSave;

    // Start is called before the first frame update
    void Start()
    {
        pTurn = true;
        pCount = 5;
        turnText = GameObject.Find("TurnText").GetComponent<TextMeshProUGUI>();
        wCountText = GameObject.Find("WorldCount").GetComponent<TextMeshProUGUI>();
        pHpText = GameObject.Find("Hp").GetComponent<TextMeshProUGUI>();
        pMpText = GameObject.Find("Mp").GetComponent<TextMeshProUGUI>();
        pHp = 100;
        pMp = 100;
        eScript = GameObject.FindGameObjectWithTag("Monster").GetComponent<mMoving>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>();
        endBtn = GameObject.Find("EndButton").GetComponent<Button>();
        drill = GameObject.Find("DrillGauge").GetComponent<DrillScript>();
        tPlayer = pScript.GetComponent<Transform>();
        tMonster = eScript.GetComponent<Transform>();
        Respawn();
        stageSelect = GameObject.Find("StageObject").GetComponent<StageSelect>();
        StageNumber = stageSelect.StageNumber;
        dSave = GetComponent<DrillGaugeSave>();
    }
    void PlayerDamaged()
    {
        pHp -= 10;
        if (pHp == 0)
        {
            Failed();
        }
    }
    void Respawn()
    {
        if (worldCount % 2 == 0 && res == false && monsterCount < maxMonsterCount)
        {
            int random = Random.Range(0, tiles.Count);
            int mRandom = Random.Range(0, monsters.Count);
            float pDis = Vector2.Distance(tPlayer.position, tiles[random].transform.position);
            for (int i = 0; i < Enemies.Count; i++)
            {
                float mDis = Vector2.Distance(Enemies[i].transform.position, tiles[random].transform.position);
                if (pDis > 1f  && mDis > 1f)
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
        if(drill.drillGauge <= 0)
        {
            Time.timeScale = 0;
            failed.gameObject.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        wCountText.text = "World Count : " + worldCount;
        pHpText.text = pHp + "/ 100";
        Hp.fillAmount = pHp / 100f;
        Mp.fillAmount = pMp / 100f;
        pMpText.text = pMp + "/ 100";
        StartCoroutine(ChangeTurn());
        if(pHp == 0)
        {
            Invoke("Failed", 2f);
        }
    }
    public void Clear()
    {
        Time.timeScale = 0;
        clear.gameObject.SetActive(true);
        TextMeshProUGUI cText = clear.GetComponentInChildren<TextMeshProUGUI>();
        cText.text = "채굴률 : " + drill.drillGauge + " % ";
        drill.lDrillGauge[StageNumber] = drill.drillGauge;
    }
    public void GoBack()
    {
        SceneManager.LoadScene("StageSelect");
        Destroy(stageSelect.gameObject);
        Time.timeScale = 1;
        dSave.Save(drill.lDrillGauge, StageNumber);
    }
    public void Failed()
    {
        Time.timeScale = 0;
        failed.gameObject.SetActive(true);
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
        if (pCount >= 0 && pTurn == true && pScript.action == false && worldCount > 0)
        {
            pTurn = false;
            eTurn = true;
            pCount = 0;
            eCount = 3;
            vCam.Follow = null;
            worldCount -= 1;
            EnemyRandomTurn();
            endBtn.gameObject.SetActive(false);
        }
        if(worldCount == 0)
        {
            Clear();
        }
    }
    IEnumerator TurnEnd()
    {
        worldCount -= 1;
        i = 0;
        if(worldCount <= 0)
        {
            Clear();
        }
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
        else if (eTurn == true && worldCount > 0)
        {
            turnText.text = "Enemy Turn : " + eCount;
            i = 1;
            if (eCount == 0)
            {
                yield return new WaitForSeconds(0.2f);
                pTurn = true;
                eTurn = false;
                pCount = 5;
                vCam.Follow = null;
                if (i > 0)
                {
                    StartCoroutine(TurnEnd());
                }
                yield return new WaitForSeconds(0.5f);
                endBtn.gameObject.SetActive(true);
            }
        }
    }

}
