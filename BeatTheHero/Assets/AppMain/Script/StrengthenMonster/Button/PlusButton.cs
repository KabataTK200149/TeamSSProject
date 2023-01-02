using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 押された部分のステータス数値を+1する処理
/// </summary
public class PlusButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //どの部分のボタンが押されたかを判定する変数
    [SerializeField] StatusPointBase statusPoint;

    public System.Action onClickCallback;


    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (statusIdentificationNumber == 0) //HP部分のボタンなら
        {
            statusPoint.PlusOperation(statusPoint.HPPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
    
                statusPoint.HPPoint++;
                statusPoint.HPcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR部分のボタンなら
        {
            statusPoint.PlusOperation(statusPoint.STRPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.STRPoint++;
                statusPoint.STRcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2)  //VIT部分のボタンなら
        {
            statusPoint.PlusOperation(statusPoint.VITPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.VITPoint++;
                statusPoint.VITcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3)  //AGI部分のボタンなら
        {
            statusPoint.PlusOperation(statusPoint.AGIPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.AGIPoint++;
                statusPoint.AGIcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT部分のボタンなら
        {
            statusPoint.PlusOperation(statusPoint.INTPoint);

            if (statusPoint.moderationSwitch) //moderationSwitchがtrueなら
            {
                statusPoint.INTPoint++;
                statusPoint.INTcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}
