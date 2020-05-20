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
public abstract class QuestEventBase :ScriptableObject// this script is used to define elements that a quest event needs
{
    public int Index;
    public bool Finished=false;
    public EventType eventType;
    public Vector3 QuestDestination;
    [TextArea(10,10)]
    public string Discription;

}
