using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// バトルを開始させるボタン
/// </summary>
public class BattleStartButton : MonoBehaviour,
    IPointerDownHandler
{
    [SerializeField] QuestSystem questSystem;
    [SerializeField] Image WarningStatementImage;
    [SerializeField] Text WarningStatementText;
    public System.Action onClickCallback;

    public void OnPointerDown(PointerEventData eventData)
    {
        //クエストに必要な数のモンスターが選択されていたらバトルを開始する、それ以外なら警告文を表示する
        if (questSystem.checkBoxNoReaction)
        {
            GManager.instance.sceneTag = GManager.GameSceneTag.BATTLE;
            SceneManager.LoadScene("BattleScene"); 
        }
        else
        {
            WarningStatementImage.color = WarningStatementImage.color + new Color32(0, 0, 0, 255);
            WarningStatementText.color = WarningStatementText.color + new Color32(0, 0, 0, 255);
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
            WarningStatementImage.color = WarningStatementImage.color - new Color32(0, 0, 0, 1);
            WarningStatementText.color = WarningStatementText.color - new Color32(0, 0, 0, 1);

            yield return new WaitForSeconds(0.008f);

        }
    }
}