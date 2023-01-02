using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// キャラクターの情報
/// </summary>
public class CharacterLibrary : MonoBehaviour
{
    static Texture2D defaultFrontSprite;
    static Texture2D defaultBackSprite;
    static Texture2D defaultTransformation;

    /// <summary>
    /// モンスターのタイプのリスト
    /// </summary>
    public enum CharacterType
    {
        None,
        ノーマル,
        炎,
        水,
        雷,
        風,
        毒,

    }

    

    /// <summary>
    /// モンスターの状態のリスト
    /// </summary>
    public enum CharacterCondition
    {
        None,
        火傷,
        ジメジメ,
        追い風,
        麻痺,
        ドクドク,
    }

    /// <summary>
    /// キャラクターの構造体
    /// </summary>
    public struct CharacterBase
    {
        public string name;
        public int evolutionLV;
        public CharacterType type;
        public int LV;
        public int HP;
        public int STR;
        public int VIT;
        public int AGI;
        public int INT;
        public int skilPoint;
        public int XP;

        public int firstMove;
        public int secondMove;
        public int thirdMove;
        public int forceMove;
        public int fifthMove;

        public int firstSkill;
        public int secondSkill;

        public CharacterCondition condition;
        public int conditionTurn;

        public Texture2D frontSprite;
        public Texture2D backSprite;
        public Texture2D transformation;

        public string frontSpriteDateName;
        public string backSpriteDateName;
        public string transformationDateName;

        //コンストラクタ
        public CharacterBase(string name, int evolutionLV, CharacterType type, int LV, int HP, int STR , int VIT , int AGI , int INT , int skilPoint , int XP, int firstMove , int secondMove , int thirdMove , int forceMove , int fifthMove , int firstSkill , int secondSkill, CharacterCondition condition , int conditionTurn , Texture2D frontSprite , Texture2D backSprite , Texture2D transformation, string frontSpriteDateName, string backSpriteDateName, string transformationDateName)
        {
            this.name = name;
            this.evolutionLV = evolutionLV;
            this.type = type;
            this.LV = LV;
            this.HP = HP;
            this.STR = STR;
            this.VIT = VIT;
            this.AGI = AGI;
            this.INT = INT;
            this.skilPoint = skilPoint;
            this.XP = XP;

            this.firstMove = firstMove;
            this.secondMove = secondMove;
            this.thirdMove = thirdMove;
            this.forceMove = forceMove;
            this.fifthMove = fifthMove;

            this.firstSkill = firstSkill;
            this.secondSkill = secondSkill;

            this.condition = condition;
            this.conditionTurn = conditionTurn;

            this.frontSprite = frontSprite;
            this.backSprite = backSprite;
            this.transformation = transformation;

            this.frontSpriteDateName = frontSpriteDateName;
            this.backSpriteDateName = backSpriteDateName;
            this.transformationDateName = transformationDateName;

        }
    }


    /// <summary>
    /// 怪人のステータスデータ
    /// </summary>
    private CharacterBase[] monster = new CharacterBase[] //初期化
     {
         //name, 進化度合（進化なし1、進化済み2), type, LV, HP, STR, VIT, AGI, INT, SKLL, XP, 1Move, 2Move, 3Move, 4Move, 5Move, 1Skill, 2Skill, Condition, conditionTurn, frontSprite, backSprite, transformation
         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"), //0番
         new CharacterBase("ウルフェンサー", 2, CharacterType.水, 25, 110, 1200, 75, 70, 95, 500, 900, 1, 21, 22, 24, 25, 3, 1, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "vil-1-af-pow-blu", "vil-1-af-pow-blu", "vil-1-af-pow-blu"),
         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
          new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
       
         //10
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),

         //20
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                          new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
         
         //30
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
 
         //40
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),

         //50
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                          new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
       
         //60
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
  
         //70
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                      new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                        new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                          new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                            new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),

         //80
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                          new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                            new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),

         //90
           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
             new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
               new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                 new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                   new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                     new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                       new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                           new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
                            new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"),
   
         //100

     };

    /// <summary>
    /// ヒーローのステータスデータ（const）
    /// </summary>
    private CharacterBase[] hero = new CharacterBase[] //初期化
    {
         //name, 進化度合（進化なし1、進化済み2), type, LV, HP, STR, VIT, AGI, INT, SKLL, XP, 1Move, 2Move, 3Move, 4Move, 5Move, 1Skill, 2Skill, Condition, conditionTurn, frontSprite, backSprite, transformation
         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"), //0番
        new CharacterBase("ヒーロー1号", 0, CharacterType.炎, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-red", "", "hero2-af-red"),
         new CharacterBase("ヒーロー2号", 0, CharacterType.水, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-blu", "", "hero2-af-blu"),
           new CharacterBase("ヒーロー3号", 0, CharacterType.風, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-grn", "", "hero2-af-grn"),

    };

    
    public CharacterBase[] Monster { get => monster; set => monster = value; }

    public CharacterBase[] Hero { get => hero;  }
   





    /// <summary>
    /// タイプ相性表二次元配列
    /// </summary>
    public class CharacterTypeChart
    {
        static float[][] chart =
        {
            //攻撃＼防御　　　　　ノーマル  炎　水　雷　風　毒
      　 /*ノーマル*/ new float[]{ 1f, 1f, 1f, 1f, 1f, 1f},
             /*炎*/   new float[]{ 1f, 1f, 0.75f, 1f, 1.5f, 1f},
         　　/*水*/   new float[]{ 1f, 1.5f, 1f, 0.75f, 1f, 1f},
          　 /*雷*/   new float[]{ 1f, 1f, 1.5f, 1f, 0.75f, 1f},
             /*風*/   new float[]{ 1f, 0.75f, 1f, 1.5f, 1f, 1f},
             /*毒*/   new float[]{ 1f, 1f, 1f, 1f, 1f, 1f},
        };


        /// <summary>
        /// タイプ相性を見て攻撃力に変化を与える
        /// </summary>
        /// <param name="attackType"></param>
        /// <param name="defenseType"></param>
        /// <returns></returns>
        public static float GetCharacterEffectivenss(CharacterType attackType, CharacterType defenseType)
        {
            if (attackType == CharacterType.None || defenseType == CharacterType.None)
            {
                return 1f;
            }

            int row = (int)attackType - 1;
            int col = (int)defenseType - 1;
            return chart[row][col];
        }
    }

  
}

