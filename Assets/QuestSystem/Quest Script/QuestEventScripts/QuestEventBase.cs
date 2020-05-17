using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EventType
{
    Dialogue,
    Combat,
    FindObject,
    ReachDestination
}
public abstract class QuestEventBase :ScriptableObject
{
    public int Index;
    public bool Finished=false;
    public EventType eventType;
    [TextArea(10,10)]
    public string Discription;

}
