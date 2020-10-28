using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data : MonoBehaviour
{
    int Hp = 100;
    int StageHp = 0; 
    void Save()
    {
        PlayerPrefs.SetInt("체력", Hp);
    }
    // Start is called before the first frame update
    void Start()
    {
        StageHp = PlayerPrefs.GetInt("체력", Hp);
        Debug.Log(StageHp);
    }
    private void Awake()
    {
        Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
