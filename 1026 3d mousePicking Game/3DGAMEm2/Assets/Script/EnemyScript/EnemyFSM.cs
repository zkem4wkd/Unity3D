using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
   public enum State
    {
        Idle,
        Move,
        Attack,
        AttackWait,
        Dead
    }


    //Idle 상태를 기본상태로 지정
    public State currentState = State.Idle;

    //마우스 클릭 지점, 플레이어가 이동할 목적지의 좌표
    Vector3 curTargetPos;

    GameObject curPlayer;

    public float rotAnglePerSecond = 360f;// 1초에 플레이어의 방향을 360도 회전

    public float moveSpeed = 2f; //초당 2의 속도이동

    float attackDelay = 2f;
    float attackTimer = 0f;
    float attackDistance = 1.5f;
    float chaseDistance = 2.5f;

    EnemyAni myAni;
    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<EnemyAni>();
        ChangeState(State.Idle, EnemyAni.ANI_ATKIDLE);
        curPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    public void AttackEnemy(GameObject player)
    {
        if(curPlayer != null && curPlayer == player)
        {
            return;
        }
        curPlayer = player;
        curTargetPos = curPlayer.transform.position;

        ChangeState(State.Move, EnemyAni.ANI_WALK);
    }

    void ChangeState(State newState, int aniNumber)
    {
        if(currentState == newState)
        {
            return;
        }

        myAni.ChangeAni(aniNumber);
        currentState = newState;
    }

    //캐릭터의 상태가 바뀌면 어떤 일이 일어날지 정의
    void UpdateState()
    {
        switch(currentState)
        {
            case State.Idle:
                IdleState();
                break;
            case State.Move:
                MoveState();
                break;
            case State.Attack:
                AttackState();
                break;
            case State.AttackWait:
                AttackWaitState();
                break;
            case State.Dead:
                DeathState();
                break;
            default:
                break;
        }
    }

    public void MoveTo(Vector3 tPos)
    {
        curTargetPos = tPos;
        ChangeState(State.Move, EnemyAni.ANI_WALK);
    }

    void TrunToDestination()
    {
        //목표방향은 목적지위치에서 자신의 위치를 빼면 구함
        Quaternion lookRotation =
            Quaternion.LookRotation(curTargetPos - transform.position);

        //로테이트타워드(현재의 rotation값, 최종목표rotation값, 최대 회전각)
        transform.rotation
            = Quaternion.RotateTowards(transform.rotation
            , lookRotation, Time.deltaTime * rotAnglePerSecond);
    }

    void MoveToDestination()
    {
        //MoveTowards(시작지점,목표지점,최대이동거리)
        transform.position = Vector3.MoveTowards(transform.position
            , curTargetPos, moveSpeed * Time.deltaTime);
        if (curPlayer == null)
        {
            //플레이어의 위치와 목표지점의 위치가 같으면 , 상태를 Idle상태로 바꿈
            if (transform.position == curTargetPos)
            {
                ChangeState(State.Idle, EnemyAni.ANI_IDLE);
            }
        }
        else if(Vector3.Distance(transform.position,curTargetPos)<attackDistance)
        {
            ChangeState(State.Attack, EnemyAni.ANI_ATTACK);
        }

    }

    void IdleState()
    {
        
    }
    void MoveState()
    {
        TrunToDestination();
        MoveToDestination();
    }

    void AttackState()
    {
        attackTimer = 0;

        transform.LookAt(curTargetPos);
        ChangeState(State.AttackWait, EnemyAni.ANI_ATTACK);
    }

    void AttackWaitState()
    {
        if(attackTimer > attackDelay)
        {
            ChangeState(State.Attack, EnemyAni.ANI_ATTACK);
        }
        attackTimer += Time.deltaTime;
    }
    void DeathState()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        if(Vector3.Distance(transform.position,curPlayer.GetComponent<Transform>().position) < 0.3f)
        {
            AttackState();
        }
    }
}
