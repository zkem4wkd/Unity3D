using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    public Vector2 direction;

    private Animator myAnimator;
    private Rigidbody2D myRigid2D;

    bool isAttacking = false;
    Coroutine attackRoutine;
    public BoxCollider2D pBox;
    public GameObject ice;

    public enum LayerName
    {
        IdleLayer= 0,
        WalkLayer = 1,
        AtkLayer = 2
    }
    public bool isMoving
    {
        get { return direction.x != 0 || direction.y != 0; }
    }


    // Start is called before the first frame update
    void Start()
    {
        myRigid2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        ice = GetComponent<GameObject>();
        direction = Vector2.zero;
        //pBox.enabled = false;
    }

    void GetInput()
    {
        Vector2 moveVector;

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isAttacking)
            {
                attackRoutine = StartCoroutine(Attack());
                //Skill();
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
            //pBox.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleLayers();
    }

    public void HandleLayers()
    {
        if(isMoving)
        {
            ActivateLayer(LayerName.WalkLayer);
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else if(isAttacking)
        {
            ActivateLayer(LayerName.AtkLayer);
        }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }
    }

    public void ActivateLayer(LayerName layerName)
    {
        for(int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(1, 0);
        }
        myAnimator.SetLayerWeight((int)layerName, 1);
    }

    //스킬
    void Skill()
    {
        Instantiate(ice, transform.position, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        myRigid2D.velocity = direction.normalized * speed;
    }
}
