using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using STRENGTHEN.SYSTEM;

/// <summary>
/// 注意勧告を表示して進化させていいなら進化させる
/// </summary>
public class EvolutionButton : MonoBehaviour,
    IPointerDownHandler
{
    public System.Action onClickCallback;

    EvolutionMonsterSet evolutionMonster = new EvolutionMonsterSet();

    [Header("進化をさせるぼたんならTrue・戻るボタンならFalse")] public bool create;

    [SerializeField] GameObject coutionObj;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad save;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (create)
        {
            save.saveMonsterDate(GManager.instance.selectMonsterNumber, characterLibrary.Monster[GManager.instance.selectMonsterNumber].name, characterLibrary.Monster[GManager.instance.selectMonsterNumber].evolutionLV + 1, characterLibrary.Monster[GManager.instance.selectMonsterNumber].type, characterLibrary.Monster[GManager.instance.selectMonsterNumber].LV, characterLibrary.Monster[GManager.instance.selectMonsterNumber].HP, characterLibrary.Monster[GManager.instance.selectMonsterNumber].STR, characterLibrary.Monster[GManager.instance.selectMonsterNumber].VIT, characterLibrary.Monster[GManager.instance.selectMonsterNumber].AGI, characterLibrary.Monster[GManager.instance.selectMonsterNumber].INT, characterLibrary.Monster[GManager.instance.selectMonsterNumber].skilPoint, characterLibrary.Monster[GManager.instance.selectMonsterNumber].XP, characterLibrary.Monster[GManager.instance.selectMonsterNumber].firstMove, characterLibrary.Monster[GManager.instance.selectMonsterNumber].secondMove, characterLibrary.Monster[GManager.instance.selectMonsterNumber].thirdMove, characterLibrary.Monster[GManager.instance.selectMonsterNumber].forceMove, characterLibrary.Monster[GManager.instance.selectMonsterNumber].fifthMove, characterLibrary.Monster[GManager.instance.selectMonsterNumber].firstSkill, characterLibrary.Monster[GManager.instance.selectMonsterNumber].secondSkill, evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1)), evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1)));

            SceneManager.LoadScene("HomeScene");
        }
        else
        {
            coutionObj.SetActive(false);
        }
    }
}
