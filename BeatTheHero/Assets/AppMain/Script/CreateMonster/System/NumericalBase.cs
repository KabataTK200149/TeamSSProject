using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// スキルポイント振り分けスクリプト
/// </summary>
public class NumericalBase : MonoBehaviour
{

    [SerializeField] Text TypeTextNo1;
    [SerializeField] Text TypeTextNo2;

    [SerializeField] GameObject TypeText1;
    [SerializeField] GameObject TypeText2;

    CharacterLibrary.CharacterType[] characterTypes = new CharacterLibrary.CharacterType[5];

    public int typeNumber { get; set; }
    public int Attribute { get; set; }

    Vector3 originalPos1;
    Vector3 originalPos2;
    CharacterLibrary.CharacterType TypeNo1;
    CharacterLibrary.CharacterType TypeNo2;


    public void Start()
    {
        Attribute = GManager.instance.monsterDate[0];
        
        characterTypes[0] = CharacterLibrary.CharacterType.炎;
        characterTypes[1] = CharacterLibrary.CharacterType.水;
        characterTypes[2] = CharacterLibrary.CharacterType.雷;
        characterTypes[3] = CharacterLibrary.CharacterType.風;
        characterTypes[4] = CharacterLibrary.CharacterType.毒;


        //skillPoint += GManager.instance.monsterDate[6];

        originalPos1 = TypeText1.transform.localPosition;
        originalPos2 = TypeText2.transform.localPosition;

        TypeNo1 = characterTypes[0];
        TypeNo2 = characterTypes[1];


        typeNumber = 0;
    }

    public void Update()
    {
        DisplaySkillPoint();
    }

    /// <summary>
    /// 表示テキストの制御
    /// </summary>
    public void DisplaySkillPoint()
    {

        TypeTextNo1.text = ($"{TypeNo1}");
        TypeTextNo2.text = ($"{TypeNo2}");
       
    }
    
    /// <summary>
    /// タイプの選択時のアニメーション（プラス時）
    /// </summary>
    /// <returns></returns>
    public IEnumerator TypeSelectAnimationPlus()
    {
        if(TypeText1.transform.localPosition.x == originalPos1.x)
        { 
            if (typeNumber == 4) //今のタイプの確認
            {
                typeNumber = 0;
            }
            else
            {
                typeNumber++;
            }

            
            TypeNo2 = characterTypes[typeNumber];

            TypeText2.transform.localPosition = originalPos2;

            TypeText1.transform.DOLocalMoveX(-280, 0.1f);
            TypeText2.transform.DOLocalMoveX(originalPos1.x, 0.1f);

            

        }
        else
        { 
            if (typeNumber == 4) //今のタイプの確認
            {
                typeNumber = 0;
            }
            else
            {
                typeNumber++;
            }

           
            TypeNo1 = characterTypes[typeNumber];

            TypeText1.transform.localPosition = originalPos2;

            TypeText2.transform.DOLocalMoveX(-280, 0.1f);
            TypeText1.transform.DOLocalMoveX(originalPos1.x, 0.1f);

            
        }

        return null;

    }

    /// <summary>
    /// タイプの選択時のアニメーション（マイナス時）
    /// </summary>
    /// <returns></returns>
    public IEnumerator TypeSelectAnimationMinus()
    {
        if (TypeText1.transform.localPosition.x == originalPos1.x)
        {
            if (typeNumber == 0) //今のタイプの確認
            {
                typeNumber = 4;
            }
            else
            {
                typeNumber--;
            }

            TypeNo2 = characterTypes[typeNumber];

            TypeText2.transform.localPosition = new Vector3(-280, 0, 0);

            TypeText1.transform.DOLocalMoveX(280, 0.1f);
            TypeText2.transform.DOLocalMoveX(originalPos1.x, 0.1f);

           
        }
        else
        {
            if (typeNumber == 0) //今のタイプの確認
            {
                typeNumber = 4;
            }
            else
            {
                typeNumber--;
            }

            TypeNo1 = characterTypes[typeNumber];

            TypeText1.transform.localPosition = new Vector3(-280, 0, 0);

            TypeText2.transform.DOLocalMoveX(280, 0.1f);
            TypeText1.transform.DOLocalMoveX(originalPos1.x, 0.1f);
        }

      return null;
    }
}
