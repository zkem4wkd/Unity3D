using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCoolTime : MonoBehaviour
{
    public Image btnImg;
    public Button btn;
    float coolTime;

    public void CoolTime()
    {
        coolTime = 6f;
        btnImg.fillAmount = 0;
        btn.enabled = false;
        StartCoroutine(cool(coolTime));
    }
    IEnumerator cool(float coolTime)
    {
        while(coolTime > 1f)
        {
            coolTime -= Time.deltaTime;
            btnImg.fillAmount = (1.0f / coolTime);
            yield return new WaitForFixedUpdate();
            if (coolTime <= 1)
            {
                btnImg.fillAmount = 1;
                btn.enabled = true;
                break;
            }
        }
    }
}
