using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// ���͂������O�œo�^���đ��v���ǂ������₷��{�b�N�X��\��
/// </summary>
public class CreateCancelButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject chackBox;

    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData) //��������
    {
        chackBox.SetActive(false);
    }


}
