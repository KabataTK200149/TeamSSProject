using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RewardsBuutton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] QuestSystem questSystem;
    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        questSystem.RewardsOnTrigger();
    }
}


