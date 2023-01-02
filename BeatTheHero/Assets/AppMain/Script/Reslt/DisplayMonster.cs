using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMonster : MonoBehaviour
{
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;
    public Image imageMonster;
    private void Awake()
    {
        GameObject image_objectMonster = GameObject.Find("Image");
        imageMonster = imageMonster.GetComponent<Image>();

    }

    public void DisplayMonsters()
    {
        road.roadMonsterDate();

        characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSprite = Resources.Load(characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSpriteDateName) as Texture2D;
        imageMonster.sprite = Sprite.Create(characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSprite, new Rect(0, 0, characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSprite.width, characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSprite.height), Vector2.zero);
    }
   
}
