using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtolSceneChange : MonoBehaviour,
    IPointerDownHandler
{

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
   
        SceneManager.LoadScene("BattleEntrance");
        
    }
}