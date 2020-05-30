using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Dialogue : ScriptableObject
{
    public enum DialogueType
    {
        normal,
        Quest,
        Quit
    }

    [TextArea(10,10)]
    public string dialogueText;
    public string ButtonText;
    public int NextID;
    public int PreviousID;
    public DialogueType Dtype;
    public WholeQuestBase quest;
}
