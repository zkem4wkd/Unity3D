using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GameController : MonoBehaviour
{
    SaveData data;
    string filePath = string.Empty;
    int maxWorldTime = 24;
    public int worldTime;
    public bool Am = true;
    public Sprite afternoonSky;
    public Sprite eveningSky;
    public Sprite nightSky;
    public Light2D freedom;
    public GameObject[] npc;
    private void Awake()
    {
        filePath = Application.dataPath + "/Uk.bin";
        Save();
        Load();
    }
    public void Save()
    {
        data = new SaveData(worldTime);
        SaveSystem.Save(data, filePath);
        Debug.Log("save" + worldTime);
    }
    public void Load()
    {
        data = SaveSystem.Load(filePath);
        worldTime = data.worldTime;
        Debug.Log("load" + worldTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(worldTime > 6 && worldTime <= 17)
        {
            Am = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = afternoonSky;
            transform.GetChild(1).GetComponent<Light2D>().intensity = 1;
            for (int i = 0; i < npc.Length; i++)
            {
                npc[i].gameObject.SetActive(true);
            }
        }
        else if(worldTime > 17 && worldTime < 20)
        {
            Am = true;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = eveningSky;
            transform.GetChild(1).GetComponent<Light2D>().intensity = 0.7f;
        }
        else if (worldTime >= 20 || worldTime <= 6)
        {
            Am = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = nightSky;
            transform.GetChild(1).GetComponent<Light2D>().intensity = 0.5f;
            for(int i = 0; i < npc.Length; i ++)
            {
                npc[i].gameObject.SetActive(false);
            }
        }
    }
}
