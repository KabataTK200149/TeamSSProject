using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


/// <summary>
/// �L�����N�^�[�̏��
/// </summary>
public class CharacterLibrary : MonoBehaviour
{
    static Texture2D defaultFrontSprite;
    static Texture2D defaultBackSprite;
    static Texture2D defaultTransformation;

    /// <summary>
    /// �����X�^�[�̃^�C�v�̃��X�g
    /// </summary>
    public enum CharacterType
    {
        None,
        �m�[�}��,
        ��,
        ��,
        ��,
        ��,
        ��,

    }

    

    /// <summary>
    /// �����X�^�[�̏�Ԃ̃��X�g
    /// </summary>
    public enum CharacterCondition
    {
        None,
        �Ώ�,
        �W���W��,
        �ǂ���,
        ���,
        �h�N�h�N,
    }

    /// <summary>
    /// �L�����N�^�[�̍\����
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

        //�R���X�g���N�^
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
    /// ���l�̃X�e�[�^�X�f�[�^
    /// </summary>
    private CharacterBase[] monster = new CharacterBase[] //������
     {
         //name, �i���x���i�i���Ȃ�1�A�i���ς�2), type, LV, HP, STR, VIT, AGI, INT, SKLL, XP, 1Move, 2Move, 3Move, 4Move, 5Move, 1Skill, 2Skill, Condition, conditionTurn, frontSprite, backSprite, transformation
         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"), //0��
         new CharacterBase("�E���t�F���T�[", 2, CharacterType.��, 25, 110, 1200, 75, 70, 95, 500, 900, 1, 21, 22, 24, 25, 3, 1, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "vil-1-af-pow-blu", "vil-1-af-pow-blu", "vil-1-af-pow-blu"),
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
    /// �q�[���[�̃X�e�[�^�X�f�[�^�iconst�j
    /// </summary>
    private CharacterBase[] hero = new CharacterBase[] //������
    {
         //name, �i���x���i�i���Ȃ�1�A�i���ς�2), type, LV, HP, STR, VIT, AGI, INT, SKLL, XP, 1Move, 2Move, 3Move, 4Move, 5Move, 1Skill, 2Skill, Condition, conditionTurn, frontSprite, backSprite, transformation
         new CharacterBase("null", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "null", "null", "null"), //0��
        new CharacterBase("�q�[���[1��", 0, CharacterType.��, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-red", "", "hero2-af-red"),
         new CharacterBase("�q�[���[2��", 0, CharacterType.��, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-blu", "", "hero2-af-blu"),
           new CharacterBase("�q�[���[3��", 0, CharacterType.��, 25, 94, 94, 94, 94, 94, 0, 1,  3, 11, 12, 14, 15, 5, 11, CharacterCondition.None, 0, defaultFrontSprite, defaultBackSprite, defaultTransformation, "hero-bef-grn", "", "hero2-af-grn"),

    };

    
    public CharacterBase[] Monster { get => monster; set => monster = value; }

    public CharacterBase[] Hero { get => hero;  }
   





    /// <summary>
    /// �^�C�v�����\�񎟌��z��
    /// </summary>
    public class CharacterTypeChart
    {
        static float[][] chart =
        {
            //�U���_�h��@�@�@�@�@�m�[�}��  ���@���@���@���@��
      �@ /*�m�[�}��*/ new float[]{ 1f, 1f, 1f, 1f, 1f, 1f},
             /*��*/   new float[]{ 1f, 1f, 0.75f, 1f, 1.5f, 1f},
         �@�@/*��*/   new float[]{ 1f, 1.5f, 1f, 0.75f, 1f, 1f},
          �@ /*��*/   new float[]{ 1f, 1f, 1.5f, 1f, 0.75f, 1f},
             /*��*/   new float[]{ 1f, 0.75f, 1f, 1.5f, 1f, 1f},
             /*��*/   new float[]{ 1f, 1f, 1f, 1f, 1f, 1f},
        };


        /// <summary>
        /// �^�C�v���������čU���͂ɕω���^����
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

