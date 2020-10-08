using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject lightning;
    public int numberOfObject = 20;
    public float radius = 0.5f;
    float speed = 100f;

    public Transform player;
    float delayTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        delayTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.position, transform.position);
        
        if(dis < 10f)
        {
            if(Time.time > delayTime + 3)
            {
                delayTime = Time.time;

                float angle = 360 / numberOfObject;

                for(int i = 0; i < numberOfObject; i++)
                {
                    GameObject obj;

                    obj = (GameObject)Instantiate(lightning,transform.position,Quaternion.identity);

                    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed*Mathf.Cos(Mathf.PI * 2 * i/numberOfObject),
                        speed*Mathf.Sin(Mathf.PI * i * 2/numberOfObject)));

                    obj.transform.Rotate(new Vector3(0, 0, 360 * i / numberOfObject - 0)); // - 0 은 오브젝트 각도
                }
            }
        }
    }
}
