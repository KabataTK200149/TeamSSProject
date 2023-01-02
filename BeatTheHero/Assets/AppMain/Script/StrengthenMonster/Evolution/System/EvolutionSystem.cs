using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using STRENGTHEN.SYSTEM;
using DG.Tweening;

/// <summary>
/// �i��������y�[�W�Ői�����̃����X�^�[��I�������Ƃ��̓���
/// </summary>
public class EvolutionSystem : MonoBehaviour
{
    EvolutionMonsterSet evolutionMonster = new EvolutionMonsterSet(); //Strengthen.system�̃N���X�̎擾

    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;
    [SerializeField] GameObject monsterBoxObj;
    [SerializeField] GameObject parentObj;
    [SerializeField] GameObject evolutionObj;
    [SerializeField] Image originMonsterImage;

    public List<GameObject> createItemImageObj = new List<GameObject>();
    Vector3 originalScale;

    private void Start()
    {
        originalScale = evolutionObj.transform.localScale;
    }

    private void Update()
    {
        if(GManager.instance.statusBarPush && GManager.instance.sceneTag == GManager.GameSceneTag.EVOLUTION)
        {
            //�����X�^�[���i�����Ă��邩���Ă��Ȃ����𒲂ׂāA�o����Ȃ�\������
            if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].evolutionLV == 1)
            {
                evolutionObj.transform.localScale = new Vector2(0.7f, 0.7f);

                evolutionObj.SetActive(true);
                EvolutionJudgeSystem();
                evolutionObj.transform.DOScale(new Vector3(originalScale.x, originalScale.y, originalScale.z), 1f);

                GManager.instance.statusBarPush = false;


            }
            else
            {
                GManager.instance.statusBarPush = false;
                Debug.Log("�i���o���܂���");
            }
        }
    }

    /// <summary>
    /// �i������I���W�i���̃����X�^�[�Ƃ��̐i�����\��
    /// </summary>
    void EvolutionJudgeSystem()
    {
        originMonsterImage.sprite = Sprite.Create((Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D), new Rect(0, 0, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).width, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).height), Vector2.zero);

        evolutionMonster.SetSystem(createItemImageObj, road, monsterBoxObj, parentObj, characterLibrary);


    }

}
