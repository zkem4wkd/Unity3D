using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerScript
{
    public GameObject attackObject;
    public GameObject skillObject;
    protected bool onAttack = false;
    public virtual void Attack() { }
    public virtual void Skill() { }

}
