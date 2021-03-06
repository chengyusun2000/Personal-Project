﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FindObjectEvent", menuName = "QuestSystem/Events/FindObjectEvent")]

public class FindObjectEvent : QuestEventBase
{
    public string ItemName;
    public int Amount;
    public int FinishedAmount;
    public void Awake()
    {
        eventType = EventType.FindObject;
    }
}
