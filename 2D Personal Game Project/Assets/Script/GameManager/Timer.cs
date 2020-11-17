using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    GameController gC;
    int worldTime;
    float rotZ;
    Vector3 mousePos;
    private void Start()
    {
        gC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        worldTime = gC.worldTime;
        rotZ = (float)worldTime / 12 * 360f;
        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, rotZ);
    }
    public void clock()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 point = mousePos - this.GetComponent<RectTransform>().transform.position;
        GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, point.x *30f);
    }
}
