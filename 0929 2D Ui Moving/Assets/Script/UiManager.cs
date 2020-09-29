using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject ui;
    public bool b = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && b == true)
        {
            Instantiate(ui);
            b = false;
            StartCoroutine(boo());
        }

    }
    IEnumerator boo()
    {
        yield return new WaitForSeconds(5f);
        b = true;
        StopCoroutine(boo());
    }
}
