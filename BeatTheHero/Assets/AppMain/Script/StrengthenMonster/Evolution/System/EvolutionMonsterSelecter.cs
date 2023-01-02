using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 進化画面の時に選択された進化先にチェックマークを表示する
/// </summary>
public class EvolutionMonsterSelecter : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject checkMark; //チェックマークが書かれたGameObject
    public int monsterOrdar { get; set; } //進化先の個別番号：生成時に確定される
 
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
