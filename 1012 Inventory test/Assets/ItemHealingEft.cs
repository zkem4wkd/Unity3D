using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemEft/Consumable/Health")]
public class ItemHealingEft : ItemEffect
{
    public int healingPoint = 0;
    public override bool ExecuteRole()
    {
        Debug.Log("Hp Up : " + healingPoint);
        return true;
    }
}
