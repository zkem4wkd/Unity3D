using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestSystem : MonoBehaviour
{
    public Text QuestText;

    public void UnLockQuest(string title)
    {
        Debug.Log("퀘스트 성공 -" + title);
        QuestText.text = "쿼스트 성공 : " + title;
    }
}
