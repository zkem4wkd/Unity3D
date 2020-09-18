using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTrap : MonoBehaviour
{
    GameObject floorTrap;
    public GameObject needle;
    public float needleSpeed = 5f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            needle.transform.Translate(Vector2.down * needleSpeed * Time.deltaTime);
            Debug.Log("1");
        }
    }
    void Start()
    {
        floorTrap = GameObject.FindGameObjectWithTag("FloorTrap");
        needle = GameObject.Find("Needle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
