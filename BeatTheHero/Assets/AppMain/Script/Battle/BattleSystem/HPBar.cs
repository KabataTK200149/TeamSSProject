using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HPの増減の描画
/// </summary>
public class HPBar : MonoBehaviour
{
    //HPバーのgameobject取得
    [SerializeField] GameObject health;

    /// <summary>
    /// HPバーを徐々に減らしていく計算をしているコルーチン
    /// </summary>
    /// <param name="newHP"></param>
    /// <returns></returns>
    public IEnumerator SetHPSmooth(float newHP)
    {
        float currentHP = health.transform.localScale.x;
        float changeAmount = currentHP - newHP;

        //currerHPとnewHPに差があるなら繰り返す
        while(currentHP - newHP > Mathf.Epsilon)
        {
            currentHP -= changeAmount * Time.deltaTime;
            health.transform.localScale = new Vector3(currentHP, 1, 1);
            yield return null;
        }

        health.transform.localScale = new Vector3(newHP, 1, 1);
    }
}
