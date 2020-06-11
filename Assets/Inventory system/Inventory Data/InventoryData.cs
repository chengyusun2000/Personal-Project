using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    [SerializeField]private List<ItemObj> items;
    private CurrentQuests currentQuests;
    private QuestEventBase EventToBeRemoved;
    // Start is called before the first frame update
    void Start()
    {
        currentQuests = transform.GetComponent<CurrentQuests>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddItems(ItemObj item)
    {
        bool IfRemove = false;
        foreach (QuestEventBase questEvent in currentQuests.GetEvents())
        {
            if (questEvent.eventType == EventType.FindObject)
            {
                FindObjectEvent findObjectEvent = (FindObjectEvent)questEvent;
                if (findObjectEvent.ItemName == item.ItemName)
                {
                    findObjectEvent.FinishedAmount++;
                    if (findObjectEvent.FinishedAmount >= findObjectEvent.Amount)
                    {
                        IfRemove = true;
                        EventToBeRemoved = findObjectEvent;
                    }


                }
            }

        }
        if(IfRemove)
        {
            currentQuests.RemoveQuestEvent(EventToBeRemoved);
        }

        items.Add(item);
       
    }
    public void RemoveItem(ItemObj item)
    {
        foreach (QuestEventBase questEvent in currentQuests.GetEvents())
        {
            if (questEvent.eventType == EventType.FindObject)
            {
                FindObjectEvent findObjectEvent = (FindObjectEvent)questEvent;
                if (findObjectEvent.ItemName == item.ItemName)
                {

                    findObjectEvent.FinishedAmount--;


                }
            }

        }
        items.Remove(item);
        
    }
    public List<ItemObj> GetItems()
    {
        return items;
    }
}
