using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StreamSave : MonoBehaviour
{
    public string strData = "";
    string path = "";
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/mySaveData.txt";
        TFSave();
    }

    public void TFSave()
    {
        StreamWriter sw = new StreamWriter(path);
        strData = "캐릭터 이름";
        sw.WriteLine(strData);
        sw.Flush();
        sw.Close();
    }
    public void TFLoad()
    {
        StreamReader sr = File.OpenText(path);
        string readStr = "";

        readStr = sr.ReadLine();

        strData = readStr;

        Debug.Log(strData);
        sr.Close();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
