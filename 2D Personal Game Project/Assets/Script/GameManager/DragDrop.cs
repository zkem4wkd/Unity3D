using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    Vector2 firstPos;
    public GameObject slateObj;
    public GameObject cloneSlate;
    public void OnBeginDrag(PointerEventData eventData)
    {
        firstPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Image target = this.GetComponent<Image>();
        if (target.color == new Color(1f, 1f, 1f, 1f))
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0);
        if(hit.collider.gameObject.CompareTag("Tower"))
        {
            TowerCount pScript = GameObject.Find("GameController").GetComponent<TowerCount>();
            Vector2 target = hit.collider.transform.position;
            Image slate = this.GetComponent<Image>();
            slate.color = new Color(0, 0, 0);
            transform.position = firstPos;
            pScript.count++;
            cloneSlate = Instantiate(slateObj, new Vector2(target.x, target.y + 1f), Quaternion.identity);
        }
        else if(hit.collider != null)
        {
            transform.position = firstPos;
        }
    }
}
