using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CurrentQuests : MonoBehaviour
{
    [SerializeField] private List<QuestBase> Current;
    [SerializeField] private List<QuestBase> Finished;
    [SerializeField] private List<QuestEventBase> CurrentEvents;
    [SerializeField] private Button button;
    private QuestBase Temp;
    [SerializeField]private List<Button> Buttons;
    private InventoryData inventoryData;
    //[SerializeField] private QuestsList questsList;
    
    public Transform QuestList;
    // Start is called before the first frame update
    void Start()
    {
        inventoryData = transform.GetComponent<InventoryData>();
        //AddQuestToQuestList();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void AddQuest(QuestBase NewQuest)
    {
        Current.Add(NewQuest);
        foreach (QuestEventBase questEvent in NewQuest.GetCurrentEvent(NewQuest.FindFirstEvent()))
        {
            CurrentEvents.Add(questEvent);
        }
        AddQuestToQuestList();
    }



    public void MoveQuestToFinishend(QuestBase FinishedQuest)
    {
        int Index = new int();
        Current.Remove(FinishedQuest);
        Finished.Add(FinishedQuest);
        foreach(Button botton in Buttons)
        {
            if(button.transform.GetComponent<GetDiscription>().GetQuest() == FinishedQuest)
            {
                Index = Buttons.IndexOf(button);
            }
        }
        Buttons[Index].transform.GetComponent<GetDiscription>().GetText().text = "";
        Destroy(Buttons[Index].gameObject);
        Buttons.RemoveAt(Index);
    }



    public void AddQuestToQuestList()
    {
        
        GetDiscription getDiscription;
        foreach (QuestBase questBase in Current)
        {
            Buttons.Add( Instantiate(button, QuestList));
            
            Buttons[Buttons.Count-1].transform.GetChild(0).GetComponent<Text>().text = questBase.QuestName;
            getDiscription = Buttons[Buttons.Count - 1].transform.GetComponent<GetDiscription>();
            getDiscription.SetQuest(questBase);
        }
    }



    public void SetCurrentEvents()
    {
        bool IfMove = false;
        foreach (QuestBase quest in Current)
        {

            if(quest.GetCurrentEvent(quest.FindFirstEvent()).Count==0)
            {
                Temp = quest;
                IfMove = true;
            }
            else
            {
                foreach (QuestEventBase questEvent in quest.GetCurrentEvent(quest.FindFirstEvent()))
                {

                    if (!CurrentEvents.Contains(questEvent))
                    {
                        if(questEvent.eventType==EventType.FindObject)
                        {
                            FindObjectEvent findObjectEvent = (FindObjectEvent)questEvent;
                            foreach(ItemObj item in inventoryData.GetItems())
                            {
                                if(item.ItemName==findObjectEvent.ItemName)
                                {
                                    findObjectEvent.FinishedAmount++;
                                }
                            }

                            if(findObjectEvent.FinishedAmount>=findObjectEvent.Amount)
                            {
                                
                                RemoveQuestEvent(findObjectEvent);
                            }
                            else
                            {
                                CurrentEvents.Add(questEvent);
                            }
                        }
                        else
                        {
                            CurrentEvents.Add(questEvent);
                        }

                        

                    }

                }
            }
            
        }
        if(IfMove)
        {
            MoveQuestToFinishend(Temp);
            
        }
    }



    public List<QuestEventBase> GetEvents()
    {
        return CurrentEvents;
    }


    public void RemoveQuestEvent(QuestEventBase questEvent)
    {
        List<QuestEventBase> Index = new List<QuestEventBase>();
        //int i = 0;
        //while(i<CurrentEvents.Count)
        //{
        //    if (Event.Index == questEvent.Index)
        //    {
        //        Event.Finished = true;
        //        CurrentEvents.Remove(questEvent);
        //    }
        //}
        foreach(QuestEventBase Event in CurrentEvents)
        {
            if(Event.Index==questEvent.Index)
            {
                Event.Finished = true;
                Index.Add(Event);
            }
        }
        int Number = Index.Count;
        for (int i = 0; i < Number; i++)
        {
            
            CurrentEvents.Remove(Index[0]);
            Index.RemoveAt(0);
        }

        SetCurrentEvents();
    }



}
