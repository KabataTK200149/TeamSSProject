using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ItemDataBase", menuName ="CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
    [SerializeField]
    private List<ItemData> itemLists = new List<ItemData>();

    public List<ItemData> GetItemDataList()
    {
        return itemLists;
    }
}
