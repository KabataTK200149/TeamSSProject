using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// dialogのTextを取得して、変更する
/// </summary>
public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] Color highlightColor;

    [SerializeField] int letterPerSecond; //1文字当たりの時間
    [SerializeField] Text dialogText;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDeralls;

    [SerializeField] List<Text> actionTexts;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;
    

    /// <summary>
    /// コルーチンで文字の表示速度の設定
    /// </summary>
    /// <param name="dialog"></param>
    /// <returns></returns>
    public IEnumerator TypDialog(string dialog, Color32 color32)
    {
        dialogText.text = ""; //初期化
        dialogText.color = new Color32(color32.r, color32.g, color32.b, color32.a);
        
         foreach(char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }

        yield return new WaitForSeconds(1); //メッセージ表示後1秒待つ
    }
         
}
