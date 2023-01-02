using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// クエスト前の情報やモンスター選択画面のシステム
/// </summary>
public class QuestSystem : MonoBehaviour
{
    [SerializeField] QuestStructure questStructure; //クエストの情報があるスクリプト
    [SerializeField] CharacterLibrary characterLibrary; //モンスターの情報があるスクリプト

    [SerializeField] Image characterImage; //出現するヒーローのイメージ
    [SerializeField] Image typeImage; //ヒーローの弱点タイプのイメージ
    [SerializeField] Text startButtonText; //戦闘開始などの文字を表示
    [SerializeField] Text LVText; //ヒーローのレベルを表示
    [SerializeField] GameObject rewardsObject; //報酬が書かれているオブジェクト
    [SerializeField] GameObject challengeObject; //クエストが書かれているオブジェクト
    [SerializeField] Image detailsImage; //詳細ページのタブ
    [SerializeField] Image rewardsImage; //報酬ページのタブ
    [SerializeField] Image challenge; //クエストページのタブ

    [SerializeField] SaveAndRoad road;

    [SerializeField] GameObject questInformation;
    [SerializeField] GameObject questBoxObj; //生成するクエストバーのオブジェクト
    [SerializeField] GameObject parentObj; //生成する場所の親オブジェクト

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
    /// クエストバーを表示する
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

                //クエストバーの番号を挿入
                instansObj.GetComponent<QuestButton>().questNumber = i;

                instansObj.transform.GetChild(0).gameObject.GetComponent<Text>().text = questStructure.Quest[i].questName;
                instansObj.transform.GetChild(1).gameObject.GetComponent<Text>().text = questStructure.Quest[i].questAP.ToString();

                createItemImageObj.Add(instansObj);

                pushPointY -= posY + (posY - ((690 - (170 * 4)) / 5));
            }
        }
    }

    //クエストに登場するモンスタの情報を表示させる
    public void QuestInfomation()
    {
        //画像リード
        characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation = Resources.Load(characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformationDateName) as Texture2D;

        if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.風)
        {
            typeSprite = Resources.Load("炎") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.雷)
        {
            typeSprite = Resources.Load("風") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.水)
        {
            typeSprite = Resources.Load("雷") as Texture2D;
        }
        else if (characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].type == CharacterLibrary.CharacterType.炎)
        {
            typeSprite = Resources.Load("水") as Texture2D;
        }

        //画像変更
        characterImage.sprite = Sprite.Create(characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation, new Rect(0, 0, characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation.width, characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].transformation.height), Vector2.zero);
        typeImage.sprite = Sprite.Create(typeSprite, new Rect(0, 0, typeSprite.width, typeSprite.height), Vector2.zero);

        //テキスト変更
        
        LVText.text = ($"{characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].LV}");

        //色変更
        detailsImage.color = new Color32(120, 196, 221, 255);

    }

    //詳細ボタンを押したときの処理
    public void DetailsOnTrigger()
    {
        //バーの色変え
        detailsImage.color = new Color32(120, 196, 221, 255);
        rewardsImage.color = originalColor.color;
        challenge.color = originalColor.color;

        //画面表示許可
        rewardsObject.SetActive(false);
        challengeObject.SetActive(false);

    }

    //獲得報酬ボタンを押したときの処理
    public void RewardsOnTrigger()
    {
        //バーの色変え
        rewardsImage.color = new Color32(120, 196, 221, 255);
        detailsImage.color = originalColor.color;
        challenge.color = originalColor.color;

        //画面表示許可
        rewardsObject.SetActive(true);
        challengeObject.SetActive(false);
    }

    //チャレンジボタンを押したときの処理
    public void ChallengeOnTrigger()
    {
        //バーの色変え
        challenge.color = new Color32(120, 196, 221, 255);
        detailsImage.color = originalColor.color;
        rewardsImage.color= originalColor.color;

        //画面表示許可
        rewardsObject.SetActive(false);
        challengeObject.SetActive(true);
    }

    /// <summary>
    /// クエストに出現するヒーローの数モンスターを選択していれば戦闘を開始する
    /// </summary>
    public void CheckBoxControl()
    {
        if(checkBosTotalNumber == questStructure.Quest[GManager.instance.selectQuestNumber].heroQuanity) //選択したクエストのヒーロと選択したモンスターの数が同じならば
        {
            startButtonText.text = ("戦闘開始");
            checkBoxNoReaction = true;
        }
        else //選択したクエストのヒーロと選択したモンスターの数が違うなら
        {
            startButtonText.text = ($"消費AP{questStructure.Quest[GManager.instance.selectQuestNumber].questAP}");
           
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
