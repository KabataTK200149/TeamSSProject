using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// �i���������N���A���Ă���Ȃ璍�ӊ�����\������
/// </summary>
public class CoutionEvolutionButton : MonoBehaviour,
    IPointerDownHandler
{
    public System.Action onClickCallback;

    [SerializeField] GameObject cautionObject;
    [SerializeField] Image warningStatementImage;
    [SerializeField] Image evolutionItemImage;
    [SerializeField] Text warningStatementText;
    [SerializeField] Text evolutionItemText;
    [SerializeField] ItemDataBase itemData;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!GManager.instance.conditionNotClear)
        {
            evolutionItemImage.sprite = itemData.GetItemDataList()[GManager.instance.evolutionNumber].GetSprite(); //�K�v�ȃA�C�e���̉摜��Y�t
            evolutionItemText.text = itemData.GetItemDataList()[GManager.instance.evolutionNumber].GetItemName(); //�K�v�ȃA�C�e���̖��O��Y�t
            cautionObject.SetActive(true);
        }
        else
        {
            warningStatementImage.color = warningStatementImage.color + new Color32(0, 0, 0, 255);
            warningStatementText.color = warningStatementText.color + new Color32(0, 0, 0, 255);
            StartCoroutine(WarningStatementDisplay());
        }

    }

    /// <summary>
    /// �퓬���郂���X�^�[���I������Ă��Ȃ����Ƃ�`����{�[�h��\��
    /// </summary>
    /// <returns></returns>
    IEnumerator WarningStatementDisplay()
    {
        for (int i = 0; i < 255; i++)
        {
            warningStatementImage.color = warningStatementImage.color - new Color32(0, 0, 0, 1);
            warningStatementText.color = warningStatementText.color - new Color32(0, 0, 0, 1);

            yield return new WaitForSeconds(0.008f);

        }
    }
}
