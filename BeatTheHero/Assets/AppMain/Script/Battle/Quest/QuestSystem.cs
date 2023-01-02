using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �N�G�X�g�O�̏��⃂���X�^�[�I����ʂ̃V�X�e��
/// </summary>
public class QuestSystem : MonoBehaviour
{
    [SerializeField] QuestStructure questStructure; //�N�G�X�g�̏�񂪂���X�N���v�g
    [SerializeField] CharacterLibrary characterLibrary; //�����X�^�[�̏�񂪂���X�N���v�g

    [SerializeField] Image characterImage; //�o������q�[���[�̃C���[�W
    [SerializeField] Image typeImage; //�q�[���[�̎�_�^�C�v�̃C���[�W
    [SerializeField] Text startButtonText; //�퓬�J�n�Ȃǂ̕�����\��
    [SerializeField] Text LVText; //�q�[���[�̃��x����\��
    [SerializeField] GameObject rewardsObject; //��V��������Ă���I�u�W�F�N�g
    [SerializeField] GameObject challengeObject; //�N�G�X�g��������Ă���I�u�W�F�N�g
    [SerializeField] Image detailsImage; //�ڍ׃y�[�W�̃^�u
    [SerializeField] Image rewardsImage; //��V�y�[�W�̃^�u
    [SerializeField] Image challenge; //�N�G�X�g�y�[�W�̃^�u

    [SerializeField] SaveAndRoad road;

    [SerializeField] GameObject questInformation;
    [SerializeField] GameObject questBoxObj; //��������N�G�X�g�o�[�̃I�u�W�F�N�g
    [SerializeField] GameObject parentObj; //��������ꏊ�̐e�I�u�W�F�N�g

    static Texture2D typeSprite;
    public Image originalColor;

    List<GameObject> createItemImageObj = new List<GameObject>();

    public byte checkBosTotalNumber { get; set; }
    
    public bool checkBoxNoReaction { get; set; }

    Vector3 originalScale;

    /*
    public void Awake()
    {
        GameObject image_objectMonster = GameObject.Find("Image");
        imageMonster = imageMonster.GetComponent<Image>();
    }*/

    public void Start()
    {
        GManager.instance.conditionNotClear = false;
        originalScale = questInformation.transform.localScale;

        GManager.instance.sceneTag = GManager.GameSceneTag.BATTLE;
        SetSystem();
        road.roadMonsterDate();
        checkBoxNoReaction = false;
    }

    private void Update()
    {
        if (GManager.instance.conditionNotClear)
        {
            QuestInfomation();
            ActiveInformation();
        }

        CheckBoxControl();
    }

    /// <summary>
    /// �N�G�X�g�o�[��\������
    /// </summary>
    public void SetSystem()
    {
        int posY = ((100 / 2) + ((690 - (100 * 4)) / 5));
        int pushPointX = 130;
        int pushPointY = 768 - posY;

        createItemImageObj.Clear();

        for (int i= 0; i < questStructure.Quest.Length; i++)
        {
            if(questStructure.Quest[i].questLV <= GManager.instance.playerLevel)
            {
                GameObject instansObj = Instantiate(questBoxObj, parentObj.transform);
                instansObj.transform.localPosition = new Vector3(pushPointX, pushPointY, 0);

                //�N�G�X�g�o�[�̔ԍ���}��
                instansObj.GetComponent<QuestButton>().questNumber = i;

                instansObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = questStructure.Quest[i].questName;
                instansObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = questStructure.Quest[i].questAP.ToString();

                createItemImageObj.Add(instansObj);

                pushPointY -= posY + (posY - ((690 - (170 * 4)) / 5));
            }
        }
    }

    //�N�G�X�g�ɓo�ꂷ�郂���X�^�̏���\��������
    public void QuestInfomation()
    {
        //�摜���[�h
        characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation = Resources.Load(characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformationDateName) as Texture2D;

        if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.��)
        {
            typeSprite = Resources.Load("��") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.��)
        {
            typeSprite = Resources.Load("��") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.��)
        {
            typeSprite = Resources.Load("��") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.��)
        {
            typeSprite = Resources.Load("��") as Texture2D;
        }

        //�摜�ύX
        characterImage.sprite = Sprite.Create(characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation, new Rect(0, 0, characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation.width, characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation.height), Vector2.zero);
        typeImage.sprite = Sprite.Create(typeSprite, new Rect(0, 0, typeSprite.width, typeSprite.height), Vector2.zero);

        //�e�L�X�g�ύX
        
        LVText.text = ($"{characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].LV}");

        //�F�ύX
        detailsImage.color = new Color32(120, 196, 221, 255);

    }

    //�ڍ׃{�^�����������Ƃ��̏���
    public void DetailsOnTrigger()
    {
        //�o�[�̐F�ς�
        detailsImage.color = new Color32(120, 196, 221, 255);
        rewardsImage.color = originalColor.color;
        challenge.color = originalColor.color;

        //��ʕ\������
        rewardsObject.SetActive(false);
        challengeObject.SetActive(false);

    }

    //�l����V�{�^�����������Ƃ��̏���
    public void RewardsOnTrigger()
    {
        //�o�[�̐F�ς�
        rewardsImage.color = new Color32(120, 196, 221, 255);
        detailsImage.color = originalColor.color;
        challenge.color = originalColor.color;

        //��ʕ\������
        rewardsObject.SetActive(true);
        challengeObject.SetActive(false);
    }

    //�`�������W�{�^�����������Ƃ��̏���
    public void ChallengeOnTrigger()
    {
        //�o�[�̐F�ς�
        challenge.color = new Color32(120, 196, 221, 255);
        detailsImage.color = originalColor.color;
        rewardsImage.color= originalColor.color;

        //��ʕ\������
        rewardsObject.SetActive(false);
        challengeObject.SetActive(true);
    }

    /// <summary>
    /// �N�G�X�g�ɏo������q�[���[�̐������X�^�[��I�����Ă���ΐ퓬���J�n����
    /// </summary>
    public void CheckBoxControl()
    {
        if(checkBosTotalNumber == questStructure.Quest[GManager.instance.selectQuestNumber].heroQuanity) //�I�������N�G�X�g�̃q�[���ƑI�����������X�^�[�̐��������Ȃ��
        {
            startButtonText.text = ("�퓬�J�n");
            checkBoxNoReaction = true;
        }
        else //�I�������N�G�X�g�̃q�[���ƑI�����������X�^�[�̐����Ⴄ�Ȃ�
        {
            startButtonText.text = ($"����AP{questStructure.Quest[GManager.instance.selectQuestNumber].questAP}");
           
            checkBoxNoReaction = false;
        }

        
    }

    public void ActiveInformation()
    {
        questInformation.transform.localScale = new Vector2(0.7f, 0.7f);
        questInformation.SetActive(true);
        questInformation.SetActive(true);
        questInformation.transform.DOScale(new Vector3(originalScale.x, originalScale.y, originalScale.z), 1f);

        GManager.instance.conditionNotClear = false;
    }

   
}
