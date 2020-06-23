using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler,IPointerExitHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop to ...");

        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        // if(d != null){
        //     d.parentToReturnTo = this.transform;
        // }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Exit");
    }

    // Start is called before the first frame update

}
