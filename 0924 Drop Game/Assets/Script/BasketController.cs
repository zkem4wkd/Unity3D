using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject director;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        director = GameObject.Find("GameDirector");
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //충돌을 감지하면 true값 반환
            RaycastHit hit;
            
            
            //Raycast(시작지점,방향,레이저를 쏠 길이)
            if(Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                //가장 가까운 정수로 변환해주는 메소드 10.2 -> 10  , .5일땐 짝수 반환
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "apple")
        {
            director.GetComponent<GameDirector>().getApple();
            aud.PlayOneShot(appleSE);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag =="bomb")
        {
            director.GetComponent<GameDirector>().getBomb();
            aud.PlayOneShot(bombSE);
            Destroy(other.gameObject);
        }
    }
}
