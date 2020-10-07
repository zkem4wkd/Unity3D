using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 3;
    public Vector2 direction;
    private Rigidbody2D myrigid2D;
    public float MoveSpeed;
    public JoyStick joyStick;

    // Start is called before the first frame update
    void Start()
    {
        myrigid2D = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;
        joyStick = GetComponent<JoyStick>();
    }
    public void HandleInput()
    {
        Vector2 moveVector;
        float h = joyStick.getHorizontalValue();
        float v = joyStick.getVerticalValue();

        moveVector = new Vector3(h, v, 0).normalized;
        myrigid2D.velocity = moveVector * speed;
    }
    private void FixedUpdate()
    {
        HandleInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
