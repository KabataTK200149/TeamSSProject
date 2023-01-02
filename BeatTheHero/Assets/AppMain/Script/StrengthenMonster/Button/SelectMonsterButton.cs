using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Battle.Entry;
using UnityEngine.UI;

/// <summary>
/// �����X�^�[�̏���\�����鎞�̏���
/// </summary>
public class SelectMonsterButton : MonoBehaviour,
    IPointerDownHandler
{

    public int monsterNumber { get; set; }
    bool toggle;

    CheckBoxController checkBoxController = new CheckBoxController();
    [SerializeField] CharacterLibrary characterLibrary;
    public System.Action onClickCallback;

    void Start()
    {
        GManager.instance.battleMonsterNunber = 0;
    }

    void Update()
    {
       if(GManager.instance.sceneTag == GManager.GameSceneTag.BATTLE)
       {
            checkBoxController.SurveillanceCheckBox(this.gameObject, toggle);
       }
            
    }

    /// <summary>
    /// �L�����N�^�琬��ʂɂ����đI�����������X�^�ɉ���������\�����鏈��
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
        {
            GManager.instance.selectMonsterNumber = monsterNumber;
            GManager.instance.statusBarPush = true; //�����X�^�[�������ꂽ�Ƃ��ɕ\��������̂�����Ε\������
        }

        if (GManager.instance.sceneTag == GManager.GameSceneTag.BATTLE && GManager.instance.battleMonsterNunber == 0 && !toggle)
        {
            toggle = true;
            checkBoxController.OnToggleChanged(monsterNumber, toggle);
           
        }
        else if (GManager.instance.sceneTag == GManager.GameSceneTag.BATTLE && GManager.instance.battleMonsterNunber != 0 && toggle)
        {
            toggle = false;
            checkBoxController.OnToggleChanged(monsterNumber, toggle);
        }

        if(GManager.instance.sceneTag == GManager.GameSceneTag.EVOLUTION)
        {
                GManager.instance.selectMonsterNumber = monsterNumber;
                GManager.instance.statusBarPush = true;
            
         
        }

    }


}




