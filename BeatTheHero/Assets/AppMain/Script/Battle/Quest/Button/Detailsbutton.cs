using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Detailsbutton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] QuestSystem questSystem;
    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        questSystem.DetailsOnTrigger();
    }
}
