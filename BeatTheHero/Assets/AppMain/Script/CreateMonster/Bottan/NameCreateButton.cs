using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NameCreateButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject chackBox;
    [SerializeField] GameObject nameChackBox;
    [SerializeField] CreateMonsterName monsterName;

    [SerializeField] Text text;

    public System.Action onClickCallback;


    public void OnPointerDown(PointerEventData eventData)
    { 
        if(monsterName.nameKeep == "")
        {
            nameChackBox.SetActive(true);
        }
        else
        {
            text.text = monsterName.nameKeep;
            chackBox.SetActive(true);
        }
        
    }
}
