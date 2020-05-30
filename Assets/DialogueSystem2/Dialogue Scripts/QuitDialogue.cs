using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuitDialogue", menuName = "DialogueSystem/QuitDialogue")]

public class QuitDialogue : Dialogue
{

    private void Awake()
    {
        Dtype = DialogueType.Quit;
    }


}
