using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAttack : PlayerAttack
{
    public override void Attack()
    {
        if (onAttack == false)
        {
            onAttack = true;
            playerAni.SetTrigger("Attack");
            if(tPlayer.localScale.x == 1)
            {
                GameObject attackObj = Instantiate(attackObject, new Vector2(tPlayer.transform.position.x-0.5f, tPlayer.transform.position.y), Quaternion.identity);
                Destroy(attackObj, 1.5f);
            }
            else
            {
                GameObject attackObj = Instantiate(attackObject, new Vector2(tPlayer.transform.position.x + 0.5f, tPlayer.transform.position.y), Quaternion.identity);
                Destroy(attackObj, 1.5f);
            }
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
            playerAni.SetTrigger("Attack");
            base.Skill();
            if (tPlayer.localScale.x == 1)
            {
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.transform.position.x - 1, tPlayer.transform.position.y), Quaternion.identity);
                Destroy(skillObj, 5f);
            }
            else
            {
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.transform.position.x + 1, tPlayer.transform.position.y), Quaternion.identity);
                skillObj.transform.localScale = new Vector3(-1.59f, 1.59f, 1.59f);
                Destroy(skillObj, 5f);
            }
            StartCoroutine(SkillDelay());
        }
    }
    IEnumerator SkillDelay()
    {
        yield return new WaitForSeconds(7f);
        onSkill = false;
    }
    // Update is called once per frame
    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Skill();
        }
    }
}
