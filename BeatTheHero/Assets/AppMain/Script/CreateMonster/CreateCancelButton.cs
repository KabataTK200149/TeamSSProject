using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// 入力した名前で登録して大丈夫かどうか質問するボックスを表示
/// </summary>
public class CreateCancelButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject chackBox;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData) //押したら
    {
        chackBox.SetActive(false);
    }


}
