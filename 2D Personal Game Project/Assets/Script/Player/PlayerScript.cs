using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    protected GameObject Player;
    protected Transform tPlayer;
    protected Animator playerAni;
    protected Rigidbody2D playerRigid;
    [SerializeField]
    protected PlayerStatus playerStatus;
    protected  PlayerStatus pStatus { set { playerStatus = value; } }
    protected bool action = false;
    // Start is called before the first frame update
    virtual protected void Start()
    {
        Player = this.GetComponent<GameObject>();
        tPlayer = this.GetComponent<Transform>();
        playerAni = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    virtual protected void Update()
    {
    }
}

