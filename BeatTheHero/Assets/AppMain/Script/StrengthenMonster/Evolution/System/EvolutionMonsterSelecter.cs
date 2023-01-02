using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// �i����ʂ̎��ɑI�����ꂽ�i����Ƀ`�F�b�N�}�[�N��\������
/// </summary>
public class EvolutionMonsterSelecter : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject checkMark; //�`�F�b�N�}�[�N�������ꂽGameObject
    public int monsterOrdar { get; set; } //�i����̌ʔԍ��F�������Ɋm�肳���
 
    public System.Action onClickCallback;

    void Update()
    {
        if(GManager.instance.
            evolutionNumber != monsterOrdar)
        {
            checkMark.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GManager.instance.evolutionNumber != monsterOrdar)
        {
            checkMark.SetActive(true);
            GManager.instance.evolutionNumber = monsterOrdar;
        }
    }

}
