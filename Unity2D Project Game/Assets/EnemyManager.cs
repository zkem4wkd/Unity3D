using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float enemyX;
    public float enemyY = 6.5f;

    public GameObject[] enemyNum;

    public GameObject enemyPrefab;

    public int enemyMax = 5;
    // 젠 속도
    public float enemyJen = 1f;
    //업데이트문을 잡아줄 bool 타입 변수
    public bool instantSet = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyNum = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyNum.Length < enemyMax && instantSet == true)
        {
            enemyX = Random.Range(-5.7f, 5.7f);
            Instantiate(enemyPrefab, new Vector2(enemyX, enemyY), Quaternion.identity);
            instantSet = false;
            StartCoroutine("timeSet");
        }
        
    }
    //코루틴
    IEnumerator timeSet()
    {
        yield return new WaitForSeconds(enemyJen);
        instantSet = true;
        StopCoroutine("timeSet");
    }
    
}

