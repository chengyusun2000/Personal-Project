﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler
{
    private Canvas canvas;
    [SerializeField] private RectTransform ObjTransform;
    private CanvasGroup canvasGroup;
    private float DropX;
    private float DropY;
    [SerializeField] private int SlotX;
    [SerializeField] private int SlotY;
    [SerializeField] private Inventory inventory;
    private InventoryData inventoryData;
    [SerializeField] private Image Background;
    [SerializeField]private Transform InventoryI;
    private Transform PlayerTransform;
    public Vector2 OriginalPosition;
    private float MoveX;
    private float MoveY;
    private RectTransform BackRect;
    private ItemObj itemOnMOuse;

    [SerializeField] private List<Image> backgrounds;
    [SerializeField] private Image Panel;
    [SerializeField] private Image RightClick;
    private Transform InsPosition;
    private bool OnlyOnce = false;
    private bool Quit = true;
    private Image temp;
    public Image TempRight;
    private float time = 0f;
    private float Wait = 0.5f;
    private PointerEventData currentData;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("DontDestroyCanvas").GetComponent<Canvas>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Transform>();
        inventoryData = GameObject.FindGameObjectWithTag("GameData").GetComponent<InventoryData>();
        foreach(Transform child in GameObject.FindGameObjectWithTag("DontDestroyCanvas").GetComponentsInChildren<Transform>())
        {
            if (child.tag=="InventoryPanel")
            {
                inventory = child.GetComponent<Inventory>();
                InventoryI = child.Find("Inventory").GetComponent<Transform>();
            }
        }
        InsPosition = InventoryI.Find("Ins").GetComponent<Transform>();
        ObjTransform = transform.GetComponent<RectTransform>();
        canvasGroup = transform.GetComponent<CanvasGroup>();
       
    }

    private void Update()
    {
        if(!Quit)
        {
            time = time + Time.deltaTime;
            if(time>Wait&&!OnlyOnce)
            {
                
                temp = Instantiate(Panel,InsPosition.position,Quaternion.identity, InventoryI);
                temp.GetComponent<Discription>().SetItem(currentData.pointerEnter.GetComponent<GetItemData>().GetItemObj());
                OnlyOnce = true;
            }
        }
        else
        {
            time = 0;
        }

        //RemoveRightClick();

    }



    public void OnPointerEnter(PointerEventData eventData)
    {

        currentData = eventData;
        Quit = false;
        Debug.Log("Enter");
        
        
        
            
        
        


    }




    public void OnPointerExit(PointerEventData eventData)
    {
        Quit = true;
        if(temp!=null)
        {
            Destroy(temp.gameObject);
            
            OnlyOnce = false;
        }
        else
        {
            OnlyOnce = false;
        }
        
    }




    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
           
            TempRight = Instantiate(RightClick, eventData.position, Quaternion.identity, InventoryI);
            
            
        }
        else
        {
            
            OriginalPosition = transform.position;

            canvasGroup.alpha = 0.7f;
            canvasGroup.blocksRaycasts = false;
        }
        

    }




    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            IfSetSlotsOccupied(false, true);

            SetChild();
        }
    }




    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
        
    }




    public void OnDrag(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            MoveWithMouse(eventData);
            ObjTransform.anchoredPosition += eventData.delta / (5 * canvas.scaleFactor);
        }

    }




    public void OnPointerUp(PointerEventData eventData)
    {
        if(TempRight!=null)
        {
            TempRight.GetComponent<RightClickSet>().SetItem(eventData.pointerPress.GetComponent<GetItemData>().GetItemObj());
            TempRight.GetComponent<RightClickSet>().SetItemUI(eventData.pointerPress.GetComponent<Image>());
        }
        
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
            RemoveBackgrounds();
            OutRange(eventData);
        }
        
        
    }




    public void IfSetSlotsOccupied(bool set,bool IfSetBackground)
    {

        ItemObj itemObj = transform.GetComponent<GetItemData>().GetItemObj();
        itemOnMOuse = itemObj;
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
            //Debug.Log("sss" + PositionX);
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
        //Debug.Log(SlotX + "," + SlotY + "bug");
        for (int CheckX = SlotX; CheckX < itemObj.width + SlotX; CheckX++)
        {
            for (int CheckY = SlotY; CheckY < itemObj.height + SlotY; CheckY++)
            {
                
                inventory.slots[CheckX, CheckY].Occupied = set;
                //Debug.Log(CheckX + " " + CheckY + " " + inventory.slots[CheckX, CheckY].Occupied);
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



    




    public void OutRange(PointerEventData eventData)
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
        Debug.Log(SlotX + "de" + SlotY);
        if(SlotX<0||SlotY<0||SlotX>11||SlotY>7)
        {
            Instantiate(itemOnMOuse.SceneImage, PlayerTransform.position, Quaternion.identity);
            inventoryData.RemoveItem(itemOnMOuse);
            Destroy(gameObject);
        }
    }

    public void RemoveRightClick()
    {
        if(TempRight!=null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(TempRight.gameObject);
            }
        
        }
        
    }
    


    public Transform GetPlayerTransform()
    {
        return PlayerTransform;
    }
}
