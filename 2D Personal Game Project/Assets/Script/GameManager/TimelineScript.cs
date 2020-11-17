using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineScript : MonoBehaviour
{
    public PlayableDirector timeline;
    public float maxTime;

    public void Skip()
    {
        timeline.time = maxTime;
    }
}
