using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPBar : MonoBehaviour
{
    public float changeAmount;

    /// <summary>
    /// 経験値のバーの割合を計算して当てはめる
    /// </summary>
    /// <param name="LV"></param>
    /// <param name="XP"></param>
    public void SetXPSmooth(int LV, int XP, GameObject experience)
    {
        float currentXP = experience.transform.localScale.x; //バーのスケール
        float developXP = (100 * Mathf.Pow(1.1f, ((float)LV))); //そのレベルに対して必要な経験値 pow:指数計算
        
        
        if(LV == 1)
        {
            developXP -= 10;
        }

        changeAmount = (XP / developXP); //今の経験値とそのレベルからレベルアップするのに必要な経験値の割合

        if(currentXP - changeAmount > Mathf.Epsilon)
        {
            experience.transform.localScale = new Vector3(changeAmount, 1, 1); //割合分減らす:変更時最大が1で最小が0なので小数点を消さないこと
        }



    }
}
