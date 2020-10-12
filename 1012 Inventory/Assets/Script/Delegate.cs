using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Delegate : MonoBehaviour
{
    delegate void MyDele();
    MyDele mDele;
    public void Plus()
    {
        Debug.Log("Plus Method");
    }

    public void Minus()
    {
        Debug.Log("Minus Method");
    }
    public void Multi()
    {
        Debug.Log("Multiply Method");
    }
    // Start is called before the first frame update
    void Start()
    {
        mDele = new MyDele(Plus);
        mDele += Minus;
        mDele += Multi;
        mDele();
        mDele -= Minus;
        mDele();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
