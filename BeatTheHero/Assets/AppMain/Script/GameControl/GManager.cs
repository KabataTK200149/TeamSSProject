using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLYAER.SYSTEM;

public class GManager : MonoBehaviour
{

    /// <summary>
    /// ゲームシーンを示す
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
    public int monsterNumber { get; set; }//モンスターの製造番号
    public int selectMonsterNumber { get; set; } //育成や進化の際に使用されるモンスターが何番目なのかを保存する変数
    public int evolutionNumber { get; set; } //進化の選択先を保存する
    public int battleMonsterNunber { get; set; } //バトルの時に使用されるモンスターの番号を保存する変数
    public int selectQuestNumber { get; set; } //クエストを選択するとき、どの番号のクエストが選択されたのか保存する関数
    public int[] monsterDate { get; set; } //モンスターのステータスを入れる配列100体まで製造可 
    public string monsterName { get; set; }
    public CharacterLibrary.CharacterType characterType { get; set; }
    public byte playerLevel { get; set; }

    public GameSceneTag sceneTag { get; set; } = GameSceneTag.NONE;

    public List<InventoryDateBase> itemInventory { get; set; } = new List<InventoryDateBase>();

    public bool statusBarPush { get; set; }

    public bool conditionNotClear { get; set; } = false; //進化条件などの条件ををクリアしているかを判定する

    bool firstPlay { get; set; } = true; //一番最初のプレイかどうかを判別
    public bool homePlay, buttolDefeat, evolutionSelect;
    public static GManager instance = null;

    


    public void Awake()
    {
        //このゲームオブジェクトに何もデータが入っていなければこのインスタンスを入れる
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

    //プレイが初めてだったらモンスターの製造番号を0にして、モンスターデータの配列を作成する
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
