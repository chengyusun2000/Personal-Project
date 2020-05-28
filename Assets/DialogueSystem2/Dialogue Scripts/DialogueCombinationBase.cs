using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogueCombinationBase 
{
    public string Name;
    public int DID;
    public List<Dialogue> dialogues;
    

    public DialogueCombinationBase(List<Dialogue> _dialogues, int _did,string _name)
    {
        Name = _name;
        DID = _did;
        dialogues = _dialogues;
        
        
    }
        




}
