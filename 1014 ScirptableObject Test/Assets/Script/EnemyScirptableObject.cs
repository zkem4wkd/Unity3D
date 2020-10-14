using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data",menuName ="Scriptable Object/Enemy Data",order =int.MaxValue)]
public class EnemyScirptableObject : ScriptableObject
{
   [SerializeField]
   private string enemyName;
    public string EnemyName { get { return enemyName; } set { enemyName = value; } }
    [SerializeField]
    private string eHp;
    public string EHp { get { return eHp; } set { eHp = value; } }
    [SerializeField]
    private string eAtk;
    public string EAtk { get { return eAtk; } set { eAtk = value; } }
    [SerializeField]
    private string eSpd;
    public string ESpd { get { return eSpd; } }
}
