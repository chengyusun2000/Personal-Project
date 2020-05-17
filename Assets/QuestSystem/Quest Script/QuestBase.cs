using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestBase 
{
    public string QuestName;
    public int Index;
    public List<QuestEventBase> questEventBases;
    [TextArea(15, 20)]
    public string Discription;
    
    public QuestBase(int _index,string _discription, List<QuestEventBase> _questEventBases)
    {
        Index = _index;

        Discription = _discription;
        questEventBases = _questEventBases;
    }
    public List<QuestEventBase> NextEvent(QuestEventBase currentEvent)
    {
        int NewIndex = currentEvent.Index + 1;
        List<QuestEventBase> TempEvents = new List<QuestEventBase>();
        foreach(QuestEventBase questEvent in questEventBases)
        {
            if(NewIndex==questEvent.Index)
            {
                Debug.Log("1");
                TempEvents.Add(questEvent);
            }
           
        }
        return TempEvents;
    }
    public QuestEventBase FindFirstEvent()
    {
        foreach (QuestEventBase questEvent in questEventBases)
        {
            if (questEvent.Index == 0)
            {
                return questEvent;
            }

        }
        return null;
    }
}
