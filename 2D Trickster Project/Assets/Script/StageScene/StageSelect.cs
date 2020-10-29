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
    DrillGaugeSave dSave;
    private void Start()
    {
        List<RecItem> itemList = DrillIO.Read(Application.dataPath + "DrillGauge.xml");
        RecItem drill1 = itemList[0];
        RecItem drill2 = itemList[1];
        stage1.text = "최고 채굴률 : " + drill1.DrillGauge + "%";
        stage2.text = "최고 채굴률 : " + drill2.DrillGauge + "%";

    }
    public void GoBack()
    {
        SceneManager.LoadScene("StageSelect");
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
