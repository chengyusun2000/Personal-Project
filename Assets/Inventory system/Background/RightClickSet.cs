using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class RightClickSet : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private bool InPanel = false;
    private ItemObj item;
    private Image ItemUI;
    private PlayerInfo playerInfo;
    private DragAndDrop dragAndDrop;
    private InventoryData inventoryData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        InPanel = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InPanel = false;
    }



    private void Start()
    {
        inventoryData= GameObject.FindGameObjectWithTag("GameData").GetComponent<InventoryData>();
        playerInfo = GameObject.FindGameObjectWithTag("GameData").GetComponent<PlayerInfo>();
        
    }


    // Update is called once per frame
    void Update()
    {
        if(!InPanel)
        {
            if(Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
    }



    public void SetItem(ItemObj itemObj)
    {
        item = itemObj;
    }


    public void SetItemUI(Image image)
    {
        ItemUI = image;
    }



    public void Use()
    {
        dragAndDrop = ItemUI.gameObject.GetComponent<DragAndDrop>();
        if (item.type==ItemType.Food)
        {
            FoodObject food = (FoodObject)item;
            playerInfo.AddHp(food.HealthRestore);
            playerInfo.AddMana(food.ManaRestore);
            playerInfo.AddStanima(food.HungerRestore);
            dragAndDrop.IfSetSlotsOccupied(false, false);
            inventoryData.RemoveItem(item);
            Destroy(ItemUI.gameObject);
            Debug.Log("Used");
            Destroy(gameObject);
            
        }
    }
}
