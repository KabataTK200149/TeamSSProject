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

    //�A�C�e���̎��
    [SerializeField]
    private KindOfItem kindOfItem;
    //�A�C�e���̉摜
    [SerializeField]
    private Sprite icon;
    //�A�C�e���̖��O
    [SerializeField]
    private string itemName;
    //�A�C�e���̏��
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
