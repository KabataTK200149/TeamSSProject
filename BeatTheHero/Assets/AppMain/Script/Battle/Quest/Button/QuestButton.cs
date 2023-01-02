using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// クエストバーを押したときの動き
/// </summary>
public class QuestButton : MonoBehaviour,
    IPointerDownHandler
{

    public int questNumber { get; set; }
    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        GManager.instance.selectQuestNumber = questNumber;
        GManager.instance.conditionNotClear = true;

    }

}
