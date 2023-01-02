using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLYAER.SYSTEM;

public class GManager : MonoBehaviour
{

    /// <summary>
    /// �Q�[���V�[��������
    /// </summary>
    public enum GameSceneTag
    {
        NONE,
        HOME,
        CREATE,
        STRENGTHEN,
        BATTLE,
        EVOLUTION,
        RESLT
    }

    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;
    public int monsterNumber { get; set; }//�����X�^�[�̐����ԍ�
    public int selectMonsterNumber { get; set; } //�琬��i���̍ۂɎg�p����郂���X�^�[�����ԖڂȂ̂���ۑ�����ϐ�
    public int evolutionNumber { get; set; } //�i���̑I����ۑ�����
    public int battleMonsterNunber { get; set; } //�o�g���̎��Ɏg�p����郂���X�^�[�̔ԍ���ۑ�����ϐ�
    public int selectQuestNumber { get; set; } //�N�G�X�g��I������Ƃ��A�ǂ̔ԍ��̃N�G�X�g���I�����ꂽ�̂��ۑ�����֐�
    public int[] monsterDate { get; set; } //�����X�^�[�̃X�e�[�^�X������z��100�̂܂Ő����� 
    public string monsterName { get; set; }
    public CharacterLibrary.CharacterType characterType { get; set; }
    public byte playerLevel { get; set; }

    public GameSceneTag sceneTag { get; set; } = GameSceneTag.NONE;

    public List<InventoryDateBase> itemInventory { get; set; } = new List<InventoryDateBase>();

    public bool statusBarPush { get; set; }

    public bool conditionNotClear { get; set; } = false; //�i�������Ȃǂ̏��������N���A���Ă��邩�𔻒肷��

    bool firstPlay { get; set; } = true; //��ԍŏ��̃v���C���ǂ����𔻕�
    public bool homePlay, buttolDefeat, evolutionSelect;
    public static GManager instance = null;

    


    public void Awake()
    {
        //���̃Q�[���I�u�W�F�N�g�ɉ����f�[�^�������Ă��Ȃ���΂��̃C���X�^���X������
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    //�v���C�����߂Ă������烂���X�^�[�̐����ԍ���0�ɂ��āA�����X�^�[�f�[�^�̔z����쐬����
    public void Start()
    {
        //characterLibrary.Monster[monsterNumber].frontSprite = Resources.Load("Enemy") as Texture2D;
        //characterLibrary.Monster[monsterNumber].backSprite = Resources.Load("Enemy") as Texture2D;

        //characterLibrary.Hero[monsterNumber].frontSprite= Resources.Load("Hero(Before)") as Texture2D;
        //characterLibrary.Hero[monsterNumber].transformation = Resources.Load("Enemy2") as Texture2D;

        //road.SaveDateGeneration();
        

        if (firstPlay)
        {
            //PlayerPrefs.DeleteAll();
            //GManager.instance.monsterNumber = 1;
            //road.savePlayerDate();
            road.roadPlayerDate();
            //monsterNumber = 1;
            selectMonsterNumber = 0;
            evolutionNumber = 0;
            playerLevel = 1;
            monsterDate = new int[15];
            monsterName = ("");
            characterType = CharacterLibrary.CharacterType.None;
            homePlay = true;

            firstPlay = false;

        }
        
    }

}
