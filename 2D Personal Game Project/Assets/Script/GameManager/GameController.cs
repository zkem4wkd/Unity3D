using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    SaveData data;
    string filePath = string.Empty;
    int maxWorldTime = 24;
    public int worldTime;
    // Start is called before the first frame update
    private void Awake()
    {
        worldTime = 6;
    }
    void Start()
    {
        filePath = Application.dataPath + "/Uk.bin";
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
        
    }
}
