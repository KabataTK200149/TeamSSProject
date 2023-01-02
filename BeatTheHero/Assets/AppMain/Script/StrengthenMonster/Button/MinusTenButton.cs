using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ꂽ�����̃X�e�[�^�X���l��-10���鏈��
/// </summary>
public class MinusTenButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //�ǂ̕����̃{�^���������ꂽ���𔻒肷��ϐ�
    [SerializeField] StatusPointBase statusPoint;
    [SerializeField] CharacterLibrary characterLibrary;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (statusIdentificationNumber == 0) //HP�����̃{�^���Ȃ�
        {
            statusPoint.MinusTenOperation(statusPoint.HPPoint, characterLibrary.Monster[statusPoint.monsterNumber].HP);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.HPPoint -= 10;
                statusPoint.HPcounterPoint -= 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR�����̃{�^���Ȃ�
        {
            statusPoint.MinusTenOperation(statusPoint.STRPoint, characterLibrary.Monster[statusPoint.monsterNumber].STR);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.STRPoint -= 10;
                statusPoint.STRcounterPoint -= 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2) //VIT�����̃{�^���Ȃ�
        {
            statusPoint.MinusTenOperation(statusPoint.VITPoint, characterLibrary.Monster[statusPoint.monsterNumber].VIT);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.VITPoint -= 10; 
                statusPoint.VITcounterPoint -= 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3) //AGI�����̃{�^���Ȃ�
        {
            statusPoint.MinusTenOperation(statusPoint.AGIPoint, characterLibrary.Monster[statusPoint.monsterNumber].AGI);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.AGIPoint -= 10;
                statusPoint.AGIcounterPoint -= 10;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT�����̃{�^���Ȃ�
        {
            statusPoint.MinusTenOperation(statusPoint.INTPoint, characterLibrary.Monster[statusPoint.monsterNumber].INT);

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.INTPoint -= 10;
                statusPoint.INTcounterPoint -= 10;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}
