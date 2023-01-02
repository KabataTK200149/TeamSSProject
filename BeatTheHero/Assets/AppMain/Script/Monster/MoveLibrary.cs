using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLibrary : MonoBehaviour
{

  public struct MoveBase
  {
        public string name;
        public string description;
        public CharacterLibrary.CharacterType type;
        public int power;
        public int accuracy; //正確性
        public int effect; //戦闘エフェクト
        public CharacterLibrary.CharacterCondition efficacy; //戦闘効果

        public MoveBase(string name, string description, CharacterLibrary.CharacterType type, int power, int accuracy, int effect, CharacterLibrary.CharacterCondition efficacy)
        {
            this.name = name;
            this.description = description;
            this.type = type;
            this.power = power;
            this.accuracy = accuracy;
            this.effect = effect;
            this.efficacy = efficacy;
        }
  }


    private MoveBase[] move = new MoveBase[] //初期化
    {   // 名前、　説明、　属性、　攻撃力、　命中率、　エフェクト、　戦闘効果

        new MoveBase("","",0,0,0,0,0),
        new MoveBase("パンチ","パンチ",CharacterLibrary.CharacterType.ノーマル,65,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("キック","キック",CharacterLibrary.CharacterType.ノーマル,50,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("スラッシュ","斬撃",CharacterLibrary.CharacterType.ノーマル,60,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("チョップ","チョップ",CharacterLibrary.CharacterType.ノーマル,55,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("アッパー","アッパー",CharacterLibrary.CharacterType.ノーマル,55,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0), new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0),

        new MoveBase("フレア","フレア",CharacterLibrary.CharacterType.炎,65,100,0,CharacterLibrary.CharacterCondition.火傷),
        new MoveBase("メテオフィニッシュ","メテオフィニッシュ",CharacterLibrary.CharacterType.炎,75,100,0,CharacterLibrary.CharacterCondition.火傷),
        new MoveBase("サンライズパワー","サンライズパワー",CharacterLibrary.CharacterType.炎,0,100,0,CharacterLibrary.CharacterCondition.火傷),
        new MoveBase("バーストクラッシャー","バーストクラッシャー",CharacterLibrary.CharacterType.炎,90,100,0,CharacterLibrary.CharacterCondition.火傷),
        new MoveBase("バーニングダイナマイト","バーニングダイナマイト",CharacterLibrary.CharacterType.炎,150,100,0,CharacterLibrary.CharacterCondition.火傷),
        new MoveBase("スプラッシュ","スプラッシュ",CharacterLibrary.CharacterType.水,50,100,0,CharacterLibrary.CharacterCondition.ジメジメ),
        new MoveBase("アクアバッシャー","アクアバッシャー",CharacterLibrary.CharacterType.水,70,100,0,CharacterLibrary.CharacterCondition.ジメジメ),
        new MoveBase("オリオンチャージ","オリオンチャージ",CharacterLibrary.CharacterType.水,0,100,0,CharacterLibrary.CharacterCondition.ジメジメ),
        new MoveBase("ハイドロドライブ","ハイドロドライブ",CharacterLibrary.CharacterType.水,90,100,0,CharacterLibrary.CharacterCondition.ジメジメ),
        new MoveBase("クォーターカノン","クォーターカノン",CharacterLibrary.CharacterType.水,100,100,0,CharacterLibrary.CharacterCondition.ジメジメ),
        new MoveBase("リーフ","リーフ",CharacterLibrary.CharacterType.風,60,100,0,CharacterLibrary.CharacterCondition.追い風),
        new MoveBase("ストームバレット","ストームバレット",CharacterLibrary.CharacterType.風,70,100,0,CharacterLibrary.CharacterCondition.追い風),
        new MoveBase("フォレストアップ","フォレストアップ",CharacterLibrary.CharacterType.風,0,100,0,CharacterLibrary.CharacterCondition.追い風),
        new MoveBase("バタフライチェスト","バタフライチェスト",CharacterLibrary.CharacterType.風,90,100,0,CharacterLibrary.CharacterCondition.追い風),
        new MoveBase("エメロードタイフーン","エメロードタイフーン",CharacterLibrary.CharacterType.風,100,100,0,CharacterLibrary.CharacterCondition.追い風),
        new MoveBase("シャイン","シャイン",CharacterLibrary.CharacterType.雷,55,100,0,CharacterLibrary.CharacterCondition.麻痺),
        new MoveBase("ガンマフラッシュ","ガンマフラッシュ",CharacterLibrary.CharacterType.雷,80,100,0,CharacterLibrary.CharacterCondition.麻痺),
        new MoveBase("ソーラー・ゲート","ソーラー・ゲート",CharacterLibrary.CharacterType.雷,0,100,0,CharacterLibrary.CharacterCondition.麻痺),
        new MoveBase("ボルティックカラミティ","ボルティックカラミティ",CharacterLibrary.CharacterType.雷,85,100,0,CharacterLibrary.CharacterCondition.麻痺),
        new MoveBase("ライジングサンダー","ライジングサンダー",CharacterLibrary.CharacterType.雷,100,100,0,CharacterLibrary.CharacterCondition.麻痺),
        new MoveBase("ヴァイオ","ヴァイオ",CharacterLibrary.CharacterType.毒,45,100,0,CharacterLibrary.CharacterCondition.ドクドク),
        new MoveBase("ポイズンブレイク","ポイズンブレイク",CharacterLibrary.CharacterType.毒,75,100,0,CharacterLibrary.CharacterCondition.ドクドク),
        new MoveBase("ダーティオーラ","ダーティオーラ",CharacterLibrary.CharacterType.毒,0,100,0,CharacterLibrary.CharacterCondition.ドクドク),
        new MoveBase("アシッドクラッシュ","アシッドクラッシュ",CharacterLibrary.CharacterType.毒,90,100,0,CharacterLibrary.CharacterCondition.ドクドク),
        new MoveBase("ネビュラクラスタ","ネビュラクラスタ",CharacterLibrary.CharacterType.毒,95,100,0,CharacterLibrary.CharacterCondition.ドクドク),
    };

    public  MoveBase[] Move { get => move; set => move = value; }

}
