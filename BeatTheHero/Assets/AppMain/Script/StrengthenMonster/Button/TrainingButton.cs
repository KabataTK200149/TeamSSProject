using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrainingButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject warningBox;
    [SerializeField] GameObject characterPointBox; //表示するGameObject
    [SerializeField] StatusPointBase statusPoint;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad saveAndRoad;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        saveAndRoad.saveMonsterDate(GManager.instance.selectMonsterNumber, characterLibrary.Monster[statusPoint.monsterNumber].name, characterLibrary.Monster[statusPoint.monsterNumber].evolutionLV,  characterLibrary.Monster[statusPoint.monsterNumber].type, characterLibrary.Monster[statusPoint.monsterNumber].LV, statusPoint.HPPoint, statusPoint.STRPoint, statusPoint.VITPoint, statusPoint.AGIPoint, statusPoint.INTPoint, statusPoint.skillPoint, characterLibrary.Monster[statusPoint.monsterNumber].XP, characterLibrary.Monster[statusPoint.monsterNumber].firstMove, characterLibrary.Monster[statusPoint.monsterNumber].secondMove, characterLibrary.Monster[statusPoint.monsterNumber].thirdMove, characterLibrary.Monster[statusPoint.monsterNumber].forceMove, characterLibrary.Monster[statusPoint.monsterNumber].fifthMove, characterLibrary.Monster[statusPoint.monsterNumber].firstSkill, characterLibrary.Monster[statusPoint.monsterNumber].secondSkill, characterLibrary.Monster[statusPoint.monsterNumber].frontSpriteDateName, characterLibrary.Monster[statusPoint.monsterNumber].backSpriteDateName);

        //音をのちに入れたい
        warningBox.SetActive(false);
        characterPointBox.SetActive(false);

        saveAndRoad.roadMonsterDate();

        //スキルポイントカウンタの初期化
        statusPoint.HPcounterPoint = 0;
        statusPoint.STRcounterPoint = 0;
        statusPoint.VITcounterPoint = 0;
        statusPoint.AGIcounterPoint = 0;
        statusPoint.INTcounterPoint = 0;

       

    }

}
