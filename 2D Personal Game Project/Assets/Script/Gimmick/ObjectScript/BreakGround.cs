using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BreakGround : MonoBehaviour
{
    int groundHp = 3;
    public PlayableDirector timeline;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            groundHp--;
            timeline.Play();
            if (groundHp <= 0)
            {
                Destroy(this.gameObject,2f);
            }
        }
    }
}
