﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyFSM : MonoBehaviour
{
    public enum State
    {
        Idle,//정지
        Chase,//추적
        Attack,//공격
        Dead,//사망
        NoState//아무일도 없는 상태
    }
    public State currentState = State.Idle;

    EnemyParams myParams;

    EnemyAni myAni;

    Transform player;

    PlayerParams playerParams;


    //플레이어를 향해 몬스터가 추적을 시작할 거리
    float chaseDistance = 5f;
    //플레이어가 안쪽으로 들어오게 되면 공격을 시작
    float attackDistance = 2.5f;
    //플레이어가 도망 갈 경우 얼마나 떨어져야 다시 추적
    float reChaseDistance = 3f;
    //초당 회전 각도
    float rotAnglePersecond = 360f;
    //몬스터 이동속도
    float moveSpeed = 1.3f;
    float attackDelay = 2;
    float attackTimer = 0f;

    public ParticleSystem hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<EnemyAni>();
        myParams = GetComponent<EnemyParams>();
        myParams.deadEvent.AddListener(CallDeadEvent);

        ChangeState(State.Idle, EnemyAni.IDLE);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerParams = player.gameObject.GetComponent<PlayerParams>();

        hitEffect.Stop();
    }
    //몬스터가 죽는 순간 처리 명령어
    void CallDeadEvent()
    {
        ChangeState(State.Dead, EnemyAni.DIE);
        player.gameObject.SendMessage("CurrentEnemyDead");
    }




    public void ShowHitEffect()
    {
        hitEffect.Play();
    }
    public void AttackCalculate()
    {
        playerParams.SetEnemyAttack(myParams.GetRandomAttack());
    }


    void UpdateState()
    {
        switch(currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Chase:
                ChaseState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.Dead:
                DeadState();
                break;
            case State.NoState:
                NodeState();
                break;
        }
    }

    private void NodeState()
    {
        
    }

    private void DeadState()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    private void AttackState()
    {
        if(GetDistanceFromPlayer()>reChaseDistance)
        {
            attackTimer = 0f;
            ChangeState(State.Chase, EnemyAni.WALK);
        }
        else
        {
            if(attackTimer > attackDelay)
            {
                transform.LookAt(player.position);
                myAni.ChangeAni(EnemyAni.ATTACK);
                attackTimer = 0f;
            }
            attackTimer += Time.deltaTime;
        }       
    }

    private void ChaseState()
    {
       //몬스터가 공격가능 거리 안으로 들어가면 공격 상태
        if(GetDistanceFromPlayer() <attackDistance)
        {
            ChangeState(State.Attack, EnemyAni.ATTACK);
        }
        else
        {
            TrunToDestination();
            MoveToDestination();
        }
    }
    void TrunToDestination()
    {
        Quaternion lookRotation
            = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            lookRotation, Time.deltaTime * rotAnglePersecond);

    }
    void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position
            , player.position, moveSpeed * Time.deltaTime);
    }



    private void IdleState()
    {
        if(GetDistanceFromPlayer() <chaseDistance)
        {
            ChangeState(State.Chase, EnemyAni.WALK);
        }
    }
    //플레이어랑 거리를 구하는 함수
    float GetDistanceFromPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance;
    }



    //상태를 바꾼다.
    public void ChangeState(State newState, string aniName)
    {
        if(currentState == newState)
        {
            return;
        }

        currentState = newState;
        myAni.ChangeAni(aniName);
    }


    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}
