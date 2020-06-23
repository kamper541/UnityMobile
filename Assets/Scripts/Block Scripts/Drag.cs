using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    public Transform parentToReturnTo = null;

    static public GameObject itemBeingDragged;

    public static bool dragged = false;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragged = true;
        GameObject duplicate = Instantiate(gameObject);
        itemBeingDragged = duplicate;
        RectTransform tmpRT = gameObject.GetComponent<RectTransform>();

        RectTransform rt = itemBeingDragged.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(tmpRT.sizeDelta.x , tmpRT.sizeDelta.y);

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        parentToReturnTo = this.transform.parent;
        Transform canvas = GameObject.FindWithTag("UI Canvas").transform;
        itemBeingDragged.transform.SetParent(canvas);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        itemBeingDragged.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Destroy(DragnDrop.itemBeingDragged);
        //  DragnDrop.itemBeingDragged = null;
        //this.transform.SetParent(parentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Transform canvas = GameObject.FindWithTag("Drop").transform;
        itemBeingDragged.transform.SetParent(canvas);
        Destroy(DragnDrop.itemBeingDragged);
        Drag.itemBeingDragged = null;
        dragged = false;
    }
}
