using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DDTest : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static public GameObject itemBeingDragged;
    static public ItemIntel tmpinfo;
    public void OnBeginDrag(PointerEventData eventData)
    {
        GameObject duplicate = Instantiate(gameObject);
        itemBeingDragged = duplicate;
        RectTransform tmpRT = gameObject.GetComponent<RectTransform>();

        RectTransform rt = itemBeingDragged.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(tmpRT.sizeDelta.x , tmpRT.sizeDelta.y);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        tmpinfo = GetComponent<ItemIntel>();
        Transform canvas = GameObject.FindWithTag("UI Canvas").transform;
        // Transform zone = GameObject.FindWithTag("Drop").transform;
        // itemBeingDragged.transform.SetParent(zone);
        // zone.GetComponentInChildren<Button>().name = "newBlock";
        itemBeingDragged.transform.SetParent(canvas);
        itemBeingDragged.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeingDragged.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
         Destroy(DragnDrop.itemBeingDragged);
         DragnDrop.itemBeingDragged = null;
    }

}
