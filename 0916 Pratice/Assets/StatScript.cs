using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScript : MonoBehaviour
{
    Transform Player;
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int Atk;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
