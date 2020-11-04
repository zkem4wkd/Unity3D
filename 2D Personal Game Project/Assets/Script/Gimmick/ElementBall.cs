using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ElementBall : MonoBehaviour
{
    Transform tPlayer;
    public Image btnImg;
    public Button btn;
    public TextMeshProUGUI coolDown;
    float coolTime;
    public Button rockBall;
    public GameObject elementRock;
    public GameObject elementWind;
    public GameObject elementWater;
    public GameObject elementFire;
    public Button waterBall;
    public Button fireBall;
    public Button windBall;
    Vector2 pos;
    RaycastHit2D rHit;
    bool clickOn = false;

    public void ElementOn()
    {
        clickOn = true;
    }

    public void RockElement()
    {
        tPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameObject rock = Instantiate(elementRock, new Vector2(tPlayer.transform.position.x,tPlayer.transform.position.y - 1), Quaternion.identity);
        Destroy(rock, 3.5f);
        rockBall.gameObject.SetActive(false);
        CoolTime();
    }
    public void WindElement()
    {
        GameObject wind = Instantiate(elementWind);
        Destroy(wind, 3f);
        windBall.gameObject.SetActive(false);
        CoolTime();
    }
    public void WaterElement()
    {
        tPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameObject water = Instantiate(elementWater,tPlayer.transform.position,Quaternion.identity);
        tPlayer.gameObject.SetActive(false);
        CinemachineVirtualCamera vCam = GameObject.Find("vcam").GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = water.transform;
        StartCoroutine(waterDelay(tPlayer, vCam, water));
        waterBall.gameObject.SetActive(false);
        CoolTime();
    }
    IEnumerator waterDelay(Transform player, CinemachineVirtualCamera vCam,GameObject water)
    {
        yield return new WaitForSeconds(6f);
        player.gameObject.SetActive(true);
        player.transform.position = water.transform.position;
        vCam.Follow = tPlayer;
        Destroy(water);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && clickOn == true)
        {
            clickOn = false;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rHit = Physics2D.Raycast(pos, Vector2.zero);
            if(rHit.collider.CompareTag("Land"))
            {
                rockBall.gameObject.SetActive(true);
            }
            else if (rHit.collider.CompareTag("Water"))
            {
                waterBall.gameObject.SetActive(true);
            }
            else if (rHit.collider.CompareTag("Fire"))
            {
                fireBall.gameObject.SetActive(true);
            }
            else if (rHit.collider.CompareTag("Wind"))
            {
                windBall.gameObject.SetActive(true);
            }
        }
    }
    public void CoolTime()
    {
        coolDown.gameObject.SetActive(true);
        coolTime = 15f;
        btnImg.fillAmount = 0;
        btn.enabled = false;
        StartCoroutine(cool(coolTime));
    }
    IEnumerator cool(float coolTime)
    {
        while (coolTime > 1f)
        {
            coolTime -= Time.deltaTime;
            btnImg.fillAmount = (1.0f / coolTime);
            coolDown.text = coolTime.ToString("N1");
            yield return new WaitForFixedUpdate();
            if (coolTime <= 1)
            {
                btnImg.fillAmount = 1;
                btn.enabled = true;
                coolDown.gameObject.SetActive(false);
                break;
            }
        }
    }
}
