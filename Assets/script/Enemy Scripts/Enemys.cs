using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys
{
    
    public string Name;
    public string Type;
    public float MoveSpeed;
    public int DetectRadius;
    


    public Enemys(string _name,string _type,float _speed,int _radius)
    {
        Name = _name;
        Type = _type;
        MoveSpeed = _speed;
        DetectRadius = _radius;
    }
}
