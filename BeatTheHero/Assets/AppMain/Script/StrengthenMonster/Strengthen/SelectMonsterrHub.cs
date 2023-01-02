using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラクタ育成でのキャラクタステータスの表示
/// </summary>
public class SelectMonsterrHub : MonoBehaviour
{
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;
    [SerializeField] StatusPointBase pointBase;
    [SerializeField] XPBar xpBar;

    [SerializeField] GameObject characterPointBox; //表示するGameObject
    [SerializeField] GameObject experience;  //XPバーのgameobject取得

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text TypeText;
    [SerializeField] Text XPText;
    [SerializeField] Text HPText;
    [SerializeField] Text STRText;
    [SerializeField] Text VITText;
    [SerializeField] Text AGIText;
    [SerializeField] Text INTText;



    private void Update()
    {

        if (GManager.instance.statusBarPush && GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
        {
            DecisionStrengthenMonster(GManager.instance.selectMonsterNumber);

            //スキル制御ボックスを表示させるboolの初期化
            GManager.instance.statusBarPush = false;
        }
       
    }

    /// <summary>
    /// キャラクタ育成におけるキャラクタ情報表示処理
    /// </summary>
    /// <param name="i"></param>
    public void DecisionStrengthenMonster(int i)
    {
        road.roadMonsterDate();
        

        nameText.text = characterLibrary.Monster[i].name;
        levelText.text = ($"{characterLibrary.Monster[i].LV.ToString()}/99");
        TypeText.text = characterLibrary.Monster[i].type.ToString();
        xpBar.SetXPSmooth(characterLibrary.Monster[i].LV, characterLibrary.Monster[i].XP, experience);

        pointBase.skillPoint = characterLibrary.Monster[i].skilPoint;
        pointBase.HPPoint = characterLibrary.Monster[i].HP;
        pointBase.STRPoint = characterLibrary.Monster[i].STR;
        pointBase.VITPoint = characterLibrary.Monster[i].VIT;
        pointBase.AGIPoint = characterLibrary.Monster[i].AGI;
        pointBase.INTPoint = characterLibrary.Monster[i].INT;

        characterPointBox.SetActive(true);

    }
}
