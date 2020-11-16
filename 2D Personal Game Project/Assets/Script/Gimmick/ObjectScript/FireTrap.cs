using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            transform.GetChild(0).gameObject.SetActive(false);
            this.GetComponent<CapsuleCollider2D>().enabled = false;
            Invoke("AgainFire", 20f);
        }
    }

    void AgainFire()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
