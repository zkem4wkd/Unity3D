using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_key : MonoBehaviour
{
    public Transform Player;

    public float pSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("Player").GetComponent<Transform>();
        //Player = gameObject.GetComponent<Transform>();
        Player = GameObject.FindGameObjectWithTag("pPlayer").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.transform.Translate(Vector2.left * pSpeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player.transform.Translate(Vector2.right * pSpeed* Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player.transform.Translate(Vector2.up * pSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Player.transform.Translate(Vector2.down * pSpeed * Time.deltaTime);
        }
       

    }
}
