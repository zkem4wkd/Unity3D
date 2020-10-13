using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed = 3f;
    Camera camera;
    Vector2 mousePosition;
    Animator ani;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        ani = GetComponent<Animator>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ani.SetBool("Moving", true);
            mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, speed * Time.fixedDeltaTime);
            if(mousePosition.x > transform.position.x)
            {
                player.localScale = new Vector3(-3, 3, 1);
            }
            else
            {
                player.localScale = new Vector3(3, 3, 1);
            }
        }
        else
        {
            ani.SetBool("Moving", false);
        }
    }
}
