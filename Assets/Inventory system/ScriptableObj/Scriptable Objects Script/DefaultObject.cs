using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="DefaultObject",menuName ="InventorySystem/Item/Default")]
public class DefaultObject : ItemObj
{
    public void Awake()
    {
        type = ItemType.Default;
    }

}
