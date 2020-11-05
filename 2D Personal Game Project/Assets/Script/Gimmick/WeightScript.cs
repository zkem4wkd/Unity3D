using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightScript : MonoBehaviour
{
    [SerializeField]
    public WeightStatus pWeight;
    public int weight;
    private void Start()
    {
        weight = pWeight.Weight;
    }
}
