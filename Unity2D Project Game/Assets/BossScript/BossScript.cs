using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    GameDirector gameDirector;

    public GameObject explosion;
    public GameObject Cannon;
    public GameObject Niddle;
    public GameObject autoBullet;
    public GameObject thunder;
    public GameObject Wall;
    GameObject hpGauge;
    public float delta = 0.0f;
    public float timeTrigger = 0.5f;
    float cannonY = 5f;

    SpriteRenderer boss;
    IEnumerator cour;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag=="uCannon")
        {
            hpGauge.GetComponent<Image>().fillAmount -= 0.05f;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Bullet")
        {
            boss.color = new Color(255, 255, 255, 0.5f);
            StartCoroutine(FadeIn());
        }
    }
    
    
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.1f);
        boss.color = new Color(255, 255, 255, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        hpGauge = GameObject.Find("BossHp");
        gameDirector = GameObject.Find("BossHp").GetComponent<GameDirector>();

        boss = GameObject.Find("Boss").GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        StartCoroutine("Pattern1");
    }
    private void OnDisable()
    {
        StopAllCoroutines();

    }
    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (transform.position.y < -0.8)
        {
            transform.Translate(Vector2.up * 5f * Time.deltaTime);
        }

        if (
        hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            cour = bossClear();
            StartCoroutine(cour);
            delta = 60;
        }
    }
    IEnumerator bossClear()
    {
        Explosion();
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        Destroy(Wall.gameObject);
    }
    void Explosion()
    {
        float exX = Random.Range(3f, 7f);
        float exY = Random.Range(-4.6f, 2.5f);
        Instantiate(explosion, new Vector2(exX, exY), Quaternion.identity);
        
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
        while (delta > 20f && delta <25f)
        {
            cannonY -= 2; 
            Instantiate(Cannon,new Vector2(4.65f,cannonY),Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
        yield return StartCoroutine("Pattern4");
    }
    IEnumerator Pattern4()
    {
        while (delta > 25f && delta < 35f)
        {
            yield return new WaitForSeconds(0.3f);
            Instantiate(thunder);
            yield return new WaitForSeconds(1f);
        }
        if(delta > 35f)
        {
            delta = 0;
            cannonY = 5f;
        }
    }

}
