using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FoodObject", menuName = "InventorySystem/Item/Food")]
public class FoodObject : ItemObj
{
    public int HealthRestore;
    public int ManaRestore;
    public int HungerRestore;
    public void Awake()
    {
        type = ItemType.Food;
        

    }
}
