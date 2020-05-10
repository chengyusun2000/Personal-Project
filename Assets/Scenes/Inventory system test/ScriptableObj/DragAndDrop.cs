using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    [SerializeField] private RectTransform ObjTransform;
    private CanvasGroup canvasGroup;
    private float DropX;
    private float DropY;
    [SerializeField] private int SlotX;
    [SerializeField] private int SlotY;
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        ObjTransform = transform.GetComponent<RectTransform>();
        canvasGroup = transform.GetComponent<CanvasGroup>();
       
    }


    public void OnPointerDown(PointerEventData eventData)
    {
       
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        ObjTransform.anchoredPosition += eventData.delta/5;
        DropX = eventData.position.x;
        DropY = eventData.position.y;
        SlotX = (int)((DropX - 69.19995) / 80);
        SlotY = (int)((DropY - 262.7) / 80);
        if ((DropX - 69.19995 - 80 * SlotX) % 80 >= 40)
        {
            SlotX++;
        }
        if ((DropY - 262.7 - 80 * SlotY) % 80 >= 40)
        {
            SlotY++;
        }
    }
}
