using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject questInformation;
    [SerializeField] GameObject warningBox;
    public System.Action onClickCallback;

    /// <summary>
    /// ボタンを押されたら元の画面に戻る
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        if(GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN) //強化シーンにいるときは警告ページをfalseにする
        {
            warningBox.SetActive(false);
           
        }
   
            questInformation.SetActive(false);
 
    }
}
