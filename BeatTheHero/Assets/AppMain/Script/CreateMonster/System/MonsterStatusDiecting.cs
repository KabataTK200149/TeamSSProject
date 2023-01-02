using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ¶¬‚µ‚½ƒ‚ƒ“ƒXƒ^[‚Ìî•ñ‚ğ•\¦‚µ‚Ä“®‚©‚·
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
    /// HPBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void HPTransAnimation()
    {
        HPObj.transform.DOLocalMoveX(0f, 0.5f);
    }

    /// <summary>
    /// strBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void STRTransAnimation()
    {
        STRObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// vitBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void VITTransAnimation()
    {
        VITObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// agiBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void AGITransAnimation()
    {
        AGIObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// intBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void INTTransAnimation()
    {
        INTObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// typeBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void TypeTransAnimation()
    {
        TypeObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// firstMoveBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void FirstMoveTransAnimation()
    {
        FirstMoveObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// firstSkillBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®
    /// </summary>
    public void FirstSkillTransAnimation()
    {
        FirstSkillObj.transform.DOLocalMoveX(0.8f, 0.5f);
    }

    /// <summary>
    /// secondSkillBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®(Î‚ß‚Éæ‚ê‚é)
    /// </summary>
    public void SecondSkillEnterAnimation()
    {
        SecondSkillObj.transform.DOLocalRotate(new Vector3(0, 0, -10), 0.5f);
        SecondSkillObj.transform.DOLocalMoveX(0.8f, 0.2f);
    }

    /// <summary>
    /// secondSkillBar‚ğ‰B‚µ‚Ä‚¢‚é‘Ñ‚ÌˆÚ“®(‰º‚É—‚¿‚é)
    /// </summary>
    public void SecondSkillExitAnimation()
    {
        SecondSkillObj.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.5f);
    }


    /// <summary>
    /// ƒXƒe[ƒ^ƒX•\¦‚Ì•\¦“à—e‚Ì•ÏX
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
            GManager.instance.characterType = CharacterLibrary.CharacterType.‰Š;
        }
        else if (GManager.instance.monsterDate[7] == 1)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.…;
        }
        else if (GManager.instance.monsterDate[7] == 2)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.—‹;
        }
        else if (GManager.instance.monsterDate[7] == 3)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.•—;
        }
        else if (GManager.instance.monsterDate[7] == 4)
        {
            GManager.instance.characterType = CharacterLibrary.CharacterType.“Å;
        }
    }
}
