﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//캐릭터파람스는 플레이어의 파라미터 클래스와 몬스터
//클래스의 부모 클래스 역할을 하게됨
public class CharacterParams : MonoBehaviour
{
    //퍼블릭 변수가 아니라 약식프로퍼티,속성으로 지정
    //퍼블릭 변수와 똑같이 사용할수 있지만 유니티 인스펙터에
    //노출되는것을 막고 보안을 위해 정식 프로퍼티로 전환이 쉬어짐
    public int level { get; set; }
    public int maxHp { get; set; }
    public int curHp { get; set; }
    public int attackMin { get; set; }
    public int attackMax { get; set; }
    public int defense { get; set; }
    public bool isDead { get; set; }

    [System.NonSerialized]
    public UnityEvent deadEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        InitParams();
    }
    //나중에 CharacterParams클래스를 상속한 자식클래스에서
    //InitParams함수에 자신만의 명령어를 추가하기만 하면 자동으로 필요한
    //명령어들이 실행
    public virtual void InitParams()
    {

    }
    public int GetRandomAttack()
    {
        int randAttack = Random.Range(attackMin, attackMax + 1);
        return randAttack;
    }

    public void SetEnemyAttack(int enemyAttackPower)
    {
        curHp -= enemyAttackPower;
        UpdateAfterReceiveAttack();
    }
    //캐릭터가 적으로 공격을 받은 뒤에 자동으로 실행되게 함수를 
    //가상함수로 만든다.
    protected virtual void UpdateAfterReceiveAttack()
    {
        print(name + "Hp : " + curHp);

        if(curHp<=0)
        {
            curHp = 0;
            isDead = true;
            deadEvent.Invoke();
        }
    }

}
