using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TeleportScript : MonoBehaviour
{
    public PlayableDirector timeLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            timeLine.Play();
        }
    }
}
