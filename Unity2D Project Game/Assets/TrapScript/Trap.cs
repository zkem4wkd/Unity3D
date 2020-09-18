using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    GameObject trap;
    Transform tTrap;
    WalkingScript player;
    public float dropSpeed = 1f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene 1");
        }
    }
    void Start()
    {
        trap = GameObject.FindGameObjectWithTag("Trap");
        player = GameObject.Find("Player").GetComponent<WalkingScript>();
        tTrap = trap.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
            if (tTrap.transform.position.x - player.transform.position.x < 1f)
            {
                tTrap.transform.Translate(Vector2.down * dropSpeed * Time.deltaTime);
            }
    }
    
}
