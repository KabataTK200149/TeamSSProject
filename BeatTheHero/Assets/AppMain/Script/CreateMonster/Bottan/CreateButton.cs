using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreateButton : MonoBehaviour,
    IPointerDownHandler
{
    //[SerializeField] MonsterBase monsterStatus;
    [SerializeField] NumericalBase numericalBase;
    [SerializeField] StatusPointBase pointBase;
    [SerializeField] private CanvasGroup _canvasGroup;
    public System.Action onClickCallback;
    
    //Createƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«‚Ìˆ—
    public void OnPointerDown(PointerEventData eventData)
    {
        
        GManager.instance.monsterDate[1] = pointBase.HPPoint;
        GManager.instance.monsterDate[2] = pointBase.STRPoint;
        GManager.instance.monsterDate[3] = pointBase.VITPoint;
        GManager.instance.monsterDate[4] = pointBase.AGIPoint;
        GManager.instance.monsterDate[5] = pointBase.INTPoint;
        GManager.instance.monsterDate[6] = pointBase.skillPoint;
        GManager.instance.monsterDate[7] = numericalBase.typeNumber;

        SceneManager.LoadScene("CreateDecisionMonster");

    }
}
