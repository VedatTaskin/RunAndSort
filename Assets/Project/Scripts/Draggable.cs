using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public Transform slotTransform;
    public GameObject placeHolder;
    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        print("On Begin Drag");
        placeHolder.SetActive(true);
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .5f;
        this.transform.SetParent(this.transform.root);
    }


    public void OnDrag(PointerEventData eventData)
    {
        print("On Drag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("On End Drag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        this.transform.SetParent(slotTransform);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        placeHolder.SetActive(false);
    }
}
