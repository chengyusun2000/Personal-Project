using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Default,
    Food,
    Weapon,
    Potion,
    Armor

}
public abstract class ItemObj : ScriptableObject
{
    
    public Image image;
    public GameObject SceneImage;
    public ItemType type;
    public int height;
    public int width;
    [TextArea(15, 20)]
    public string discription;
    
    
}
