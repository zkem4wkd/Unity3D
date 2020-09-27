using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITER
using UnityEditorInternal;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource gameOver;
    SpriteRenderer portal;
    GameObject hpGauge;
    Camera mainCamera;
    public GameObject explosion;
    GameObject boss;
    public GameObject player;

    IEnumerator cour;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(445, 336, false);
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
        if(player.gameObject != enabled)
        {
            gameOver.enabled = true;
            bgm.enabled = false;
            boss.GetComponent<BossScript>().delta = 60;
        }
    }
   
}
