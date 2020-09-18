using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    GameObject portal;
    WalkingScript wPlayer;
    // Start is called before the first frame update
    void Start()
    {
        portal = GameObject.FindGameObjectWithTag("Portal");


        wPlayer = GameObject.Find("Player").GetComponent<WalkingScript>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(portal.transform.position, wPlayer.transform.position);

        if (distance < 0.3f)
        {
            SceneManager.LoadScene("Scene2");
        }

    }
}
