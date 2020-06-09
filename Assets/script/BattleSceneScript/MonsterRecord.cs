using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRecord : MonoBehaviour
{
    public Dictionary<MonsterType, int> dictionary = new Dictionary<MonsterType, int>();
    public int Wolf;
    private CurrentQuests currentQuests;
    private QuestEventBase events;
    // Start is called before the first frame update
    void Start()
    {
        dictionary.Add(MonsterType.Slime, 0);
        dictionary.Add(MonsterType.Wolf, 0);
        currentQuests = transform.GetComponent<CurrentQuests>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAmount(MonsterType monsterType)
    {
        int value = dictionary[monsterType];
        bool IfRemove = false;
        
        value++;
        dictionary[monsterType] = value;
        foreach(QuestEventBase questEvent in currentQuests.GetEvents())
        {
            if(questEvent.eventType==EventType.Combat)
            {
                BattleEvent battle = (BattleEvent)questEvent;
                if(battle.monsterType==monsterType)
                {
                    battle.FinishedNumber++;
                    if (battle.Number<=battle.FinishedNumber)
                    {
                        IfRemove = true;
                        events = battle;
                    }
                    
                    
                }
            }
        }

        if(IfRemove)
        {
            currentQuests.RemoveQuestEvent(events);
        }

    }
}
