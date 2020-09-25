using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal1 : MonoBehaviour
{
    GameObject portal;
    GameObject wPlayer;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");
        //wPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
    // Update is called once per frame
    void Update()
    {

        //float distance = Vector2.Distance(portal.transform.position, wPlayer.transform.position);

        //if (distance < 0.3f)
        //{
        //    SceneManager.LoadScene("GameClear");
        //}

    }
}
