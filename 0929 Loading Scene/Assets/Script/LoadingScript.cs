using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    [SerializeField]
    Slider s;
    [SerializeField]
    Text mainText;
    [SerializeField]
    public Text percent;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Async());
    }
    IEnumerator Async()
    {
        yield return null;
        AsyncOperation AO = SceneManager.LoadSceneAsync("LoadingScene");
        AO.allowSceneActivation = false; // 정보를 다 받아온 후 대기

        while(!AO.isDone)
        {
            yield return null;
            if(s.value<1f)
            {
                s.value = Mathf.MoveTowards(s.value,1f,Time.deltaTime);
                mainText.text = "Now Loading";
                percent.text = "loading..." + s.value.ToString() + "%";
            }
            else
            {
                mainText.text = "Press Space Key";
                percent.text = "Loading Complete";
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && s.value >= 1f && AO.progress >= 1f)
        {
            AO.allowSceneActivation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
