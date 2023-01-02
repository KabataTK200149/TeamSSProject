using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �o�g���Ŏg�p���郂���X�^�[�̃f�[�^��ێ�
/// �����X�^�[�̉摜�𔽓]������
/// </summary>
public class BattleUnit : MonoBehaviour
{
    //��킹�郂���X�^�[���Z�b�g����
    public int  battleMonsterNunber { get; set; }
    public ushort battleHeroNunber { get; set; }
    public int level;
    public bool isPlayerUnit;

    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] MoveLibrary moveLibrary;
    [SerializeField] SaveAndRoad saveDate;
    [SerializeField] QuestStructure questStructure;

    public Character character { get; set; }
    public CharacterLibrary CharacterLibrary { get => characterLibrary; set => characterLibrary = value; }
    public MoveLibrary MoveLibrary { get => moveLibrary; set => moveLibrary = value; }

    Vector3 originalPos;
    Color originalColor;

    public Image imageMonster;
    public Image imageHero;

    private void Awake()
    {
        originalPos = transform.localPosition;
        originalColor = imageMonster.color;

        GameObject image_objectMonster = GameObject.Find("Image");
        GameObject image_objectHero = GameObject.Find("Image");

        imageMonster = imageMonster.GetComponent<Image>();
        imageHero = imageHero.GetComponent<Image>();
        
    }

    /// <summary>
    /// _base���烌�x���ɉ����������X�^�[�𐶐�����
    /// </summary>
    public void SetUp()
    {
        saveDate.roadMonsterDate();

        //�v���C���[���̃����X�^�[�Ȃ炻�̃����X�^�[��BackSprite��\������
        //�G���Ȃ炻�̃����X�^�[��FrontSprite��\������
        if (isPlayerUnit)
        {
            battleMonsterNunber = GManager.instance.battleMonsterNunber;
            CharacterLibrary.Monster[battleMonsterNunber].frontSprite = Resources.Load(CharacterLibrary.Monster[battleMonsterNunber].frontSpriteDateName) as Texture2D;
            CharacterLibrary.Monster[battleMonsterNunber].backSprite = Resources.Load(CharacterLibrary.Monster[battleMonsterNunber].backSpriteDateName) as Texture2D;

            //BattleSystem�Ŏg�p����̂Ńv���p�e�B�ɓ����
            character = new Character(isPlayerUnit, CharacterLibrary, MoveLibrary, battleMonsterNunber);

            imageMonster.sprite = Sprite.Create(CharacterLibrary.Monster[battleMonsterNunber].backSprite, new Rect(0, 0, CharacterLibrary.Monster[battleMonsterNunber].backSprite.width, CharacterLibrary.Monster[battleMonsterNunber].backSprite.height), Vector2.zero);
        }
        else
        {

            battleHeroNunber = questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st;
            characterLibrary.Hero[battleHeroNunber].frontSprite = Resources.Load(CharacterLibrary.Hero[battleHeroNunber].frontSpriteDateName) as Texture2D;
            characterLibrary.Hero[battleHeroNunber].transformation = Resources.Load(CharacterLibrary.Hero[battleHeroNunber].transformationDateName) as Texture2D;

            character = new Character(isPlayerUnit, CharacterLibrary, MoveLibrary, battleHeroNunber);

            imageHero.sprite = Sprite.Create(CharacterLibrary.Hero[battleHeroNunber].frontSprite, new Rect(0, 0, CharacterLibrary.Hero[battleHeroNunber].frontSprite.width, CharacterLibrary.Hero[battleHeroNunber].frontSprite.height), Vector2.zero);
        }
        PlayerEnterAnimation();
    }


    /// <summary>
    /// �퓬����A�j���[�V����
    /// </summary>
    public void PlayerEnterAnimation()
    {
        if (isPlayerUnit)
        {
            
            transform.localPosition = new Vector3(-1255, originalPos.y);

        }
        else
        {
            transform.localPosition = new Vector3(1255, originalPos.y);
        }

        //�{���̈ʒu�܂ŃA�j���\�V����
        transform.DOLocalMoveX(originalPos.x, 1f);   
    }


    /// <summary>
    /// �U�����[�V����
    /// </summary>
    public void PlayerAttackAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        if (isPlayerUnit)
        {
           sequence.Append(transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
        }
        else
        {
            sequence.Append(transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
        }
        sequence.Append(transform.DOLocalMoveX(originalPos.x , 0.2f));
    }


    /// <summary>
    /// �U�����󂯂����ɃJ���[�`�F���W
    /// </summary>
    public void PlayerHitAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(imageMonster.DOColor(Color.gray, 0.1f));
        sequence.Append(imageMonster.DOColor(originalColor, 0.1f));
        
    }


    /// <summary>
    /// �s�k�����[�V����
    /// </summary>
    public void PlayerFaintAnimation()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMoveX(originalPos.y - 150f, 0.5f));
        sequence.Join(imageMonster.DOFade(0, 0.5f));
        
    }

   
}
