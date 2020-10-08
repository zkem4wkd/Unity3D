using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bam : MonoBehaviour
{
    //번개
    public GameObject lightning;
    public int numberOfObjects = 20;
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

        //거리가 10이상 벗어나면 번개 안씀
        if (dis < 10f)
        {
            if(Time.time >= delayTime + 3)
            {
                delayTime = Time.time;

                //360도 방향으로 번개날리기
                float angle = 360 / numberOfObjects;

                for(int i =0; i<numberOfObjects; i++)
                {
                    GameObject obj;

                    obj = (GameObject)Instantiate(lightning
                        , transform.position, Quaternion.identity);
                    //생성발사
                    obj.GetComponent<Rigidbody2D>().AddForce(
                        new Vector2(speed*Mathf.Cos(Mathf.PI*2*i/numberOfObjects),
                        speed*Mathf.Sin(Mathf.PI*2*i/numberOfObjects)));
                    //방향
                    obj.transform.Rotate(new Vector3(0, 0, 360 * i / numberOfObjects ));
                }

            }
        }


    }
}
