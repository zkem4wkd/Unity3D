using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
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

    GameObject curEnemy;

    public float rotAnglePerSecond = 360f;// 1초에 플레이어의 방향을 360도 회전

    public float moveSpeed = 2f; //초당 2의 속도이동

    float attackDelay = 2f; //공격을 한번 하고 다시 공격할때 까지 시간
    float attackTimer = 0f; //공격을 하고 난 뒤에 경과되는 시간 계산
    float attackDistance = 1.5f;  //공격거리
    float chaseDistance = 2.5f; //전투중 적이 도망가면 다시 추적을 시작하기 위한 거리

    PlayerAni myAni;
    // Start is called before the first frame update
    void Start()
    {
        myAni = GetComponent<PlayerAni>();
        ChangeState(State.Idle, PlayerAni.ANI_ATKIDLE);
    }
    public void AttackCalculate()
    {
        if(curEnemy == null)
        {
            return;
        }
        curEnemy.GetComponent<EnemyFSM>().ShowHitEffect();
    }
    //적을 공격하기 위한 함수
    public void AttackEnemy(GameObject enemy)
    {
        if(curEnemy != null && curEnemy == enemy)
        {
            return;
        }
        curEnemy = enemy;
        curTargetPos = curEnemy.transform.position;

        ChangeState(State.Move, PlayerAni.ANI_WALK);
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
                DeadState();
                break;
            default:
                break;
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
        ChangeState(State.AttackWait, PlayerAni.ANI_ATKIDLE);
    }
    void AttackWaitState()
    {
        if(attackTimer > attackDelay)
        {
            ChangeState(State.Attack, PlayerAni.ANI_ATTACK);
        }
        attackTimer += Time.deltaTime;

    }
    void DeadState()
    {

    }


    public void MoveTo(Vector3 tPos)
    {
        curEnemy = null;
        curTargetPos = tPos;
        ChangeState(State.Move, PlayerAni.ANI_WALK);
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

        if(curEnemy == null)
        {
            //플레이어의 위치와 목표지점의 위치가 같으면 , 상태를 Idle상태로 바꿈
            if (transform.position == curTargetPos)
            {
                ChangeState(State.Idle, PlayerAni.ANI_IDLE);
            }
        }
        else if(Vector3.Distance(transform.position,curTargetPos)<attackDistance)
        {
            ChangeState(State.Attack, PlayerAni.ANI_ATTACK);
        }       
    }



    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
}
