using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : PlayerScript
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public CinemachineVirtualCamera vCam;
    public void PlayerChange1()
    {
        PlayerMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        Transform tPlayer = player.GetComponent<Transform>();
        PlayerAttack pAttack = player.GetComponent<PlayerAttack>();
        int pNumber = player.playerNumber;
        if (pNumber == 1)
        {
            Debug.Log("Same");
        }
        else
        {
            pAttack.onAttack = false;
            pAttack.onSkill = false;
            player1.gameObject.SetActive(true);
            player1.transform.position = player.transform.position;
            vCam.Follow = player1.transform;
            player.gameObject.SetActive(false);
        }
    }
    public void PlayerChange2()
    {
        PlayerMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        Transform tPlayer = player.GetComponent<Transform>();
        PlayerAttack pAttack = player.GetComponent<PlayerAttack>();
        int pNumber = player.playerNumber;
        if (pNumber == 2)
        {
            Debug.Log("Same");
        }
        else
        {
            pAttack.onAttack = false;
            pAttack.onSkill = false;
            player2.gameObject.SetActive(true);
            player2.transform.position = player.transform.position;
            vCam.Follow = player2.transform;
            player.gameObject.SetActive(false);
        }

    }
    public void PlayerChange3()
    {
        PlayerMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        Transform tPlayer = player.GetComponent<Transform>();
        PlayerAttack pAttack = player.GetComponent<PlayerAttack>();
        int pNumber = player.playerNumber;
        if (pNumber == 3)
        {
            Debug.Log("Same");
        }
        else
        {
            pAttack.onAttack = false;
            pAttack.onSkill = false;
            player3.gameObject.SetActive(true);
            player3.transform.position = player.transform.position;
            vCam.Follow = player3.transform;
            player.gameObject.SetActive(false);
        }
    }
    public void PlayerChange4()
    {
        PlayerMove player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        Transform tPlayer = player.GetComponent<Transform>();
        PlayerAttack pAttack = player.GetComponent<PlayerAttack>();
        int pNumber = player.playerNumber;
        if (pNumber == 4)
        {
            Debug.Log("Same");
        }
        else
        {
            pAttack.onAttack = false;
            pAttack.onSkill = false;
            player4.gameObject.SetActive(true);
            player4.transform.position = player.transform.position;
            vCam.Follow = player4.transform;
            player.gameObject.SetActive(false);
        }
    }
    protected override void Update()
    {
    }
}
