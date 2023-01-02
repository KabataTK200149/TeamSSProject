using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject questInformation;
    [SerializeField] GameObject warningBox;
    public System.Action onClickCallback;

    /// <summary>
    /// �{�^���������ꂽ�猳�̉�ʂɖ߂�
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN) //�����V�[���ɂ���Ƃ��͌x���y�[�W��false�ɂ���
        {
            warningBox.SetActive(false);
           
        }
   
            questInformation.SetActive(false);
 
    }
}
