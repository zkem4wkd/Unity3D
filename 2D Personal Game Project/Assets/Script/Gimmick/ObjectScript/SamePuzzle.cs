using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamePuzzle : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer big;
    int i = 0;
    Sprite tSprite;
    public bool texture;
    private void Start()
    {
        big = GameObject.Find("BigOne").GetComponent<SpriteRenderer>();
    }
    public void Click()
    {
        tSprite = this.GetComponent<Image>().sprite = sprites[i];
        i++;
        if(big.sprite == tSprite)
        {
            texture = true;
        }
        else
        {
            texture = false;
        }
        if(i == 5)
        {
            i = 0;
        }
    }
}
