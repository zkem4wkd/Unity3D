using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTarget : MonoBehaviour
{
    public List<Collider> targetList;
    // Start is called before the first frame update
    void Start()
    {
        targetList = new List<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        targetList.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        targetList.Remove(other);
    }
}
