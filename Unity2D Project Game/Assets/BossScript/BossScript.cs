using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public GameObject Cannon;
    public GameObject Niddle;
    public GameObject autoBullet;
    public GameObject thunder;
    GameObject hpGauge;
    float delta = 0.0f;
    public float timeTrigger = 0.5f;
    float cannonY = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="uCannon")
        {
            hpGauge = GameObject.Find("BossHp");
            hpGauge.GetComponent<Image>().fillAmount -= 0.05f;
            Destroy(collision.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("Pattern1");
    }


    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        print(delta);
        if (transform.position.y < -0.8)
        {
            transform.Translate(Vector2.up * 5f * Time.deltaTime);
        }
        
    }
    IEnumerator Pattern1()
    {
        yield return new WaitForSeconds(3f);
        while (delta < 10f)
        {
            float niddleX = Random.Range(-6f, 1.9f);
            yield return new WaitForSeconds(timeTrigger);
            Instantiate(Niddle, new Vector2(niddleX, 4.8f), Quaternion.identity);
            yield return StartCoroutine("Pattern2");
        }
    }
    IEnumerator Pattern2()
    {
        while (delta >10f && delta < 20f)
        {
            Instantiate(autoBullet);
            yield return new WaitForSeconds(0.3f);
        }

        yield return StartCoroutine("Pattern3");
    }
    IEnumerator Pattern3()
    {
        while (delta > 20f && delta <30f)
        {
            cannonY -= 2; 
            Instantiate(Cannon,new Vector2(4.65f,cannonY),Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        yield return StartCoroutine("Pattern4");
    }
    IEnumerator Pattern4()
    {
        while (delta > 30f && delta < 40f)
        {
            Instantiate(thunder);
            yield return new WaitForSeconds(1f);
            Destroy(thunder);
        }
        Destroy(thunder);
        yield return 0;
    }

}
