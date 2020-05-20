using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SlotDrop : MonoBehaviour, IDropHandler
{
    private float DropX;
    private float DropY;
    [SerializeField]private int SlotX;
    [SerializeField] private int SlotY;
    [SerializeField] private Inventory inventory;
    [SerializeField] bool SetToOriginal = true;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag != "InventoryPanel")
        {
            ItemObj itemObj = eventData.pointerDrag.GetComponent<GetItemData>().GetItemObj();
            DragAndDrop dragAndDrop = eventData.pointerDrag.GetComponent<DragAndDrop>();
            DropX = eventData.position.x;
            DropY = eventData.position.y;
            SlotX = (int)((DropX - inventory.x) / 80);
            SlotY = (int)((DropY - inventory.y) / 80);
            //Debug.Log(SlotX + "," + SlotY);
            if ((DropX - inventory.x - 80 * SlotX) % 80 >= 40)
            {
                SlotX++;
            }
            if ((DropY - inventory.y - 80 * SlotY) % 80 >= 40)
            {
                SlotY++;
            }

            Debug.Log(SlotX + "," + SlotY + "setPos");


            if ((inventory.Width - SlotX < itemObj.width) || (inventory.length - SlotY < itemObj.height))
            {
                Debug.Log("out of range");
                SetOriginal(itemObj, dragAndDrop, eventData);

                return;
            }
            for (int CheckX = SlotX; CheckX < itemObj.width + SlotX; CheckX++)
            {
                for (int CheckY = SlotY; CheckY < itemObj.height + SlotY; CheckY++)
                {
                    if (inventory.slots[CheckX, CheckY].Occupied)
                    {
                        Debug.Log("occ");

                        SetOriginal(itemObj, dragAndDrop, eventData);
                        return;
                    }



                }
            }
            if (!SetToOriginal)
            {

                float FloatWidth = itemObj.width;
                float FloatHeight = itemObj.height;
                float PositionX;
                float PositionY;
                Debug.Log(FloatWidth / 4);
                Debug.Log("www" + (FloatWidth - 1) / 2);
                if (inventory.OddOrEven(itemObj.width) == 0)
                {
                    PositionX = (float)(inventory.x + 80 * (FloatWidth / 4) + 80 * SlotX);

                }
                else
                {
                    PositionX = (float)(inventory.x + 80 * ((FloatWidth - 1) / 2) + 80 * SlotX);

                }


                if (inventory.OddOrEven(itemObj.height) == 0)
                {
                    PositionY = (float)(inventory.y + 80 * (FloatHeight / 4) + 80 * SlotY);
                }
                else
                {
                    PositionY = (float)(inventory.y + 80 * ((FloatHeight - 1) / 2) + 80 * SlotY);
                }



                eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(PositionX, PositionY);
                for (int CheckX = SlotX; CheckX < itemObj.width + SlotX; CheckX++)
                {
                    for (int CheckY = SlotY; CheckY < itemObj.height + SlotY; CheckY++)
                    {
                        inventory.slots[CheckX, CheckY].Occupied = true;
                        Debug.Log(CheckX + " " + CheckY + " " + inventory.slots[CheckX, CheckY].Occupied);

                    }
                }


            }
        }
    
        
    
        



    }
    
    public void SetOriginal(ItemObj itemObj, DragAndDrop dragAndDrop, PointerEventData eventData)
    {
        float PositionX;
        float PositionY;
        float FloatWidth = itemObj.width;
        float FloatHeight = itemObj.height;
        DropX = dragAndDrop.OriginalPosition.x;
        DropY = dragAndDrop.OriginalPosition.y;
        eventData.pointerDrag.GetComponent<RectTransform>().position = dragAndDrop.OriginalPosition;
        if (inventory.OddOrEven(itemObj.width) == 0)
        {
            PositionX = (float)(DropX - 80 * (FloatWidth / 4));
            Debug.Log("sss" + PositionX);
        }
        else
        {
            PositionX = (float)(DropX - 80 * ((FloatWidth - 1) / 2));
            Debug.Log("sss" + PositionX);
        }


        if (inventory.OddOrEven(itemObj.height) == 0)
        {
            PositionY = (float)(DropY - 80 * (FloatHeight / 4));
        }
        else
        {
            PositionY = (float)(DropY - 80 * ((FloatHeight - 1) / 2));
        }

        SlotX = (int)((PositionX - inventory.x-80) / 80);
        SlotY = (int)((PositionY - inventory.y-80) / 80);
        SetToOriginal = true;
        for (int x = SlotX; x < itemObj.width + SlotX; x++)
        {
            for (int y = SlotY; y < itemObj.height + SlotY; y++)
            {
                inventory.slots[x, y].Occupied = true;
                Debug.Log(x + " " + y + " " + inventory.slots[x, y].Occupied);

            }
        }
        SetToOriginal = false;
    }
    
}
