using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : PlayerAttack
{
    float speed = 6.5f;
    Vector3 mousePos;
    protected override void Start()
    {
        base.Start();
    }
    public override void Attack()
    {
        if (onAttack == false && action == false)
        {
            base.Attack();
            playerAni.SetTrigger("Attack");
            if (tPlayer.transform.localScale.x == 1)
            {
                onAttack = true;
                GameObject atkObj = Instantiate(attackObject, new Vector2(tPlayer.transform.position.x - 1, tPlayer.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 90)));
                atkObj.GetComponent<Rigidbody2D>().velocity = new Vector2(tPlayer.transform.localScale.x * -speed, 0);
                StartCoroutine(Delay());
                Destroy(atkObj, 1f);
            }
            else if (tPlayer.transform.localScale.x == -1)
            {
                onAttack = true;
                GameObject atkObj = Instantiate(attackObject, new Vector2(tPlayer.transform.position.x + 1, tPlayer.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 90)));
                atkObj.GetComponent<Rigidbody2D>().velocity = new Vector2(tPlayer.transform.localScale.x * -speed, 0);
                StartCoroutine(Delay());
                Destroy(atkObj, 1f);
            }
        }
    }
    public override void Skill()
    {
        playerAni.SetTrigger("Attack");
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        onSkill = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        GameObject skillObj = Instantiate(skillObject, mousePos, Quaternion.identity);
        Destroy(skillObj, 10f);
        StartCoroutine(SkillDelay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        onAttack = false;
    }
    IEnumerator SkillDelay()
    {
        yield return new WaitForSeconds(5f);
        onSkill = false;
    }
    protected override void Update()
    {
        if(Input.GetKey(KeyCode.E) && onSkill == false)
        {
            Skill();
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Attack();
        }
    }
}
