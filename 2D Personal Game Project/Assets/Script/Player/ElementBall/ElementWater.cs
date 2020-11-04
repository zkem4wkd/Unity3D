using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementWater : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - 4f * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + 4f * Time.deltaTime, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
}
