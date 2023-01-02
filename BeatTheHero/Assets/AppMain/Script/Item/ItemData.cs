using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class ItemData : ScriptableObject
{

    public enum KindOfItem
    {
        Evolution,
        Skill,
    }

    //アイテムの種類
    [SerializeField]
    private KindOfItem kindOfItem;
    //アイテムの画像
    [SerializeField]
    private Sprite icon;
    //アイテムの名前
    [SerializeField]
    private string itemName;
    //アイテムの情報
    [SerializeField]
    private string information;

    public KindOfItem GetKindOfItem()
    {
        return kindOfItem;
    }

    public Sprite GetSprite()
    {
        return icon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemInformation()
    {
        return information;
    }
}
