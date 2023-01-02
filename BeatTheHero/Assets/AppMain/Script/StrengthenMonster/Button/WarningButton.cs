using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WarningButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject warningBox;
    [SerializeField] GameObject characterPointBox; //•\Ž¦‚·‚éGameObject
    [SerializeField] StatusPointBase statusPoint;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad saveAndRoad;

    public Toggle toggle;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (toggle.isOn)
        {
            saveAndRoad.saveMonsterDate(GManager.instance.selectMonsterNumber, characterLibrary.Monster[statusPoint.monsterNumber].name, characterLibrary.Monster[statusPoint.monsterNumber].evolutionLV, characterLibrary.Monster[statusPoint.monsterNumber].type, characterLibrary.Monster[statusPoint.monsterNumber].LV, statusPoint.HPPoint, statusPoint.STRPoint, statusPoint.VITPoint, statusPoint.AGIPoint, statusPoint.INTPoint, statusPoint.skillPoint, characterLibrary.Monster[statusPoint.monsterNumber].XP, characterLibrary.Monster[statusPoint.monsterNumber].firstMove, characterLibrary.Monster[statusPoint.monsterNumber].secondMove, characterLibrary.Monster[statusPoint.monsterNumber].thirdMove, characterLibrary.Monster[statusPoint.monsterNumber].forceMove, characterLibrary.Monster[statusPoint.monsterNumber].fifthMove, characterLibrary.Monster[statusPoint.monsterNumber].firstSkill, characterLibrary.Monster[statusPoint.monsterNumber].secondSkill, characterLibrary.Monster[statusPoint.monsterNumber].frontSpriteDateName, characterLibrary.Monster[statusPoint.monsterNumber].backSpriteDateName);

            //‰¹‚ð‚Ì‚¿‚É“ü‚ê‚½‚¢
            warningBox.SetActive(false);
            characterPointBox.SetActive(false);

            saveAndRoad.roadMonsterDate();

            statusPoint.HPcounterPoint = 0;
            statusPoint.STRcounterPoint = 0;
            statusPoint.VITcounterPoint = 0;
            statusPoint.AGIcounterPoint = 0;
            statusPoint.INTcounterPoint = 0;
        }
        else
        {
            warningBox.SetActive(true);
        }
       


    }

}
