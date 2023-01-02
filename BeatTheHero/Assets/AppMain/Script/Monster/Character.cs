using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �o�g���Ŏg�p���郆�j�b�g�̐����G�R���X�g���N�^
/// </summary>
public class Character : MonoBehaviour
{
    //�x�[�X�ƂȂ�f�[�^  
     CharacterLibrary.CharacterBase sikibetu;
   
 
    //�X�e�[�^�X�̑���
    public new string  name { get; set; }
    public int level { get; set; }
    public int  MaxHP { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int Speed { get; set; }
    public int Intellect { get; set; }
    public int Damage { get; set; }
    public CharacterLibrary.CharacterCondition condition { get; set; }
    public int turn = 0;
    public int mototi = 0;
    

    //HP�̑���
    public int HP { get; set; }

    //�g����Z
    //public MoveLibrary moveLibrary;
    public List<MoveLibrary.MoveBase> Moves { get; set; }

    //public bool characterbool = true;

    /// <summary>
    /// �R���X�g���N�^�[�F�������̏�����
    /// </summary>
    /// <param name="characterbool"></param>
    /// <param name="characterLibrary"></param>
    /// <param name="moveLibrary"></param>
    /// <param name="i"></param>
    public Character(bool characterbool, CharacterLibrary characterLibrary, MoveLibrary moveLibrary, int i)
    {
        if (characterbool)
        {
            sikibetu = characterLibrary.Monster[i];
        }
        else
        {
            sikibetu = characterLibrary.Hero[i];
        }

        //��������L�����̃X�e�[�^�X���f
        name =  sikibetu.name;
        level = sikibetu.LV;
        MaxHP = sikibetu.HP;
        Attack = sikibetu.STR;
        Defence = sikibetu.VIT;
        Speed = sikibetu.AGI;
        Intellect = sikibetu.INT;
        condition = sikibetu.condition;
        

        HP = MaxHP;

        Moves = new List<MoveLibrary.MoveBase>();

        //���x���ɉ����Ďg����Z�̕ω�
        if (level >= 0 && level <= 25)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
        }
        else if (level >= 26 && level <= 50)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
        }
        else if (level >= 51 && level <= 70)
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
            Moves.Add(moveLibrary.Move[sikibetu.thirdMove]);
            Moves.Add(moveLibrary.Move[sikibetu.forceMove]);
        }
        else
        {
            Moves.Add(moveLibrary.Move[sikibetu.firstMove]);
            Moves.Add(moveLibrary.Move[sikibetu.secondMove]);
            Moves.Add(moveLibrary.Move[sikibetu.thirdMove]);
            Moves.Add(moveLibrary.Move[sikibetu.forceMove]);
            Moves.Add(moveLibrary.Move[sikibetu.fifthMove]);

        }
    }
    

    

    /// <summary>
    /// �_���[�W�̌v�Z����
    /// </summary>
    /// <param name="move"></param>
    /// <param name="character"></param>
    /// <returns></returns>
    public DamageDetails TakeDamage(MoveLibrary.MoveBase move, Character character)
    {
        //�N���e�B�J��
        float critical = 1f;
        if(Random.value * 100 <= 6.25f) //6.25���̊m���ŃN���e�B�J��
        {
            critical = 2f;
        }

        //Type�����@�ύX��CharacterLibrary����
        float type = CharacterLibrary.CharacterTypeChart.GetCharacterEffectivenss(move.type, sikibetu.type);
        DamageDetails damageDetails = new DamageDetails�@//�U����Ԃ̏�����
        {
            Fainted = false,
            Critical = critical,
            TypeEffectiveness = type,
            
             
        };


        //float modifiers = Random.Range(0.5f, 1f) * type * critical; //�^����_���[�W�̗h�炬
        //float a = (2 * character.level + 10) / 250f;�@//���x���ɉ������U����
        //float b = a * move.power * ((float)character.Attack / sikibetu.VIT) + 2;
        //int damage = Mathf.FloorToInt(b * modifiers);

        float c = move.power * (((float)character.Attack) / (sikibetu.VIT)) * (((float)character.level + 4) / 90) ;
        float d =  type * critical * Random.Range(0.5f, 1f);
        int damage = Mathf.FloorToInt(c * d );
        
        if(damage == 0)
        {
            damage++;
            Damage = damage;
            //Debug.Log($"{damage}");
            HP -= damage;
        }
        else
        {
            Damage = damage;
            //Debug.Log($"{damage}");
            HP -= damage;
        }
        

        //HP��0�ȉ��ɂȂ�����C��̏���
        if (HP <= 0)
        {
            HP = 0;
            damageDetails.Fainted = true;
        }

        return damageDetails;
    
    }
    
    /// <summary>
    /// �U���Z�̐ݒ�
    /// </summary>
    /// <returns></returns>
    public MoveLibrary.MoveBase GetCharaRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }

    /// <summary>
    /// ��Ԉُ�̃_���[�W�v�Z
    /// </summary>
    /// <param name="battleUnit"></param>
    /// <returns></returns>
    public StateProcessing statEfficacy(BattleUnit battleUnit)
    {

        StateProcessing stateProcessing = new StateProcessing
        {
            Fainted = false,
            TurnFrequency = turn,
            nowCondition = sikibetu.condition,
        };

        //�Ώ��Ȃ�HP����5���̃_���[�W�i�Œᐔ�l1�j
        if (battleUnit.character.condition == CharacterLibrary.CharacterCondition.�Ώ�)
        {
            
            float a = (sikibetu.HP) * 0.05f;
            int damage = Mathf.FloorToInt(a);
            Damage = damage;

            if(damage < 1)
            {
                damage = 1;
            }

            HP -= damage;

        }
        //�łȂ�HP����5���̃_���[�W�i�Œᐔ�l1�j
        else if (battleUnit.character.condition == CharacterLibrary.CharacterCondition.�h�N�h�N)
        {
            float a = (sikibetu.HP) * 0.15f;
            int damage = Mathf.FloorToInt(a);
            Damage = damage;

            if (damage < 1)
            {
                damage = 1;
            }

            HP -= damage;
        }
        else
        {

        }

        //HP��0�ȉ��ɂȂ�����C��̏���
        if (HP <= 0)
        {
            HP = 0;
            stateProcessing.Fainted = true;
        }

        return stateProcessing;
;
    }

    /// <summary>
    /// �_�C�����O�ɓ���_���[�W�̗L�������m
    /// </summary>
    public class DamageDetails
    {
        public bool Fainted { get; set; }
        public float Critical { get; set; }
        public float TypeEffectiveness { get; set; }

       
       
    }

    public class StateProcessing
    {
        public bool Fainted { get; set; }
        public int TurnFrequency { get; set; }
        public CharacterLibrary.CharacterCondition nowCondition { get; set; }
    }
}
