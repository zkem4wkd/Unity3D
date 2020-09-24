using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject score;
    float time = 60.0f;
    int point = 0;

    GameObject generator;
    public void getApple()
    {
        point += 100;
    }
    public void getBomb()
    {
        point /= 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Time");
        score = GameObject.Find("Score");
        generator = GameObject.Find("ItemGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timerText.GetComponent<Text>().text = time.ToString("F1");
        score.GetComponent<Text>().text = point.ToString("F1");

        if(this.time < 0)
        {
            time = 0;
            generator.GetComponent<ItemGenerator>().setParameter(10000.0f,0,0);
        }
        else if(time >= 5 && time < 10)
        {
            generator.GetComponent<ItemGenerator>().setParameter(0.5f, -0.04f, 5);
        }
        else if (time >= 10 && time < 20)
        {
            generator.GetComponent<ItemGenerator>().setParameter(0.7f, -0.04f, 4);
        }
        else if (time >= 20 && time < 30)
        {
            generator.GetComponent<ItemGenerator>().setParameter(0.3f, -0.04f, 3);
        }
    }
}
