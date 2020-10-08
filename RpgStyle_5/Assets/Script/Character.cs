using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Image Hp;
    [SerializeField]
    private float speed = 3;
    public Vector2 direction;

    private Animator myAnimator;
    private Rigidbody2D myrigid2D;
    public int pHp = 100;
    //공격
    bool isAttacking = false;
    Coroutine attackRoutine;
    public BoxCollider2D pBox;

    //스킬
    public GameObject Ice;

    public enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2
    }

    //프로퍼티
    //x나 y값이 0이아니면 IsMoving =true 
    //움직이냐 아니냐를 체크하는 bool값
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        myrigid2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        direction = Vector2.zero;
    }

    void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //공격
            if(!isAttacking)
            {
                attackRoutine = StartCoroutine(Attack());
                Skill();
            }
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        myAnimator.SetBool("attack", isAttacking);
        pBox.enabled = true;
        yield return new WaitForSeconds(0.3f);
        StopAttack();
    }

    public void StopAttack()
    {
        if(attackRoutine != null)
        {
            StopCoroutine(attackRoutine);
            isAttacking = false;
            myAnimator.SetBool("attack", isAttacking);
            pBox.enabled = false;
        }
    }




    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleLayers();
        Hp.fillAmount = pHp * 0.01f;
    }

    public void HandleLayers()
    {
        if(IsMoving)
        {
            ActivateLayer(LayerName.WalkLayer);
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else if(isAttacking)
        {
            ActivateLayer(LayerName.AttackLayer);
        }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }

    }
    //애니메이터 안의 레이어이름을 정해준다.
    public void ActivateLayer(LayerName layerName)
    {
        //초기화
        for(int i =0; i<myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }
        //맞는 레이어 활성화 앞이 레이어번호 ,뒤가 0이면 꺼지고 1이면 켜지고
        myAnimator.SetLayerWeight((int)layerName, 1);
    }
    //물리연산은 fixedupdate를 이용해야 확실한 처리가 가능
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        myrigid2D.velocity = direction.normalized * speed;
    }


    void Skill()
    {
        //up 
        Instantiate(Ice, transform.position, Quaternion.identity);
    }




}
