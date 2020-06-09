using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        ItemIntel myInfo = gameObject.GetComponent<ItemIntel>();
        ItemIntel dropInfo = DragnDrop.itemBeingDragged.GetComponent<ItemIntel>();

        Image dropSprite = DragnDrop.itemBeingDragged.GetComponent<Image>();
        gameObject.GetComponent<Button>().image.sprite = dropSprite.sprite;

        myInfo.itemID = dropInfo.itemID;
        myInfo.myName = dropInfo.myName;
        myInfo.spriteID = dropInfo.spriteID;
        myInfo.name = dropInfo.name;

        Destroy(DragnDrop.itemBeingDragged);
        DragnDrop.itemBeingDragged = null;
    }
}
