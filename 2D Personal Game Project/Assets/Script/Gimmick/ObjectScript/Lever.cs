using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Lever : MonoBehaviour
{
    public Sprite LeverLeft;
    public Sprite LeverRight;
    public bool leverOn;
    public PlayableDirector timeline;
    bool action = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F) && leverOn == false && action == false)
            {
                action = true;
                leverOn = true;
                this.GetComponent<SpriteRenderer>().sprite = LeverRight;
                timeline.Play();
                Invoke("Trigger", 3f);
            }
            else if (Input.GetKeyDown(KeyCode.F) && leverOn == true && action == false)
            {
                action = true;
                leverOn = false;
                this.GetComponent<SpriteRenderer>().sprite = LeverLeft;
                GetComponent<PlayableDirector>().Play();
                Invoke("Trigger", 3f);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void Trigger()
    {
        action = false;
    }
}
