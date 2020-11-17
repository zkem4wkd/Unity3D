using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : WaterAttack
{
    Vector3 mousePos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Fire"))
        {
            collision.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    protected override void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        this.transform.position = mousePos;
    }
}
