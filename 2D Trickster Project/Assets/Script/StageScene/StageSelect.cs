using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class StageSelect : MonoBehaviour
{
    public TextMeshProUGUI stage1,stage2;
    public int StageNumber;
    public GameObject StageObject;
    int[] drillGauge;
    DrillGaugeSave dSave;
    private void Start()
    {
        dSave = GetComponent<DrillGaugeSave>();
        drillGauge[1] = PlayerPrefs.GetInt("채굴률", dSave.drillGauge[1]);
        drillGauge[2] = PlayerPrefs.GetInt("채굴률", dSave.drillGauge[2]);
        stage1.text = "채굴률 : " + dSave.drillGauge[1];
        stage2.text = "채굴률 : " + dSave.drillGauge[2];
    }
    public void SelectStage1()
    {
        SceneManager.LoadScene("SampleScene");
        StageNumber = 1;
        DontDestroyOnLoad(StageObject);
    }
    public void SelectStage2()
    {
        SceneManager.LoadScene("Stage2");
        StageNumber = 2; 
        DontDestroyOnLoad(StageObject);
    }
}
