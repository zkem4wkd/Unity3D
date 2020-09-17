using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float Speed = 0f;
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //this.Speed = 0.1f;

            this.startPos = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            float swipeLength = (endPos.x - this.startPos.x);

            this.Speed = swipeLength / 500.0f;

            //효과음 재생
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.Speed = -0.1f;
        }

        transform.Translate(this.Speed,0,0);
        this.Speed *= 0.96f;
    }
}
