using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Menu;
    bool menuActive = false;
    public GameObject stageObject;
    public void Continue()
    {
        Menu.SetActive(false);
        menuActive = false;
        Time.timeScale = 1;
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene");
        Destroy(stageObject.gameObject);
        Time.timeScale = 1;
    }
    public void GameExit()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && menuActive == false)
        {
            Menu.SetActive(true);
            menuActive = true;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            Menu.SetActive(false);
            menuActive = false;
            Time.timeScale = 1;
        }
    }
}
