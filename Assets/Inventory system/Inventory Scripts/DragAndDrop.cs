using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler
{
    [SerializeField] private RectTransform ObjTransform;
    private CanvasGroup canvasGroup;
    private float DropX;
    private float DropY;
    [SerializeField] private int SlotX;
    [SerializeField] private int SlotY;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Image Background;
    [SerializeField]private Transform InventoryI;
    public Vector2 OriginalPosition;
    private float MoveX;
    private float MoveY;
    private RectTransform BackRect;
    
    [SerializeField] private List<Image> backgrounds;

    private void Awake()
    {
        foreach(Transform child in GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Transform>())
        {
            if (child.tag=="InventoryPanel")
            {
                inventory = child.GetComponent<Inventory>();
                InventoryI = child.Find("Inventory").GetComponent<Transform>();
            }
        }

        ObjTransform = transform.GetComponent<RectTransform>();
        canvasGroup = transform.GetComponent<CanvasGroup>();
       
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        OriginalPosition = transform.position;
        
        canvasGroup.alpha = 0.7f;
        canvasGroup.blocksRaycasts = false;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        IfSetSlotsOccupied(false,true);
        
        SetChild();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        
    }

    public void OnDrag(PointerEventData eventData)
    {


        MoveWithMouse(eventData);
        ObjTransform.anchoredPosition += eventData.delta/5;

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        RemoveBackgrounds();
        Debug.Log("mouse up");
    }
    public void IfSetSlotsOccupied(bool set,bool IfSetBackground)
    {

        ItemObj itemObj = transform.GetComponent<GetItemData>().GetItemObj();
        Debug.Log(itemObj.name);
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
                
                inventory.slots[CheckX, CheckY].Occupied = set;
                Debug.Log(CheckX + " " + CheckY + " " + inventory.slots[CheckX, CheckY].Occupied);
                if(IfSetBackground==true)
                {
                    PositionX = CheckX * 80 + inventory.x;
                    PositionY = CheckY * 80 + inventory.y;
                    backgrounds.Add(Instantiate(Background, new Vector3(PositionX, PositionY, 0), Quaternion.identity, InventoryI));


                }



            }
        }

        
    }


    
    public void SetChild()
    {
        if (backgrounds.Count>1)
        {
            for (int i = 1; i < backgrounds.Count; i++)
            {
               
                backgrounds[i].transform.SetParent(backgrounds[0].transform);
            }
        }
        BackRect = backgrounds[0].rectTransform;
    
        
    }


    public void MoveWithMouse(PointerEventData eventData)
    {

        DropX = eventData.position.x;
        DropY = eventData.position.y;
        SlotX = (int)((DropX - inventory.x) / 80);
        SlotY = (int)((DropY - inventory.y) / 80);
        
        if ((DropX - inventory.x - 80 * SlotX) % 80 >= 40)
        {
            SlotX++;
        }
        if ((DropY - inventory.y - 80 * SlotY) % 80 >= 40)
        {
            SlotY++;
        }
        MoveX = SlotX * 80 + inventory.x;
        MoveY = SlotY * 80 + inventory.y;
        //Debug.Log(SlotX + "," + SlotY + "setPos");
        BackRect.position = new Vector3(MoveX, MoveY, 0);
    }


    public void RemoveBackgrounds()
    {
        for (int i = 1; i < backgrounds.Count; i++)
        {

            backgrounds[i].transform.SetParent(InventoryI);
        }
        int counts = backgrounds.Count;
        for (int i=0;i<counts;i++)
        {
            Destroy(backgrounds[0].gameObject);
            backgrounds.RemoveAt(0);
        }
    }
}
