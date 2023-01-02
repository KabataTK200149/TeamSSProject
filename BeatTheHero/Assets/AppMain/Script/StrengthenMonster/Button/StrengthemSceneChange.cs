using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StrengthemSceneChange : MonoBehaviour,
    IPointerDownHandler
{
    [Header("�{�^���������Ȃ�1�A�L�����ꗗ�Ȃ�2�A�X�L���Z�b�g�Ȃ�3�A�i���Ȃ�4")] public int selectBottonNo;
    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(selectBottonNo == 1)
        {
            GManager.instance.sceneTag = GManager.GameSceneTag.STRENGTHEN;
            SceneManager.LoadScene("StrengthenScene");
        }
        else if (selectBottonNo == 4)
        {
            GManager.instance.sceneTag = GManager.GameSceneTag.EVOLUTION;
            SceneManager.LoadScene("EvolutionScene");
        }


    }
}