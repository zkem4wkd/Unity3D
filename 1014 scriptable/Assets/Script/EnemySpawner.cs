using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    bat,orc,turtle,autoBat
}


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyData> enemyDatas;
    [SerializeField]
    private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < enemyDatas.Count; i++)
        {
            var enemy = SpawnEnemy((EnemyType)i);
            enemy.printEnemyinfo();
        }
    }

    public Enemy SpawnEnemy(EnemyType type)
    {
        var newEnemy = Instantiate(enemyPrefab).GetComponent<Enemy>();
        newEnemy.EnemyData = enemyDatas[(int)type];
        return newEnemy;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
