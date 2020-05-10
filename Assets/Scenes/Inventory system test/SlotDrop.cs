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
    public void OnDrop(PointerEventData eventData)
    {
        ItemObj itemObj = eventData.pointerDrag.GetComponent<GetItemData>().GetItemObj();
        DropX = eventData.position.x;
        DropY = eventData.position.y;
        SlotX = (int)((DropX - 69.19995) / 80);
        SlotY = (int)((DropY - 262.7) / 80);
        if((DropX - 69.19995-80*SlotX) % 80>=40)
        {
            SlotX++;
        }
        if ((DropY - 262.7-80*SlotY) % 80>=40)
        {
            SlotY++;
        }
        
        Debug.Log(SlotX + "," + SlotY);
        

        for (int CheckX = SlotX; CheckX < itemObj.width + SlotX; CheckX++)
        {
            for (int CheckY = SlotY; CheckY < itemObj.height + SlotY; CheckY++)
            {
                if (inventory.slots[CheckX, CheckY].Occupied)
                {
                    Debug.Log("occ");
                    return;
                }
                else
                {
                    
                }
                Debug.Log(CheckX + "," + CheckY);

            }
        }

        float FloatWidth = itemObj.width;
        float FloatHeight = itemObj.height;
        float PositionX;
        float PositionY;
        Debug.Log(FloatWidth / 4);
        Debug.Log("www" + (FloatWidth - 1) / 2);
        if (inventory.OddOrEven(itemObj.width) == 0)
        {
            PositionX = (float)(69.19995 + 80 * (FloatWidth / 4) + 80 * SlotX);
            Debug.Log("sss" + PositionX);
        }
        else
        {
            PositionX = (float)(69.19995 + 80 * ((FloatWidth - 1) / 2) + 80 * SlotX);
            Debug.Log("sss" + PositionX);
        }


        if (inventory.OddOrEven(itemObj.height) == 0)
        {
            PositionY = (float)(262.7 + 80 * (FloatHeight / 4) + 80 * SlotY);
        }
        else
        {
            PositionY = (float)(262.7 + 80 * ((FloatHeight - 1) / 2) + 80 * SlotY);
        }



        eventData.pointerDrag.GetComponent<RectTransform>().position = new Vector2(PositionX, PositionY);






        //Debug.Log(PositionX + " " + PositionY);
        //for (int CheckX = x; CheckX < items.width + x; CheckX++)
        //{
        //    for (int CheckY = y; CheckY < items.height + y; CheckY++)
        //    {
        //        Debug.Log(CheckX + " " + CheckY);
        //        slots[CheckX, CheckY].Occupied = true;

        //    }
        //}


    }
}
