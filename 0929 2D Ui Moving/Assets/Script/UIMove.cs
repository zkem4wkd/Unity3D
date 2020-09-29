using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(uiMoving());

        gameObject.transform.position = new Vector2(-20, 0);
    }
    IEnumerator uiMoving()
    {
        for(int a = 0; a < 500; a++)
        {
            float Distance = Vector2.Distance(gameObject.transform.position, Vector2.zero);
            if(Distance > 0.1f)
            {
                gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, Vector2.zero,2.5f * Time.deltaTime);
            }
            if(Distance <= 0.1f)
            {
                gameObject.transform.position = Vector2.zero;
                break;
            }

            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(1.5f);
        for(int b = 0; b < 500; b++)
        {
            float Distance = Vector2.Distance(gameObject.transform.position,new Vector2(30,0));
            if(Distance > 0.1f)
            {
                gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, new Vector2(30, 0), 2.5f * Time.deltaTime);
            }
            if(Distance < 0.5f)
            {

                Destroy(this.gameObject);
                StopCoroutine(uiMoving());
            }
            yield return new WaitForSeconds(0.005f);
        }
    }
    
}