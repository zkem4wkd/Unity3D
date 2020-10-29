using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DrillGaugeSave : MonoBehaviour
{
    int[] lDrillGauge;
    public int[] drillGauge;

    public void Save(int[] lDrillGauge,int StageNumber)
    {
        PlayerPrefs.SetInt("채굴률", lDrillGauge[StageNumber]);
    }
    private void Start()
    {
        drillGauge[1] = PlayerPrefs.GetInt("채굴률", lDrillGauge[1]);
        drillGauge[2] = PlayerPrefs.GetInt("채굴률", lDrillGauge[2]);
    }
}

