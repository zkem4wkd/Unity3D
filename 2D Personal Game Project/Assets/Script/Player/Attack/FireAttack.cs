using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttack : PlayerAttack
{
    bool onSkill = false;

    public override void Attack()
    {
        if(onAttack == false)
        {
            onAttack = true;
            playerAni.SetTrigger("Attack");
            StartCoroutine("AttackDelay");
        }
    }
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1.8f);
        onAttack = false;
    }
    public override void Skill()
    {
        if (onSkill == false)
        {
            onSkill = true;
            base.Skill();
            if(tPlayer.localScale.x == 1)
            {
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.transform.position.x + 1, tPlayer.transform.position.y), Quaternion.identity);
                Destroy(skillObj, 2f);
            }
            else
            {
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.transform.position.x - 1, tPlayer.transform.position.y), Quaternion.identity);
                skillObj.transform.localScale = new Vector3(-1, 1, 1);
                Destroy(skillObj, 2f);
            }
            StartCoroutine(SkillDelay());
        }
    }
    IEnumerator SkillDelay()
    {
        yield return new WaitForSeconds(3f);
        onSkill = false;
    }
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Skill();
        }
    }
}
