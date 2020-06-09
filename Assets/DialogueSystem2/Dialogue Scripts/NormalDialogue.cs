﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogue", menuName = "DialogueSystem/Dialogue")]
public class NormalDialogue : Dialogue
{
    public bool IfStartAQuest;
    public void Awake()
    {
        Dtype = DialogueType.normal;
    }
}
