using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestButton : MonoBehaviour
{
    public int timeNumber;
    RestChangeTime rChangeTime;
    private void Start()
    {
        rChangeTime = GameObject.FindGameObjectWithTag("TimeSystem").GetComponent<RestChangeTime>();
    }
    public void SendTime()
    {
        rChangeTime.cTime = timeNumber;
    }
}
