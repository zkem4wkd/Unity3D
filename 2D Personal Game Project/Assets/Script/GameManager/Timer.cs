using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameController gC;
    int worldTime;
    float rotZ ,angle;
    float eulerZ;
    Vector2 mousePos, target;
    bool nowAm;
    int time;
    private void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        target = transform.position;
        worldTime = gC.worldTime;
        rotZ = (float)worldTime / 12 * 360f;
        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, rotZ);
        eulerZ = transform.eulerAngles.z;
        nowAm = gC.Am;
    }
    public void clock()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mousePos.y - target.y, mousePos.x - target.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        PlusTime();
    }
    void PlusTime()
    {
        if(eulerZ < transform.eulerAngles.z)
        {
            time = (int)(Mathf.Abs(transform.eulerAngles.z) / 30);
            Debug.Log(time);
        }
    }
}
