using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotControl : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        print("On Drop");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().position = 
                GetComponent<RectTransform>().position;
        }        
    }
}
