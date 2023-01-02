using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject warningBox;
    

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        warningBox.SetActive(false);
        
    }

}
