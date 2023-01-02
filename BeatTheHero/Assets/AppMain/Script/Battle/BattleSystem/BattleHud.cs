using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// バトル時のモンスター情報のテキスト表示
/// </summary>
public class BattleHud : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Character _character;
    

    /// <summary>
    /// レベル、HP、名前の位置に何を表示するのかを設定
    /// </summary>
    /// <param name="monster"></param>
    public void SetDate(Character character)
    {
        _character = character;
    }

    /// <summary>
    /// HPバー増減のコルーチンを発動
    /// </summary>
    /// <returns></returns>
    public IEnumerator UpdateHP()
    { 
        yield return hpBar.SetHPSmooth((float)_character.HP / _character.MaxHP);   
    }

}
