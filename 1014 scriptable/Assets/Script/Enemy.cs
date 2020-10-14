using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;
    public EnemyData EnemyData { set { enemyData = value; } }
    // Start is called before the first frame update
    
    public void printEnemyinfo()
    {
        Debug.Log("Enemy Name : " + enemyData.EnemyName);
        Debug.Log("Enemy Hp : " + enemyData.EHp);
        Debug.Log("Enemy Atk : " + enemyData.Damage);
        Debug.Log("Enemy Sight Range : " + enemyData.SightRange);
        Debug.Log("Enemy Move Speed : " + enemyData.MoveSpeed);
    }

    private void Start()
    {
        printEnemyinfo();
    }
}
