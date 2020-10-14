using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType{ dog,cat,bird }

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<EnemyScirptableObject> enemyDatas;
    [SerializeField]
    private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<enemyDatas.Count;i++)
        {
            var enemy = SpawnEnemy((EnemyType)i);
            enemy.printEnemy();
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
