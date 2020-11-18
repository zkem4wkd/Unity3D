using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public GameObject[] maps;
    int i = 0;
    public void MapRightChange()
    {
        if (maps.Length <= i + 1)
        {
            return;
        }
        else
        {
            maps[i].SetActive(false);
            maps[i + 1].SetActive(true);
            i++;
        }
    }
    public void MapLeftChange()
    {
        if (maps.Length > i + 1)
        {
            return;
        }
        else
        {
            maps[i].SetActive(false);
            maps[i - 1].SetActive(true);
            i--;
        }
    }
}
