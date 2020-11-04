using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementWind : MonoBehaviour
{
    Vector3 mousePos;
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        this.transform.position = mousePos;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
