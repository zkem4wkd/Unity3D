using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : PlayerAttack
{
    Vector3 worldPos;
    bool onSkill = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();   
    }
    public override void Attack()
    {
        if (onAttack == false)
        {
            onAttack = true;
            base.Attack();
            playerAni.SetTrigger("Attack");
            worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject atkObj = Instantiate(attackObject, worldPos, Quaternion.identity);
            StartCoroutine(Delay());
            Destroy(atkObj, 5f);
        }
    }
    public override void Skill()
    {
        if (onSkill == false)
        {
            float j = 0;
            playerAni.SetTrigger("Attack");
            onSkill = true;
            StartCoroutine(SkillDelay());
            for (int i = 0; i < 3; i++)
            {
                j += 0.8f;
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.position.x + j, tPlayer.position.y+0.5f), Quaternion.identity);
                Destroy(skillObj, 1f);
            }
            j = 0;
            for (int i = 0; i < 3; i++)
            {
                j -= 0.8f;
                GameObject skillObj = Instantiate(skillObject, new Vector2(tPlayer.position.x + j, tPlayer.position.y+0.5f), Quaternion.identity);
                Destroy(skillObj, 1f);
            }
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5f);
        onAttack = false;
    }
    IEnumerator SkillDelay()
    {
        yield return new WaitForSeconds(3f);
        onSkill = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            Attack();
        }
        if(Input.GetKey(KeyCode.E))
        {
            Skill();
        }
    }
}
