using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRock : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime);
    }
}
