using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    Transform Player;
    public float pSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizon = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Player.transform.Translate(Vector2.right * Horizon*pSpeed * Time.deltaTime);
        Player.transform.Translate(Vector2.up *Vertical* pSpeed * Time.deltaTime);



        
    }
}
