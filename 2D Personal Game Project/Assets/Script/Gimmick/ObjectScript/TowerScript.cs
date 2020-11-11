using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    public int number;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if (collision.GetComponent<GetStoneScript>().slateNumber == this.number)
            {
                TowerCount pScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<TowerCount>();
                pScript.towerCount++;
                collision.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
