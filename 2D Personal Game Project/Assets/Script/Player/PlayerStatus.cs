using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Player Data", order = int.MaxValue)]
public class PlayerStatus : ScriptableObject
{
    [SerializeField]
    string playerName;
    public string PlayerName { get { return playerName; } }
    [SerializeField]
    int playerNumber;
    public int PlayerNumber { get { return playerNumber; } }
    [SerializeField]
    int playerElement; // 0 : 땅 , 1 : 바람 , 2 : 물 , 3 : 불 
    public int PlayerElement { get { return playerElement; } }
    [SerializeField]
    int jumpCount;
    public int JumpCount { get { return jumpCount; }}
}
