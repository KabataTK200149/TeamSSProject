using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// クエストの情報保持スクリプト
    /// </summary>
public class QuestStructure : MonoBehaviour
{
    /// <summary>
    /// クエストに必要な情報の構造体
    /// </summary>
  　public struct QuestBase
    {
        public string questName; //名前
        public ushort questAP; //必要体力
        public ushort questLV; //必要LV
        public byte heroQuanity; //ヒーロ―の出現数

        //出現ヒーローの番号：出ないものは0を入力
        public ushort heroNumber1st;
        public byte heroNumber2nd;
        public byte heroNumber3rd;
        public byte heroNumber4th;
        public byte heroNumber5th;

        //クエストのチャレンジの番号：チャレンジの内容や処理は別
        public int questChallenge1st;
        public int questChallenge2nd;
        public int questChallenge3rd;

        public byte questCrearRewardQuanity; //CLEAR報酬の総数
        public int questCrearRewardNumber; //獲得報酬の番号；報酬内容はリストにしておく

        public QuestBase(string questName, ushort questAP, ushort questLV, byte heroQuanity, ushort heroNumber1st, byte heroNumber2nd, byte heroNumber3rd, byte heroNumber4th, byte heroNumber5th, int questChallenge1st, int questChallenge2nd, int questChallenge3rd, byte questCrearRewardQuanity, int questCrearRewardNumber)
        {
            this.questName = questName;
            this.questAP = questAP;
            this.questLV = questLV;
            this.heroQuanity = heroQuanity;
            this.heroNumber1st = heroNumber1st;
            this.heroNumber2nd = heroNumber2nd;
            this.heroNumber3rd = heroNumber3rd;
            this.heroNumber4th = heroNumber4th;
            this.heroNumber5th = heroNumber5th;
            this.questChallenge1st = questChallenge1st;
            this.questChallenge2nd = questChallenge2nd;
            this.questChallenge3rd = questChallenge3rd;
            this.questCrearRewardQuanity = questCrearRewardQuanity;
            this.questCrearRewardNumber = questCrearRewardNumber;
        }
    }

    private QuestBase[] quest = new QuestBase[]
    {
        //クエスト名　消費するコスト　必要なLV　ヒーローの出現数　出現ヒーロー*5　チャレンジ（クエスト）の内容*3　クリア報酬の総数　獲得報酬リストの番号
        new QuestBase("最初のクエスト", 10, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("二人のクエスト", 10, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("書物のクエスト", 10, 1, 1, 3, 1, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("書物のクエスト", 10, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("書物のクエスト", 10, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 5, 0),
    };

    //CLEAR報酬として用意される物を塊として呼び出すためのリスト：獲得報酬を規定分入れたらピリオドとして0を最後に入れる
    public int[,] QuestCrearRewardItems = new int[,]
    {
      {1,1,2,0 }
    };

    public QuestBase[] Quest { get => quest; set => quest = value; }
}
