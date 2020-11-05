using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementFire : MonoBehaviour
{
    public GameObject fireElement;
    public ElementBall bScript;
    Transform player;
    bool click = false;
    GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void onClick()
    {
        click = true;
    }
    void ThrowBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            click = false;
            fire = Instantiate(fireElement, player.position, Quaternion.identity);
            Destroy(fire, 3.7f);
            bScript.FireElement();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (click == true)
        {
            ThrowBall();
        }
    }
}
