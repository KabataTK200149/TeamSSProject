using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 生成したモンスターの情報を表示して動かす
/// </summary>
public class MonsterStatusDiecting : MonoBehaviour
{
    [SerializeField] GManager gManager;
    [SerializeField] SkillSorting skillSorting;
    [SerializeField] MoveLibrary moveLibrary;

    [SerializeField] GameObject HPObj;
    [SerializeField] GameObject STRObj;
    [SerializeField] GameObject VITObj;
    [SerializeField] GameObject AGIObj;
    [SerializeField] GameObject INTObj;
    [SerializeField] GameObject TypeObj;
    [SerializeField] GameObject FirstMoveObj;
    [SerializeField] GameObject FirstSkillObj;
    [SerializeField] GameObject SecondSkillObj;

    [SerializeField] Text HPText;
    [SerializeField] Text STRText;
    [SerializeField] Text VITText;
    [SerializeField] Text AGIText;
    [SerializeField] Text INTText;
    [SerializeField] Text TypeText;
    [SerializeField] Text FirstMoveText;
    [SerializeField] Text FirstSkillText;
    [SerializeField] Text SecondSkillText;

    /// <summary>
    /// HPBarを隠している帯の移動
    /// </summary>
    public void HPTransAnimation()
    {
        HPObj.transform.DOLocalMoveX(0f, 0.5f);
    }

    /// <summary>
    /// strBarを隠している帯の移動
    /// </summary>
    public void STRTransAnimation()
    {
        STRObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// vitBarを隠している帯の移動
    /// </summary>
    public void VITTransAnimation()
    {
        VITObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// agiBarを隠している帯の移動
    /// </summary>
    public void AGITransAnimation()
    {
        AGIObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// intBarを隠している帯の移動
    /// </summary>
    public void INTTransAnimation()
    {
        INTObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// typeBarを隠している帯の移動
    /// </summary>
    public void TypeTransAnimation()
    {
        TypeObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// firstMoveBarを隠している帯の移動
    /// </summary>
    public void FirstMoveTransAnimation()
    {
        FirstMoveObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// firstSkillBarを隠している帯の移動
    /// </summary>
    public void FirstSkillTransAnimation()
    {
        FirstSkillObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// secondSkillBarを隠している帯の移動(斜めに取れる)
    /// </summary>
    public void SecondSkillEnterAnimation()
    {
        SecondSkillObj.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.5f);
        SecondSkillObj.transform.DOLocalMoveX(0.8f, 0.2f);
    }

    /// <summary>
    /// secondSkillBarを隠している帯の移動(下に落ちる)
    /// </summary>
    public void SecondSkillExitAnimation()
    {
        SecondSkillObj.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
    }


    /// <summary>
    /// ステータス表示の表示内容の変更
    /// </summary>
    public void ReflectionText()
    {
        TranslationType();

        HPText.text = GManager.instance.monsterDate[1].ToString();
        STRText.text = GManager.instance.monsterDate[2].ToString();
        VITText.text = GManager.instance.monsterDate[3].ToString();
        AGIText.text = GManager.instance.monsterDate[4].ToString();
        INTText.text = GManager.instance.monsterDate[5].ToString();
        TypeText.text = GManager.instance.characterType.ToString();
        FirstMoveText.text = moveLibrary.Move[skillSorting.move1].name;
        FirstSkillText.text = moveLibrary.Move[skillSorting.skill1].name;
        SecondSkillText.text = moveLibrary.Move[skillSorting.skill2].name;

     
    }

    void TranslationType()
    {
        if (GManager.instance.monsterDate[7] == 0)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.炎;
        }
        else if (GManager.instance.monsterDate[7] == 1)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.水;
        }
        else if (GManager.instance.monsterDate[7] == 2)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.雷;
        }
        else if (GManager.instance.monsterDate[7] == 3)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.風;
        }
        else if (GManager.instance.monsterDate[7] == 4)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.毒;
        }
    }
}
