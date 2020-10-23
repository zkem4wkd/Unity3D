using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.WSA.Input;

public class TutorialStage : MonoBehaviour
{
    public List<Sprite> tutorialImage = new List<Sprite>();
    public Image textUI;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI nameText;
    public GameObject Background;
    public Image tImage;
    string[,] Sentence;
    int i = 0;
    public void Tutorial()
    {
        Background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        textUI.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void TutorialText()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("Tutorial");
        i++;
        if (i == 15)
        {
            textUI.gameObject.SetActive(false);
            i = 0;
            Time.timeScale = 1;
            Background.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);

        }
        mainText.text = data[i]["text"]+" ";
        tImage.sprite = tutorialImage[i-1];
    }
    // Start is called before the first frame update
    void Start()
    {
        textUI.gameObject.SetActive(false);
    }

}
