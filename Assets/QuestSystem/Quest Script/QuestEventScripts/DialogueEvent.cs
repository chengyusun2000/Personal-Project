using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogueEvent", menuName = "QuestSystem/Events/DialogueEvent")]
public class DialogueEvent : QuestEventBase
{
    public string Name;
    public string Location;
    public List<Dialogue> dialogue;
    public bool AddDialogues = false;
    public void Awake()
    {
        eventType = EventType.Dialogue;
    }
}
