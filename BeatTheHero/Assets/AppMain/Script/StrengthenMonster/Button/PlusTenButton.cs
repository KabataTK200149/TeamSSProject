using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 押された部分のステータス数値を+10する処理
/// </summary
public class PlusTenButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //どの部分のボタンが押されたかを判定する変数
    [SerializeField] StatusPointBase statusPoint;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(statusIdentificationNumber == 0) //HP部分のボタンなら
        {
            statusPoint.PlusTenOperation(statusPoint.HPPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.HPPoint += 10;
                statusPoint.HPcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR部分のボタンなら
        {
            statusPoint.PlusTenOperation(statusPoint.STRPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.STRPoint += 10;
                statusPoint.STRcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2)  //VIT部分のボタンなら
        {
            statusPoint.PlusTenOperation(statusPoint.VITPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.VITPoint += 10;
                statusPoint.VITcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3) //AGI部分のボタンなら
        {
            statusPoint.PlusTenOperation(statusPoint.AGIPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.AGIPoint += 10;
                statusPoint.AGIcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT部分のボタンなら
        {
            statusPoint.PlusTenOperation(statusPoint.INTPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.INTPoint += 10;
                statusPoint.INTcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}
