using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ArmorObject", menuName = "InventorySystem/Item/Armor")]
public class ArmorObject : ItemObj
{
    public int Defence;
    public int Health;
    public int Mana;
    public void Awake()
    {
        type = ItemType.Armor;
    }
}
