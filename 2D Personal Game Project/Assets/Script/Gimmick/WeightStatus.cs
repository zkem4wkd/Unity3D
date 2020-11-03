using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Object/Weight Data", order = int.MaxValue)]
public class WeightStatus : ScriptableObject
{
    [SerializeField]
    int weight;
    public int Weight { get { return weight; } }
    
}