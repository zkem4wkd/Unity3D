using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed = 3f;
    Camera camera;
    Vector2 mousePosition;
    Rigidbody2D rigid2d;
    private float xVelocity = 0.0f;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flag = true;
            mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(mousePosition);
            Vector2 Shipmove = mousePosition;
            StartCoroutine(Moving());
        }
    }
    IEnumerator Moving()
    {
        float dis = Vector2.Distance(mousePosition, transform.position);
        transform.position = Vector3.Lerp(transform.position, mousePosition, 0.2f * Time.deltaTime);
        if (dis < 0.1f)
        {
            flag = false;
        }
        yield return null;
    }
}
