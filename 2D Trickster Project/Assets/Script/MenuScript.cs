using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject Menu;
    bool menuActive = false;
    public void Continue()
    {
        Menu.SetActive(false);
        menuActive = false;
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("StartScene");
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
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menuActive == true)
        {
            Menu.SetActive(false);
            menuActive = false;
        }
    }
}
