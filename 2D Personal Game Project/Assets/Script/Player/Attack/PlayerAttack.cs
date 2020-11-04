using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerScript
{
    public GameObject attackObject;
    public GameObject skillObject;
    public bool onAttack = false;
    public bool onSkill = false;
    public virtual void Attack() { }
    public virtual void Skill() { }

}
