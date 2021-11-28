using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveImage : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        print("on begin drag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("on drag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("on end drag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("on pointer down");
    }

}
