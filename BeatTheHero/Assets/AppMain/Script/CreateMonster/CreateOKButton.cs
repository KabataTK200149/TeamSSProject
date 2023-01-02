using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.IO;
using MonsterCreat;

/// <summary>
/// 入力した名前で良いならデータをセーブしてバトルシーンへ移動
/// </summary>
public class CreateOKButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] GameObject chackBox;
    [SerializeField] SkillSorting skillSorting;
    [SerializeField] CreateMonsterName monsterName;
    [SerializeField] SaveAndRoad save;
    //[SerializeField] MonsterCreatDirection monsterCreat;

    public System.Action onClickCallback;
    MonsterCreat.Selection.ImageSelection imageSelection = new MonsterCreat.Selection.ImageSelection();

    /// <summary>
    /// クリエイトしたデータを保存
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {

        GManager.instance.monsterNumber++;

        save.saveMonsterDate(GManager.instance.monsterNumber, monsterName.nameKeep, 1, GManager.instance.characterType, 1, GManager.instance.monsterDate[1], GManager.instance.monsterDate[2], GManager.instance.monsterDate[3], GManager.instance.monsterDate[4], GManager.instance.monsterDate[5], GManager.instance.monsterDate[6], 0, skillSorting.move1, skillSorting.move2, skillSorting.move3, skillSorting.move4, skillSorting.move5, skillSorting.skill1, skillSorting.skill2, imageSelection.CharacterSelection(), imageSelection.CharacterSelection());

        save.savePlayerDate();

        GManager.instance.monsterDate[1] = 0;
        GManager.instance.monsterDate[2] = 0;
        GManager.instance.monsterDate[3] = 0;
        GManager.instance.monsterDate[4] = 0;
        GManager.instance.monsterDate[5] = 0;
        GManager.instance.monsterDate[6] = 0;
        GManager.instance.monsterDate[7] = 0;

        SceneManager.LoadScene("HomeScene");
        chackBox.SetActive(false);
 
    }

}