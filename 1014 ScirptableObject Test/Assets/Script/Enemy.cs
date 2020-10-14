using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyScirptableObject enemyData;
    public EnemyScirptableObject EnemyData { set { enemyData = value; } }
    public void printEnemy()
    {
        Debug.Log("Enemy Name : " + enemyData.EnemyName);
        Debug.Log("Enemy Hp : " + enemyData.EHp);
        Debug.Log("Enemy Atk : " + enemyData.EAtk);
        Debug.Log("Enemy Speed : " + enemyData.ESpd);

    }

}
