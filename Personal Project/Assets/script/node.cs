using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class node 
{
    public int[] position;
    public bool walkable;
    public string type;
    public node parent;
    public int Gcost=int.MaxValue;
    public int Hcost;
    public float weight;
    public node(Vector3Int _position, bool _walkable,string _type,float _weight)
    {
        position = new int[3];
        position[0] = _position.x;
        position[1] = _position.y;
        position[2] = _position.z;
        walkable = _walkable;
        type = _type;
        weight = _weight;

    }
    public int Fcost
    {
        get
        {
            return Gcost + (int)(Hcost*weight);
        }
    }
    
    
    
}
