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
    public Vector2 OriginalPosition;

    private void Awake()
    {
        foreach(Transform child in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            if (child.tag=="InventoryPanel")
            {
                inventory = child.GetComponent<Inventory>();
            }
        }

        ObjTransform = transform.GetComponent<RectTransform>();
        canvasGroup = transform.GetComponent<CanvasGroup>();
       
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        OriginalPosition = transform.position;
        SetSlotsNoOccupied();
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

    }
    public void SetSlotsNoOccupied()
    {

        ItemObj itemObj = transform.GetComponent<GetItemData>().GetItemObj();
        float PositionX;
        float PositionY;
        float FloatWidth = itemObj.width;
        float FloatHeight = itemObj.height;
        DropX = transform.position.x;
        DropY = transform.position.y;
        if (inventory.OddOrEven(itemObj.width) == 0)
        {
            PositionX = (float)(DropX - 80 * (FloatWidth / 4) );
            Debug.Log("sss" + PositionX);
        }
        else
        {
            PositionX = (float)(DropX - 80 * ((FloatWidth - 1) / 2) );
            Debug.Log("sss" + PositionX);
        }


        if (inventory.OddOrEven(itemObj.height) == 0)
        {
            PositionY = (float)(DropY - 80 * (FloatHeight / 4));
        }
        else
        {
            PositionY = (float)(DropY - 80 * ((FloatHeight - 1) / 2) );
        }

        SlotX = (int)((PositionX - inventory.x ) / 80);
        SlotY = (int)((PositionY - inventory.y) / 80);
        Debug.Log(SlotX + "," + SlotY + "bug");
        for (int CheckX = SlotX; CheckX < itemObj.width + SlotX; CheckX++)
        {
            for (int CheckY = SlotY; CheckY < itemObj.height + SlotY; CheckY++)
            {
                if (inventory.slots[CheckX, CheckY].Occupied)
                {
                    inventory.slots[CheckX, CheckY].Occupied = false;
                    Debug.Log(CheckX + " " + CheckY + " " + inventory.slots[CheckX, CheckY].Occupied);
                }

                

            }
        }

        
    }
}
