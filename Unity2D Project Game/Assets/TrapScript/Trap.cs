using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    GameObject[] trap;
    Transform tTrap;
    WalkingScript player;
    public float dropSpeed = 6f;
    float playerTrapDistance = 1.3f;
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
        trap = GameObject.FindGameObjectsWithTag("Trap");
        player = GameObject.Find("Player").GetComponent<WalkingScript>();
        //tTrap = trap.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < trap.Length; i++)
        {
            if (trap[i].transform.position.x - player.transform.position.x < playerTrapDistance)
            {
                trap[i].transform.Translate(Vector2.down * dropSpeed * Time.deltaTime);
                playerTrapDistance = 2f;
            }
            

        }
        for(int i = 0; i < trap.Length; i ++)
        {
            if (trap[i].transform.position.y < -50f)
            {
                Destroy(trap[i]);
            }
        }
        
    }
    
    
}
