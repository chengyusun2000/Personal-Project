using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Slots 
{
    public bool Occupied = false;
    //public bool Background = false;
    public int Width = 80;
    public int Length = 80;
    
    public Slots(bool _occ/*,bool _back*/)
    {
        Occupied = _occ;
        //Background = _back;
        
    }
   
}
