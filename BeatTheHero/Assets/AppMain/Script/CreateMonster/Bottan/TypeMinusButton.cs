using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TypeMinusButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] NumericalBase numericalBase;

    public System.Action onClickCallback;


    // タップダウン  
    public void OnPointerDown(PointerEventData eventData)
    {
        numericalBase.TypeSelectAnimationMinus();
    }


}