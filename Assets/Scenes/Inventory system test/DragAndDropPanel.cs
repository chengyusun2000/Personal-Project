using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDropPanel : MonoBehaviour, IPointerDownHandler,IDragHandler,IEndDragHandler,IBeginDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform RectTransform;
    public void Awake()
    {
        RectTransform = transform.GetComponent<RectTransform>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

}
