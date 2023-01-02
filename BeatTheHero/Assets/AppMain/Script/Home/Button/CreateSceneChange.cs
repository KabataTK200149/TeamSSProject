using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CreateSceneChange : MonoBehaviour,
    IPointerDownHandler
{

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        GManager.instance.sceneTag = GManager.GameSceneTag.CREATE;
        SceneManager.LoadScene("CreateMonster");
    }
}