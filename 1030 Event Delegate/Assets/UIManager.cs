using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerText;
    public void OnPlayerDead()
    {
        playerText.text = "You Die!!";
    }   
}
