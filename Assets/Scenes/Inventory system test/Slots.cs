using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Slots 
{
    public bool Occupied = false;
    //public float x;
    //public float y;
    public int Width = 80;
    public int Length = 80;
    
    public Slots(bool _occ/*float _x,float _y*/)
    {
        Occupied = _occ;
        //x = _x;
        //y = _y;
        
    }
   
}
