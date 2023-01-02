using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �����ɑт�\���E��\��������
/// ���ʂ�����
/// </summary>
public class EnemyTransform : MonoBehaviour
{
    [SerializeField] CharacterLibrary character;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] Color victoryColor;
    [SerializeField] Color defeatColor;
    [SerializeField] Color battleColor;
    [SerializeField] GameObject transformHero;
    [SerializeField] GameObject heroImageObj;
    [SerializeField] GameObject battleStertText;
    [SerializeField] Text dialogTex;
    [SerializeField] Text situationText;
    public Image heroImage;

   public float centralPosy;

    Vector3 originalScaleObi, originalScaleImage, originalPosBattle;
    Vector2 NowScale;
    Texture2D transformHeroSprite;

    public void Awake()
    {
        originalScaleObi = transformHero.transform.localScale; //TransformDirecting�̌��X�̃X�P�[�����擾
        originalScaleImage = heroImageObj.transform.localScale;
        originalPosBattle = battleStertText.transform.localPosition;

        GameObject image_objectMonster = GameObject.Find("HeroTransform");
        heroImage = heroImage.GetComponent<Image>();

    }

    /// <summary>
    /// �ϐg�ѕ\���E��\���ݒ�
    /// </summary>
    /// <param name="enabled"></param>
    public void EnableTransformHero(bool enabled)
    {
        transformHero.SetActive(enabled);
    }

    /// <summary>
    /// �ϐg�ѕ\���A�j���[�V����
    /// </summary>
    /// <returns></returns>
    public IEnumerator ExpansionEnterAnimation()
    {
        transformHero.transform.localScale = new Vector2(originalScaleObi.x, 0); //�т̑傫��Scale���ŏ��ɂ���
        dialogTex.text = ("");

        //�т̑傫��Scale�����X�ɑ傫�����Ă���
        while (transformHero.transform.localScale.y <= originalScaleObi.y)
        {
            NowScale = transformHero.transform.localScale;
            transformHero.transform.localScale = new Vector2(originalScaleObi.x, NowScale.y + 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void ChangingHero()
    {
       
        transformHeroSprite = Resources.Load(character.Hero[enemyUnit.battleHeroNunber].transformationDateName) as Texture2D;

        heroImage.sprite = Sprite.Create(transformHeroSprite, new Rect(0, 0, transformHeroSprite.width, transformHeroSprite.height), Vector2.zero);

    }

    public void MoveChangingHero()
    {
        heroImageObj.transform.DOScale(new Vector3(1.4f, 1.4f, 0), 3f);
    }

    /// <summary>
    /// �ϐg�ю��k�A�j���[�V����
    /// </summary>
    /// <returns></returns>
    public IEnumerator ExpansionFaintAnimation()
    {
        //�т̑傫��Scale�����X�ɏ��������Ă���
        while(transformHero.transform.localScale.y >= 0.1f)
        {
            NowScale = transformHero.transform.localScale;
            transformHero.transform.localScale = new Vector2(originalScaleObi.x, NowScale.y - 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    /// <summary>
    /// BattlestertText����ʉE���獶�ֈړ�������
    /// </summary>
    /// <returns></returns>
    public IEnumerator BattleStertAnimation()
    {
        situationText.text = ($"BATTLE START");
        situationText.color = battleColor;
        situationText.fontSize = 180;
        battleStertText.transform.localPosition = new Vector3(1658, originalPosBattle.y); //��ʉE�[��Text���ړ�
        battleStertText.SetActive(true); //Text�\��

        battleStertText.transform.DOLocalMoveX(originalPosBattle.x, 1f);
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(0.8f); //��ʒ�����Text��ҋ@������b

        battleStertText.transform.DOLocalMoveX(-1658f, 1f);
        yield return new WaitForSeconds(1f);

        battleStertText.SetActive(false); //Text��\��
    }

    public IEnumerator VictoryAnimation()
    {
        situationText.text = ($"����!");
        situationText.color = victoryColor;
        situationText.fontSize = 0;
        battleStertText.transform.localPosition = new Vector3( 0, originalPosBattle.y ); //��ʉE�[��Text���ړ�
        battleStertText.SetActive(true); //Text�\��

        while(situationText.fontSize <= 170)
        {
            situationText.fontSize += 10;
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

    }

    public IEnumerator DefeatAnimation()
    {
        situationText.text = ($"�s�k");
        situationText.color = defeatColor;
        situationText.fontSize = 0;
        battleStertText.transform.localPosition = new Vector3(0, originalPosBattle.y ); //��ʉE�[��Text���ړ�
        battleStertText.SetActive(true); //Text�\��

        while (situationText.fontSize <= 180)
        {
            situationText.fontSize += 10;
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

    }
}
