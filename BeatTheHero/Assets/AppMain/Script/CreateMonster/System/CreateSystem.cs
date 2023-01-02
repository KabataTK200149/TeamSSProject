using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MonsterCreat.Move;
using MonsterCreat.Selection;

/// <summary>
/// �L�����N�^�[�̉摜�o�����o�ƃX�e�[�^�X�\�����o�̃V�X�e��
/// </summary>
public class CreateSystem : MonoBehaviour
{
    [SerializeField] GameObject createMonsterObject;
    [SerializeField] GameObject createCharacterBase;
    [SerializeField] GameObject createCircleObject;

    [SerializeField] MonsterStatusDiecting monsterStatus;
    [SerializeField] SkillSorting skillSorting;

    CreatDirection monsterCreatMove = new CreatDirection(); //�����X�^�[�������̓������Q��

    Image image_component;

    public void Start()
    {
        image_component = createCharacterBase.GetComponent<Image>();
        StartCoroutine(FirstAction());
    }


    IEnumerator FirstAction()
    {
        skillSorting.SkillCheck();  //�����X�^�[�̏����Z�ƃX�L��������
        monsterStatus.ReflectionText(); //�e�L�X�g�̕\�����e��ύX

        monsterCreatMove.ExpansionEnterAnimation(createMonsterObject, image_component);
        yield return new WaitForSeconds(3f);

        monsterCreatMove.ExpansionCircleEnterAnimation(createCircleObject);
        yield return new WaitForSeconds(1f);

        monsterCreatMove.ExpansionCircleFainAnimation(createCircleObject);
        yield return new WaitForSeconds(0.8f);

        monsterCreatMove.ExpansionDetailAnimation(createCharacterBase);
        yield return new WaitForSeconds(1f);

        monsterStatus.HPTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.STRTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.VITTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.AGITransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.INTTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.TypeTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.FirstMoveTransAnimation();
        yield return new WaitForSeconds(1f);

        monsterStatus.FirstSkillTransAnimation();
        yield return new WaitForSeconds(1f);



        if (skillSorting.skill2 != 0)
        {
            monsterStatus.SecondSkillEnterAnimation();
            yield return new WaitForSeconds(0.5f);

            monsterStatus.SecondSkillExitAnimation();
            yield return new WaitForSeconds(1f);
        }
       
    }

}
