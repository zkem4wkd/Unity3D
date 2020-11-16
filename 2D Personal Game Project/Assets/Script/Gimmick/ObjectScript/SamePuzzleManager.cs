using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SamePuzzleManager : MonoBehaviour
{
    public SamePuzzle[] button;
    public PlayableDirector timeline;
    bool play = false;


    private void Update()
    {
        if(button[0].texture == true && button[1].texture == true && button[2].texture == true && play == false)
        {
            play = true;
            Invoke("TimelinePlay", 2f);
            return;
        }
    }
    void TimelinePlay()
    {
        timeline.Play();
    }
}
