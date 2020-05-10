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

    public void OnDrop(PointerEventData eventData)
    {
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
        Debug.Log((DropX - 69.19995) % 80 + "     ,    " + (DropY - 262.7) % 80);
        Debug.Log(SlotX + "," + SlotY);
        
        
        
    }
}
