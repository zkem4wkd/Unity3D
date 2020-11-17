using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int worldTime;
    public float[] pos;

    public SaveData(int _time)
    {
        worldTime = _time;
    }
}
