using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ꂽ�����̃X�e�[�^�X���l��+10���鏈��
/// </summary
public class PlusTenButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //�ǂ̕����̃{�^���������ꂽ���𔻒肷��ϐ�
    [SerializeField] StatusPointBase statusPoint;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(statusIdentificationNumber == 0) //HP�����̃{�^���Ȃ�
        {
            statusPoint.PlusTenOperation(statusPoint.HPPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.HPPoint += 10;
                statusPoint.HPcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR�����̃{�^���Ȃ�
        {
            statusPoint.PlusTenOperation(statusPoint.STRPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.STRPoint += 10;
                statusPoint.STRcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2)  //VIT�����̃{�^���Ȃ�
        {
            statusPoint.PlusTenOperation(statusPoint.VITPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.VITPoint += 10;
                statusPoint.VITcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3) //AGI�����̃{�^���Ȃ�
        {
            statusPoint.PlusTenOperation(statusPoint.AGIPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.AGIPoint += 10;
                statusPoint.AGIcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT�����̃{�^���Ȃ�
        {
            statusPoint.PlusTenOperation(statusPoint.INTPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.INTPoint += 10;
                statusPoint.INTcounterPoint += 10;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}
