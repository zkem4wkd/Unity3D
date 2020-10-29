using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    private void Awake()
    {
        List<RecItem> itemList = new List<RecItem>();
        for (int i = 0; i < 5; i++)
        {
            RecItem item = new RecItem();
            item.DrillGauge = 0;
            itemList.Insert(i, item);
        }
        DrillIO.Write(itemList, Application.dataPath + "DrillGauge.xml");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
