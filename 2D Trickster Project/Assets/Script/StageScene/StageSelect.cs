using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelect : MonoBehaviour
{
    public int StageNumber;
    public GameObject StageObject;
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
