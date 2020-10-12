using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//다형성
public class Unit 
{
    public virtual void Move()
    {
        Debug.Log("Moving");
    }

    public virtual void Attack()
    {
        Debug.Log("Attack");
    }
}

public class Marine : Unit
{
    public override void Move()
    {
        Debug.Log("Marine Moving");
    }
    public override void Attack()
    {
        Debug.Log("Marine Attack");
    }
}
public class Firebat : Unit
{
    public override void Move()
    {
        Debug.Log("Firebat Moving");
    }
    public override void Attack()
    {
        Debug.Log("Firebat Attack");
    }
}
public class Ghost : Unit
{
    public override void Move()
    {
        Debug.Log("Ghost Moving");
    }
    public override void Attack()
    {
        Debug.Log("Ghost Attack");
    }
}
public class poly : MonoBehaviour
{
    Unit unit;
    Unit marine;
    // Start is called before the first frame update
    void Start()
    {
        unit = new Unit();
        marine = new Marine();

        unit.Move();
        unit.Attack();
        marine.Move();
        marine.Attack();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
