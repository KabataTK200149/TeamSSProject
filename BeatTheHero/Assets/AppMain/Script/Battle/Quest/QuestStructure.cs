using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// �N�G�X�g�̏��ێ��X�N���v�g
    /// </summary>
public class QuestStructure : MonoBehaviour
{
    /// <summary>
    /// �N�G�X�g�ɕK�v�ȏ��̍\����
    /// </summary>
  �@public struct QuestBase
    {
        public string questName; //���O
        public ushort questAP; //�K�v�̗�
        public ushort questLV; //�K�vLV
        public byte heroQuanity; //�q�[���\�̏o����

        //�o���q�[���[�̔ԍ��F�o�Ȃ����̂�0�����
        public ushort heroNumber1st;
        public byte heroNumber2nd;
        public byte heroNumber3rd;
        public byte heroNumber4th;
        public byte heroNumber5th;

        //�N�G�X�g�̃`�������W�̔ԍ��F�`�������W�̓��e�⏈���͕�
        public int questChallenge1st;
        public int questChallenge2nd;
        public int questChallenge3rd;

        public byte questCrearRewardQuanity; //CLEAR��V�̑���
        public int questCrearRewardNumber; //�l����V�̔ԍ��G��V���e�̓��X�g�ɂ��Ă���

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
        //�N�G�X�g���@�����R�X�g�@�K�v��LV�@�q�[���[�̏o�����@�o���q�[���[*5�@�`�������W�i�N�G�X�g�j�̓��e*3�@�N���A��V�̑����@�l����V���X�g�̔ԍ�
        new QuestBase("�ŏ��̃N�G�X�g", 10, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("��l�̃N�G�X�g", 10, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("�����̃N�G�X�g", 10, 1, 1, 3, 1, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("�����̃N�G�X�g", 10, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 5, 0),
        new QuestBase("�����̃N�G�X�g", 10, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 5, 0),
    };

    //CLEAR��V�Ƃ��ėp�ӂ���镨����Ƃ��ČĂяo�����߂̃��X�g�F�l����V���K�蕪���ꂽ��s���I�h�Ƃ���0���Ō�ɓ����
    public int[,] QuestCrearRewardItems = new int[,]
    {
      {1,1,2,0 }
    };

    public QuestBase[] Quest { get => quest; set => quest = value; }
}
