using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ꂽ�����̃X�e�[�^�X���l��+1���鏈��
/// </summary
public class PlusButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //�ǂ̕����̃{�^���������ꂽ���𔻒肷��ϐ�
    [SerializeField] StatusPointBase statusPoint;

    public System.Action onClickCallback;


    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (statusIdentificationNumber == 0) //HP�����̃{�^���Ȃ�
        {
            statusPoint.PlusOperation(statusPoint.HPPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
    
                statusPoint.HPPoint++;
                statusPoint.HPcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR�����̃{�^���Ȃ�
        {
            statusPoint.PlusOperation(statusPoint.STRPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.STRPoint++;
                statusPoint.STRcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2)  //VIT�����̃{�^���Ȃ�
        {
            statusPoint.PlusOperation(statusPoint.VITPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.VITPoint++;
                statusPoint.VITcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3)  //AGI�����̃{�^���Ȃ�
        {
            statusPoint.PlusOperation(statusPoint.AGIPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.AGIPoint++;
                statusPoint.AGIcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT�����̃{�^���Ȃ�
        {
            statusPoint.PlusOperation(statusPoint.INTPoint);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.INTPoint++;
                statusPoint.INTcounterPoint++;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}
