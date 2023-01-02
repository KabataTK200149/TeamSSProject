using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �i���̃{�b�N�X�ɕ\������郂���X�^�[��\��������
/// </summary>
public class SelectMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterBoxObj;
    [SerializeField] GameObject parentObj;
    [SerializeField] SelectMonsterrHub monsterrHub;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;

    private List<GameObject> createItemImageObj = new List<GameObject>();

    public void Start()
    {
        //�����X�^�[�ԍ���������
        GManager.instance.selectMonsterNumber = 0;
        GManager.instance.evolutionNumber = 0;
  
        //�����X�^�[�{�b�N�X�̔z�u
        int posX = ((340 / 2) + ((1920 - (340 * 4)) / 5));
        int pushPointY = 600;
        int pushPointX = (posX - 960) ;
        createItemImageObj.Clear();

        //road.roadPlayerDate();
        road.roadMonsterDate();

        for(int i = 0; i < GManager.instance.monsterNumber; i++)
        {
            int monsterNo = i + 1; //�����X�^�[�̃��C�u������0�Ԃ�NULL�Ȃ̂�+1���Ă�����

            GameObject instansObj = Instantiate(monsterBoxObj, parentObj.transform); //�����X�^�[�{�b�N�X�̐���
            instansObj.transform.localPosition = new Vector3(pushPointX, pushPointY, 0); //���������{�b�N�X�̈ʒu�𒲐�

            instansObj.GetComponent<SelectMonsterButton>().monsterNumber = (monsterNo); //���������{�b�N�X�Ɍʔԍ���t�^

            //�e�L�X�g�ύX
            characterLibrary.Monster[monsterNo].frontSprite = Resources.Load(characterLibrary.Monster[monsterNo].frontSpriteDateName) as Texture2D;
            instansObj.GetComponent<Image>().sprite = Sprite.Create(characterLibrary.Monster[monsterNo].frontSprite, new Rect(0, 0, characterLibrary.Monster[monsterNo].frontSprite.width, characterLibrary.Monster[monsterNo].frontSprite.height), Vector2.zero);

            //�i���o���邩�m�F���ďo���Ȃ��Ȃ�F��ς���
            if(characterLibrary.Monster[monsterNo].evolutionLV != 1 && GManager.instance.sceneTag == GManager.GameSceneTag.EVOLUTION)
            {
                instansObj.GetComponent<Image>().color = new Color32(122, 122, 122, 255); //�i���s�\�ȃ����X�^�[�̐F�i�D�F)
            }

            createItemImageObj.Add(instansObj);
     
            //�����X�^�[�{�b�N�X�̈ʒu�𒲐�
            if ((monsterNo) % 4 == 0)
            {
                pushPointY -= 400;
                pushPointX = (posX - 960);
            }
            else
            {
                pushPointX += posX + (posX - ((1920 - (340 * 4)) / 5));
            }

        }
        
        
    }

}
