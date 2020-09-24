using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float Speed = -0.03f;
    public void setParameter(float span,float Speed,int ratio)
    {
        this.span = span;
        this.Speed = Speed;
        this.ratio = ratio;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        delta += Time.deltaTime;
        if(delta > span)
        {
            delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11);
            if(dice <= ratio)
            {
                item = Instantiate(bombPrefab);
            }
            else
            {
                item = Instantiate(applePrefab);
            }
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.position = new Vector3(x, 4, z);
            item.GetComponent<ItemController>().dropSpeed = this.Speed;
        }
    }
}
