using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int[] position;
    public bool walkable;
    
    public Node parent;
    public int Gcost = int.MaxValue;
    public int Hcost;
    
    public Node(Vector3Int _position, bool _walkable)
    {
        position = new int[3];
        position[0] = _position.x;
        position[1] = _position.y;
        position[2] = _position.z;
        walkable = _walkable;
        

    }
    public int Fcost
    {
        get
        {
            return Gcost + Hcost;
        }
        
    }

}
