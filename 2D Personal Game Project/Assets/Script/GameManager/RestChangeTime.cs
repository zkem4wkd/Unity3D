using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RestChangeTime : MonoBehaviour
{
    GameController gC;
    public int cTime;
    public PlayableDirector timeline;
    public GameObject restText;
    private void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }
    public void ChangeTime()
    {
        if (gC.worldTime >= 6 && gC.worldTime <= 12)
        {
            restText.SetActive(true);
            Invoke("ActiveF", 2f);
        }
        else
        {
            gC.worldTime = cTime;
            timeline.Play();
        }
    }
    void ActiveF()
    {
        restText.SetActive(false);
    }
}
