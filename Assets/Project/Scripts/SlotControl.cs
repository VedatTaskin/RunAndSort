using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotControl : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    
    public void OnDrop(PointerEventData eventData)
    {
        print("On Drop");

        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();

        if (draggable != null)
        {
            draggable.slotTransform = this.transform;
        }        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("On Pointer Enter"); ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("On Pointer Exit");
    }
}
