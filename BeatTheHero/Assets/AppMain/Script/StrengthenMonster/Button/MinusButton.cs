using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 押された部分のステータス数値を-1する処理
/// </summary
public class MinusButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //どの部分のボタンが押されたかを判定する変数
    [SerializeField] StatusPointBase statusPoint;
    [SerializeField] CharacterLibrary characterLibrary;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (statusIdentificationNumber == 0) // HP部分のボタンなら
        {
            if(GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.HPPoint, characterLibrary.Monster[statusPoint.monsterNumber].HP);
            }
            else if(GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.HPPoint, 10);
            }


            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.HPPoint--;
                statusPoint.HPcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR部分のボタンなら
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.STRPoint, characterLibrary.Monster[statusPoint.monsterNumber].STR);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.STRPoint, 1);
            }
          

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.STRPoint--;
                statusPoint.STRcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2) //VIT部分のボタンなら
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.VITPoint, characterLibrary.Monster[statusPoint.monsterNumber].VIT);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.VITPoint, 1);
            }

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.VITPoint--;
                statusPoint.VITcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3) //AGI部分のボタンなら
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.AGIPoint, characterLibrary.Monster[statusPoint.monsterNumber].AGI);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.AGIPoint, 1);
            }
           

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.AGIPoint--;
                statusPoint.AGIcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT部分のボタンなら
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.INTPoint, characterLibrary.Monster[statusPoint.monsterNumber].INT);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.INTPoint, 1);
            }

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.INTPoint--;
                statusPoint.INTcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}

