using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerCount : MonoBehaviour
{
    public int towerCount;
    public int count;
    bool active = false;
    public Image[] slates;

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
        Debug.Log("1");
    }
    private void ResetSlate()
    {
        Debug.Log("2");
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
