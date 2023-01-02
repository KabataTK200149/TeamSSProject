using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 技とスキルの振り分け
/// </summary>
public class SkillSorting : MonoBehaviour
{
    public int move1, move2, move3, move4, move5, skill1, skill2;

    public void SkillCheck()
    {
        if (GManager.instance.monsterDate[7] == 0) //キャラクターのタイプが炎なら
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.炎;

           

            
            move1 = Random.Range(1, 5);
            move2 = 11;
            move3 = Random.Range(12, 14);
            move4 = 14;
            move5 = 15;
           

            skill1 = 1;

            if (Random.Range(0, 100) <= 20)
            {
                skill2 = 1;
            }
            else
            {
                skill2 = 0;
            }
        }
        else if (GManager.instance.monsterDate[7] == 1) //キャラクターのタイプが水なら
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.水;

            move1 = Random.Range(1, 5);
            move2 = 16;
            move3 = Random.Range(17, 19);
            move4 = 19;
            move5 = 20; ;

            skill1 = 1;

            if (Random.Range(0, 100) <= 20)
            {
                skill2 = 1;
            }
            else
            {
                skill2 = 0;
            }
        }
        else if (GManager.instance.monsterDate[7] == 2) //キャラクターのタイプが雷なら
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.雷;

            move1 = Random.Range(1, 5);
            move2 = 21;
            move3 = Random.Range(22, 24);
            move4 = 24;
            move5 = 25;

            skill1 = 1;

            if (Random.Range(0, 100) <= 20)
            {
                skill2 = 1;
            }
            else
            {
                skill2 = 0;
            }
        }
        else if (GManager.instance.monsterDate[7] == 3) //キャラクターのタイプが風なら
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.風;

            move1 = Random.Range(1, 5);
            move2 = 26;
            move3 = Random.Range(27, 29);
            move4 = 29;
            move5 = 30;

            skill1 = 1;

            if (Random.Range(0, 100) <= 20)
            {
                skill2 = 1;
            }
            else
            {
                skill2 = 0;
            }

        }
        else if (GManager.instance.monsterDate[7] == 4) //キャラクターのタイプが毒なら
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.毒;

            move1 = Random.Range(1, 5);
            move2 = 31;
            move3 = Random.Range(32, 34);
            move4 = 34;
            move5 = 35;

            skill1 = 1;

            if (Random.Range(0, 100) <= 20)
            {
                skill2 = 1;
            }
            else
            {
                skill2 = 0;
            }

        }
        else
        {
            move1 = 0;
            move2 = 0;
            move3 = 0;
            move4 = 0;
            move5 = 0;

            skill1 = 0;
            skill2 = 0;

        }

    }
}
