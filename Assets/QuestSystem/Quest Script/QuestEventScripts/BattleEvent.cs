using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterType
{
    Slime,
    Wolf,
    Goblin
}
[CreateAssetMenu(fileName = "BattleEvent", menuName = "QuestSystem/Events/BattleEvent")]
public class BattleEvent : QuestEventBase
{
    public void Awake()
    {
        eventType = EventType.Combat;
    }
    public int Number;
    public MonsterType monsterType;

}

