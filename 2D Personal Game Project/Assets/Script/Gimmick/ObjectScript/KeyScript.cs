using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public Canvas keyPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            keyPanel.gameObject.SetActive(true);
            Destroy(this.gameObject);
            DontDestroyOnLoad(keyPanel);
        }
    }
}
