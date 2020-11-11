using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStoneScript : MonoBehaviour
{
    public Image panelStone;
    public int slateNumber;
    Canvas slateC;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        slateC = GameObject.Find("SlateCanvas").GetComponent<Canvas>();
        if(collision.gameObject.CompareTag("Player") && slateC != null)
        {
            panelStone.color = new Color(1f, 1f, 1f,1f);
            Destroy(this.gameObject);
        }
    }
}
