using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Needel : MonoBehaviour
{
    GameObject needle;
    WalkingScript player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SampleScene 1");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        needle = GameObject.FindGameObjectWithTag("Needle");
        player = GameObject.Find("Player").GetComponent<WalkingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (needle.transform.position.y < -10f)
            {
                Destroy(this.gameObject);
            }
        
    }
}
