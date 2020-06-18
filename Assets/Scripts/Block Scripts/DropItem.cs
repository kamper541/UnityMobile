using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DropItem : MonoBehaviour, IDropHandler
{
    ItemIntel myInfo;
    public void OnDrop(PointerEventData eventData)
    {
        myInfo = gameObject.GetComponent<ItemIntel>();
        ItemIntel dropInfo = DragnDrop.itemBeingDragged.GetComponent<ItemIntel>();

        Image dropSprite = DragnDrop.itemBeingDragged.GetComponent<Image>();
        gameObject.GetComponent<Button>().image.sprite = dropSprite.sprite;

        myInfo.itemID = dropInfo.itemID;
        myInfo.myName = dropInfo.myName;
        myInfo.spriteID = dropInfo.spriteID;
        myInfo.name = dropInfo.name;
        

        //gameObject.AddComponent<DragnDrop>();

        Destroy(DragnDrop.itemBeingDragged);
        DragnDrop.itemBeingDragged = null;
    }

    public void clear(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
