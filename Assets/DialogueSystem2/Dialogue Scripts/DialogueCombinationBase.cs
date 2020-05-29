using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueCombinationBase 
{
    [TextArea(10, 10)]
    public string StartText;
    public string Name;
    public int DID;
    public List<Dialogue> dialogues;
    

    public DialogueCombinationBase(List<Dialogue> _dialogues, int _did,string _name,string _text)
    {
        Name = _name;
        DID = _did;
        dialogues = _dialogues;
        StartText = _text;
        
        
    }
        




}
