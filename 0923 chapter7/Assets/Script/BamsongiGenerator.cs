using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //float randomX = Random.Range(18, 24);
        //float randomY = Random.Range(3.0f, 8.0f);
        //float randomZ = Random.Range(0f, 4.0f);
        if(Input.GetMouseButtonDown(0))
        {
            //GameObject bamsongi = Instantiate(bamsongiPrefab,new Vector3(randomX,randomY,randomZ),Quaternion.identity) as GameObject;
            GameObject bamsongi = Instantiate(bamsongiPrefab) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);


        }
    }
}
