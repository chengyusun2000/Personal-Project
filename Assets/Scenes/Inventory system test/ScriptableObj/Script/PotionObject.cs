using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PotionObject", menuName = "InventorySystem/Item/Potion")]

public class PotionObject : ItemObj
{
    public int HealthRestroe;
    public int ManaRestore;
    public void Awake()
    {
        type = ItemType.Potion;

    }

}
