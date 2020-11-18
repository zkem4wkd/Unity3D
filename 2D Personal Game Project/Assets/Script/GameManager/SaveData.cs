using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int worldTime;

    public SaveData(int _time)
    {
        worldTime = _time;
    }
}
