using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MonsterBoxUpButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] GameObject MonsterBox;
    [SerializeField] CharacterLibrary library;
    public System.Action onClickCallback;

    Vector2 initialPos;
    public bool startUpJudgement;

    private void Start()
    {
        startUpJudgement = false;

        if(library.Monster.Length <= 4)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!startUpJudgement)
        {
            initialPos = (new Vector2(MonsterBox.transform.localPosition.x, MonsterBox.transform.localPosition.y));
            MonsterBox.transform.DOLocalMoveY(-104, 2f);
            startUpJudgement = true;

        }
        else
        {
            MonsterBox.transform.DOLocalMoveY(initialPos.y, 2f);
            startUpJudgement = false;
        }
        
    }
}