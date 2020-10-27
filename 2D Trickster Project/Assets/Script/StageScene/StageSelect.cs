using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public void SelectStage1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SelectStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
