using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{

    SpriteRenderer portal;
    GameObject hpGauge;
    Camera mainCamera;
    public GameObject explosion;
    GameObject boss;
    IEnumerator cour;
    // Start is called before the first frame update
    void Start()
    {
        hpGauge = GameObject.Find("BossHp");
        boss = GameObject.Find("Boss");
        portal = GameObject.Find("ClearPortal").GetComponent<SpriteRenderer>();
    }

    public void HpDecrease()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.005f;
    }
    // Update is called once per frame
    void Update()
    {
        if (hpGauge.GetComponent<Image>().fillAmount <= 0)
        {
            portal.color = new Color(255, 255, 255, 255);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
}
