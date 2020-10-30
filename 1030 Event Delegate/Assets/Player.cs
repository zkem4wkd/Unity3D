using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent onPlayerDead;
    //public UIManager uiManager;
    //public QuestSystem questSystem;
    //public EventManager eventManager;
    private void Dead()
    {
        onPlayerDead.Invoke();//Invoke : 발동하다.
        //uiManager.OnPlayerDead();
        //questSystem.UnLockQuest("첫번째 퀘스트");
        //eventManager.OnPlayerDead();
        //Debug.Log("죽었다.");
        //Destroy(gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {
        Dead();
    }

   
}
