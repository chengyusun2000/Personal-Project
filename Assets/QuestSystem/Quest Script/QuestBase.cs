using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestBase // these are what a quest has, in a quest, we have a quest name, an index that we will use when we try to add a quest, a quest event list that contains some quest events(quest event is used to define what player needs to do in the quest)
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
    public List<QuestEventBase> NextEvent(QuestEventBase currentEvent)//it is used to get the next event
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
    public List<QuestEventBase>  FindFirstEvent()//it is used to find the first event
    {
        List<QuestEventBase> TempEvents = new List<QuestEventBase>();
        foreach (QuestEventBase questEvent in questEventBases)
        {
            if (questEvent.Index == 0)
            {
                TempEvents.Add(questEvent);
            }

        }
        return TempEvents;
    }
    public List<QuestEventBase> GetCurrentEvent(List<QuestEventBase> FirstEvent)//it is used to automatically find the current quest event(the "firstevent"needs to be the first event), which will be used when player is looking for the event he needs to do in a quest
    {
        bool IsFinished = false;
        
        
        for(int x=0;x< FirstEvent.Count;x++)
        {
            if(FirstEvent[x].Finished)
            {
                IsFinished = true;
            }
           
        }
        if(IsFinished)
        {
            FirstEvent = NextEvent(FirstEvent[0]);
            FirstEvent = GetCurrentEvent(FirstEvent);
        }
        return FirstEvent;




    }
}
