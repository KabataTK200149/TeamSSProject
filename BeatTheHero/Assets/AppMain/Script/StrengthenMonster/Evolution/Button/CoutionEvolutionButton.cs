using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// 進化条件をクリアしているなら注意勧告を表示する
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
            evolutionItemImage.sprite = itemData.GetItemDataList()[GManager.instance.evolutionNumber].GetSprite(); //必要なアイテムの画像を添付
            evolutionItemText.text = itemData.GetItemDataList()[GManager.instance.evolutionNumber].GetItemName(); //必要なアイテムの名前を添付
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
    /// 戦闘するモンスターが選択されていないことを伝えるボードを表示
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
