using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TowerCount : MonoBehaviour
{
    public int towerCount;
    public int count;
    bool active = false;
    public Image[] slates;
    public PlayableDirector sucessScene, failScene;

    private void Update()
    {
        if (active == false && count == 3)
        {
            active = true;
            StartCoroutine("countCheck");
        }
    }
    IEnumerator countCheck()
    {
        yield return new WaitForSeconds(1f);
        if (towerCount == 3)
        {
            Invoke("PlayCutscene", 1.5f);
        }
        else
        {
            Invoke("ResetSlate", 1.5f);
        }
    }
    void PlayCutscene()
    {
        sucessScene.Play();
    }
    private void ResetSlate()
    {
        failScene.Play();

        count = 0;
        towerCount = 0;
        active = false;
        for(int i = 0; i < slates.Length; i++)
        {
            slates[i].color = new Color(1, 1, 1,1);
            Destroy(slates[i].GetComponent<DragDrop>().cloneSlate);
        }
    }
}
