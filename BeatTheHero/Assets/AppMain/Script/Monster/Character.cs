using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バトルで使用するユニットの生成；コンストラクタ
/// </summary>
public class Character : MonoBehaviour
{
    //ベースとなるデータ  
     CharacterLibrary.CharacterBase sikibetu;
   
 
    //ステータスの増減
    public new string  name { get; set; }
    public int level { get; set; }
    public int  MaxHP { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Speed { get; set; }
    public int Intellect { get; set; }
    public int Damage { get; set; }
    public CharacterLibrary.CharacterCondition condition { get; set; }
    public int turn = 0;
    public int mototi = 0;
    

    //HPの増減
    public int HP { get; set; }

    //使える技
    //public MoveLibrary moveLibrary;
    public List<MoveLibrary.MoveBase> Moves { get; set; }

    //public bool characterbool = true;

    /// <summary>
    /// コンストラクター：生成時の初期化
    /// </summary>
    /// <param name="characterbool"></param>
    /// <param name="characterLibrary"></param>
    /// <param name="moveLibrary"></param>
    /// <param name="i"></param>
    public Character(bool characterbool, CharacterLibrary characterLibrary, MoveLibrary moveLibrary, int i)
    {
        if (characterbool)
        {
            sikibetu = characterLibrary.Monster[i];
        }
        else
        {
            sikibetu = characterLibrary.Hero[i];
        }

        //生成するキャラのステータス反映
        name =  sikibetu.name;
        level = sikibetu.LV;
        MaxHP = sikibetu.HP;
        Attack = sikibetu.STR;
        Defence = sikibetu.VIT;
        Speed = sikibetu.AGI;
        Intellect = sikibetu.INT;
        condition = sikibetu.condition;
        

        HP = MaxHP;

        Moves = new List<MoveLibrary.MoveBase>();

        //レベルに応じて使える技の変化
        if (level >= 0 && level <= 25)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
        }
        else if (level >= 26 && level <= 50)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
        }
        else if (level >= 51 && level <= 70)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
            Moves.Add(moveLibrary.Move[sikibetu.thirdMove]);
            Moves.Add(moveLibrary.Move[sikibetu.forceMove]);
        }
        else
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
            Moves.Add(moveLibrary.Move[sikibetu.thirdMove]);
            Moves.Add(moveLibrary.Move[sikibetu.forceMove]);
            Moves.Add(moveLibrary.Move[sikibetu.fifthMove]);

        }
    }
    

    

    /// <summary>
    /// ダメージの計算部分
    /// </summary>
    /// <param name="move"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    public DamageDetails TakeDamage(MoveLibrary.MoveBase move, Character character)
    {
        //クリティカル
        float critical = 1f;
        if(Random.value * 100 <= 6.25f) //6.25％の確率でクリティカル
        {
            critical = 2f;
        }

        //Type相性　変更はCharacterLibraryから
        float type = CharacterLibrary.CharacterTypeChart.GetCharacterEffectivenss(move.type, sikibetu.type);
        DamageDetails damageDetails = new DamageDetails　//攻撃状態の初期化
        {
            Fainted = false,
            Critical = critical,
            TypeEffectiveness = type,
            
             
        };


        //float modifiers = Random.Range(0.5f, 1f) * type * critical; //与えるダメージの揺らぎ
        //float a = (2 * character.level + 10) / 250f;　//レベルに応じた攻撃力
        //float b = a * move.power * ((float)character.Attack / sikibetu.VIT) + 2;
        //int damage = Mathf.FloorToInt(b * modifiers);

        float c = move.power * (((float)character.Attack) / (sikibetu.VIT)) * (((float)character.level + 4) / 90) ;
        float d =  type * critical * Random.Range(0.5f, 1f);
        int damage = Mathf.FloorToInt(c * d );
        
        if(damage == 0)
        {
            damage++;
            Damage = damage;
            //Debug.Log($"{damage}");
            HP -= damage;
        }
        else
        {
            Damage = damage;
            //Debug.Log($"{damage}");
            HP -= damage;
        }
        

        //HPが0以下になったら気絶の処理
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }

        return damageDetails;
    
    }
    
    /// <summary>
    /// 攻撃技の設定
    /// </summary>
    /// <returns></returns>
    public MoveLibrary.MoveBase GetCharaRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }

    /// <summary>
    /// 状態異常のダメージ計算
    /// </summary>
    /// <param name="battleUnit"></param>
    /// <returns></returns>
    public StateProcessing statEfficacy(BattleUnit battleUnit)
    {

        StateProcessing stateProcessing = new StateProcessing
        {
            Fainted = false,
            TurnFrequency = turn,
            nowCondition = sikibetu.condition,
        };

        //火傷ならHPかの5％のダメージ（最低数値1）
        if (battleUnit.character.condition == CharacterLibrary.CharacterCondition.火傷)
        {
            
            float a = (sikibetu.HP) * 0.05f;
            int damage = Mathf.FloorToInt(a);
            Damage = damage;

            if(damage < 1)
            {
                damage = 1;
            }

            HP -= damage;

        }
        //毒ならHPかの5％のダメージ（最低数値1）
        else if (battleUnit.character.condition == CharacterLibrary.CharacterCondition.ドクドク)
        {
            float a = (sikibetu.HP) * 0.15f;
            int damage = Mathf.FloorToInt(a);
            Damage = damage;

            if (damage < 1)
            {
                damage = 1;
            }

            HP -= damage;
        }
        else
        {

        }

        //HPが0以下になったら気絶の処理
        if (HP <= 0)
        {
            HP = 0;
            stateProcessing.Fainted = true;
        }

        return stateProcessing;
;
    }

    /// <summary>
    /// ダイヤログに特殊ダメージの有無を告知
    /// </summary>
    public class DamageDetails
    {
        public bool Fainted { get; set; }
        public float Critical { get; set; }
        public float TypeEffectiveness { get; set; }

       
       
    }

    public class StateProcessing
    {
        public bool Fainted { get; set; }
        public int TurnFrequency { get; set; }
        public CharacterLibrary.CharacterCondition nowCondition { get; set; }
    }
}
