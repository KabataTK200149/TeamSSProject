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
        public int accuracy; //���m��
        public int effect; //�퓬�G�t�F�N�g
        public CharacterLibrary.CharacterCondition efficacy; //�퓬����

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


    private MoveBase[] move = new MoveBase[] //������
    {   // ���O�A�@�����A�@�����A�@�U���́A�@�������A�@�G�t�F�N�g�A�@�퓬����

        new MoveBase("","",0,0,0,0,0),
        new MoveBase("�p���`","�p���`",CharacterLibrary.CharacterType.�m�[�}��,65,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("�L�b�N","�L�b�N",CharacterLibrary.CharacterType.�m�[�}��,50,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("�X���b�V��","�a��",CharacterLibrary.CharacterType.�m�[�}��,60,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("�`���b�v","�`���b�v",CharacterLibrary.CharacterType.�m�[�}��,55,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("�A�b�p�[","�A�b�p�[",CharacterLibrary.CharacterType.�m�[�}��,55,100,0,CharacterLibrary.CharacterCondition.None),
        new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0), new MoveBase("","",0,0,0,0,0),new MoveBase("","",0,0,0,0,0),

        new MoveBase("�t���A","�t���A",CharacterLibrary.CharacterType.��,65,100,0,CharacterLibrary.CharacterCondition.�Ώ�),
        new MoveBase("���e�I�t�B�j�b�V��","���e�I�t�B�j�b�V��",CharacterLibrary.CharacterType.��,75,100,0,CharacterLibrary.CharacterCondition.�Ώ�),
        new MoveBase("�T�����C�Y�p���[","�T�����C�Y�p���[",CharacterLibrary.CharacterType.��,0,100,0,CharacterLibrary.CharacterCondition.�Ώ�),
        new MoveBase("�o�[�X�g�N���b�V���[","�o�[�X�g�N���b�V���[",CharacterLibrary.CharacterType.��,90,100,0,CharacterLibrary.CharacterCondition.�Ώ�),
        new MoveBase("�o�[�j���O�_�C�i�}�C�g","�o�[�j���O�_�C�i�}�C�g",CharacterLibrary.CharacterType.��,150,100,0,CharacterLibrary.CharacterCondition.�Ώ�),
        new MoveBase("�X�v���b�V��","�X�v���b�V��",CharacterLibrary.CharacterType.��,50,100,0,CharacterLibrary.CharacterCondition.�W���W��),
        new MoveBase("�A�N�A�o�b�V���[","�A�N�A�o�b�V���[",CharacterLibrary.CharacterType.��,70,100,0,CharacterLibrary.CharacterCondition.�W���W��),
        new MoveBase("�I���I���`���[�W","�I���I���`���[�W",CharacterLibrary.CharacterType.��,0,100,0,CharacterLibrary.CharacterCondition.�W���W��),
        new MoveBase("�n�C�h���h���C�u","�n�C�h���h���C�u",CharacterLibrary.CharacterType.��,90,100,0,CharacterLibrary.CharacterCondition.�W���W��),
        new MoveBase("�N�H�[�^�[�J�m��","�N�H�[�^�[�J�m��",CharacterLibrary.CharacterType.��,100,100,0,CharacterLibrary.CharacterCondition.�W���W��),
        new MoveBase("���[�t","���[�t",CharacterLibrary.CharacterType.��,60,100,0,CharacterLibrary.CharacterCondition.�ǂ���),
        new MoveBase("�X�g�[���o���b�g","�X�g�[���o���b�g",CharacterLibrary.CharacterType.��,70,100,0,CharacterLibrary.CharacterCondition.�ǂ���),
        new MoveBase("�t�H���X�g�A�b�v","�t�H���X�g�A�b�v",CharacterLibrary.CharacterType.��,0,100,0,CharacterLibrary.CharacterCondition.�ǂ���),
        new MoveBase("�o�^�t���C�`�F�X�g","�o�^�t���C�`�F�X�g",CharacterLibrary.CharacterType.��,90,100,0,CharacterLibrary.CharacterCondition.�ǂ���),
        new MoveBase("�G�����[�h�^�C�t�[��","�G�����[�h�^�C�t�[��",CharacterLibrary.CharacterType.��,100,100,0,CharacterLibrary.CharacterCondition.�ǂ���),
        new MoveBase("�V���C��","�V���C��",CharacterLibrary.CharacterType.��,55,100,0,CharacterLibrary.CharacterCondition.���),
        new MoveBase("�K���}�t���b�V��","�K���}�t���b�V��",CharacterLibrary.CharacterType.��,80,100,0,CharacterLibrary.CharacterCondition.���),
        new MoveBase("�\�[���[�E�Q�[�g","�\�[���[�E�Q�[�g",CharacterLibrary.CharacterType.��,0,100,0,CharacterLibrary.CharacterCondition.���),
        new MoveBase("�{���e�B�b�N�J���~�e�B","�{���e�B�b�N�J���~�e�B",CharacterLibrary.CharacterType.��,85,100,0,CharacterLibrary.CharacterCondition.���),
        new MoveBase("���C�W���O�T���_�[","���C�W���O�T���_�[",CharacterLibrary.CharacterType.��,100,100,0,CharacterLibrary.CharacterCondition.���),
        new MoveBase("���@�C�I","���@�C�I",CharacterLibrary.CharacterType.��,45,100,0,CharacterLibrary.CharacterCondition.�h�N�h�N),
        new MoveBase("�|�C�Y���u���C�N","�|�C�Y���u���C�N",CharacterLibrary.CharacterType.��,75,100,0,CharacterLibrary.CharacterCondition.�h�N�h�N),
        new MoveBase("�_�[�e�B�I�[��","�_�[�e�B�I�[��",CharacterLibrary.CharacterType.��,0,100,0,CharacterLibrary.CharacterCondition.�h�N�h�N),
        new MoveBase("�A�V�b�h�N���b�V��","�A�V�b�h�N���b�V��",CharacterLibrary.CharacterType.��,90,100,0,CharacterLibrary.CharacterCondition.�h�N�h�N),
        new MoveBase("�l�r�����N���X�^","�l�r�����N���X�^",CharacterLibrary.CharacterType.��,95,100,0,CharacterLibrary.CharacterCondition.�h�N�h�N),
    };

    public  MoveBase[] Move { get => move; set => move = value; }

}
