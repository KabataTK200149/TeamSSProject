using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using STRENGTHEN.SYSTEM;

/// <summary>
/// 進化先に選択したモンスターに進化するための条件を表示する
/// </summary>
public class SelectEvolutionMonsterButton : MonoBehaviour,
    IPointerDownHandler
{
    public System.Action onClickCallback;

    EvolutionMonsterSet evolutionMonster = new EvolutionMonsterSet();

    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] ItemDataBase itemData;
    [SerializeField] GameObject verificationScreen;
    [SerializeField] Image originalMonsterImage;
    [SerializeField] Image evolutionMonsterImage;
    [SerializeField] Text lvText;
    [SerializeField] Text AbilityText;
    [SerializeField] Text ItemText;

    public void OnPointerDown(PointerEventData eventData)
    {
        
            GManager.instance.conditionNotClear = false;

            //進化前のモンスターを表示
            originalMonsterImage.sprite = Sprite.Create((Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D), new Rect(0, 0, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).width, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).height), Vector2.zero);

            //進化後のモンスターを表示
            evolutionMonsterImage.sprite = Sprite.Create((Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D), new Rect(0, 0, (Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D).width, (Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D).height), Vector2.zero);

            //進化後のモンスターのイメージの色を黒にする
            evolutionMonsterImage.color = new Color32(0, 0, 0, 255);

            lvText.text = evolutionMonster.LVStringSetting(characterLibrary); //レベルテキスト変更
            AbilityText.text = evolutionMonster.AbilityStringSetting(characterLibrary); //ステータステキスト変更
            ItemText.text = evolutionMonster.ItemStringSetting(itemData); //アイテムテキスト変更

            if (!evolutionMonster.LVCheck(characterLibrary))
            {
                lvText.color = new Color32(122, 122, 122, 255); //条件未達成の色（灰色)
                GManager.instance.conditionNotClear = true;
            }

            if (!evolutionMonster.AbilityCheck(characterLibrary))
            {
                AbilityText.color = new Color32(122, 122, 122, 255); //条件未達成の色（灰色)
                GManager.instance.conditionNotClear = true;
            }

            if (!evolutionMonster.ItemCheck())
            {
                ItemText.color = new Color32(122, 122, 122, 255); //条件未達成の色（灰色)
                GManager.instance.conditionNotClear = true;
            }

            verificationScreen.SetActive(true);
 

    }



}



