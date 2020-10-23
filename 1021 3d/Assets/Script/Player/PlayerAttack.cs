using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int NormalDamage = 10;
    public int SkillDamage = 30;
    public int DashDamage = 30;

    public NormalTarget normalTarget;
    public SkillTarget skillTarget;
    
    public void NormalAttack()
    {
        List<Collider> targetList = new List<Collider>(normalTarget.targetList);

        foreach(Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponentInParent<EnemyHealth>();

            if(enemy != null)
            {
                StartCoroutine(enemy.StartDamage(NormalDamage,transform.position,0.5f,10f));
            }
        }
    }

    public void SkillAttack()
    {
        List<Collider> targetList = new List<Collider>(skillTarget.targetList);

        foreach (Collider one in targetList)
        {
            EnemyHealth enemy = one.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
            {
                StartCoroutine(enemy.StartDamage(SkillDamage, transform.position, 0.5f, 20f));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
