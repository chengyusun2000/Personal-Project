using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AddQuestDialogue", menuName = "DialogueSystem/AddQuestDialogue")]
public class AddQuestDialogue : Dialogue
{
    private void Awake()
    {
        Dtype = DialogueType.Quest;
    }
    
    
}
