using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �����ꂽ�����̃X�e�[�^�X���l��-1���鏈��
/// </summary
public class MinusButton : MonoBehaviour,
    IPointerDownHandler
{
    [Header("0HP,1STR,2VIT,3AGI,4INT")] public byte statusIdentificationNumber; //�ǂ̕����̃{�^���������ꂽ���𔻒肷��ϐ�
    [SerializeField] StatusPointBase statusPoint;
    [SerializeField] CharacterLibrary characterLibrary;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (statusIdentificationNumber == 0) // HP�����̃{�^���Ȃ�
        {
            if(GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.HPPoint, characterLibrary.Monster[statusPoint.monsterNumber].HP);
            }
            else if(GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.HPPoint, 10);
            }


            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.HPPoint--;
                statusPoint.HPcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 1) //STR�����̃{�^���Ȃ�
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.STRPoint, characterLibrary.Monster[statusPoint.monsterNumber].STR);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.STRPoint, 1);
            }
          

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.STRPoint--;
                statusPoint.STRcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 2) //VIT�����̃{�^���Ȃ�
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.VITPoint, characterLibrary.Monster[statusPoint.monsterNumber].VIT);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.VITPoint, 1);
            }

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.VITPoint--;
                statusPoint.VITcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 3) //AGI�����̃{�^���Ȃ�
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.AGIPoint, characterLibrary.Monster[statusPoint.monsterNumber].AGI);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.AGIPoint, 1);
            }
           

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.AGIPoint--;
                statusPoint.AGIcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }
        else if (statusIdentificationNumber == 4) //INT�����̃{�^���Ȃ�
        {
            if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
            {
                statusPoint.MinusOperation(statusPoint.INTPoint, characterLibrary.Monster[statusPoint.monsterNumber].INT);
            }
            else if (GManager.instance.sceneTag == GManager.GameSceneTag.CREATE)
            {
                statusPoint.MinusOperation(statusPoint.INTPoint, 1);
            }

            if (statusPoint.moderationSwitch) //moderationSwitch��true�Ȃ�
            {
                statusPoint.INTPoint--;
                statusPoint.INTcounterPoint--;
                statusPoint.moderationSwitch = false;
            }
        }


    }


}

