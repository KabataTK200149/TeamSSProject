using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using STRENGTHEN.SYSTEM;

/// <summary>
/// �i����ɑI�����������X�^�[�ɐi�����邽�߂̏�����\������
/// </summary>
public class SelectEvolutionMonsterButton : MonoBehaviour,
    IPointerDownHandler
{
    public System.Action onClickCallback;

    EvolutionMonsterSet evolutionMonster = new EvolutionMonsterSet();

    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] ItemDataBase itemData;
    [SerializeField] GameObject verificationScreen;
    [SerializeField] Image originalMonsterImage;
    [SerializeField] Image evolutionMonsterImage;
    [SerializeField] Text lvText;
    [SerializeField] Text AbilityText;
    [SerializeField] Text ItemText;

    public void OnPointerDown(PointerEventData eventData)
    {
        
            GManager.instance.conditionNotClear = false;

            //�i���O�̃����X�^�[��\��
            originalMonsterImage.sprite = Sprite.Create((Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D), new Rect(0, 0, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).width, (Resources.Load(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName) as Texture2D).height), Vector2.zero);

            //�i����̃����X�^�[��\��
            evolutionMonsterImage.sprite = Sprite.Create((Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D), new Rect(0, 0, (Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D).width, (Resources.Load(evolutionMonster.ImageSelection(characterLibrary, (GManager.instance.evolutionNumber - 1))) as Texture2D).height), Vector2.zero);

            //�i����̃����X�^�[�̃C���[�W�̐F�����ɂ���
            evolutionMonsterImage.color = new Color32(0, 0, 0, 255);

            lvText.text = evolutionMonster.LVStringSetting(characterLibrary); //���x���e�L�X�g�ύX
            AbilityText.text = evolutionMonster.AbilityStringSetting(characterLibrary); //�X�e�[�^�X�e�L�X�g�ύX
            ItemText.text = evolutionMonster.ItemStringSetting(itemData); //�A�C�e���e�L�X�g�ύX

            if (!evolutionMonster.LVCheck(characterLibrary))
            {
                lvText.color = new Color32(122, 122, 122, 255); //�������B���̐F�i�D�F)
                GManager.instance.conditionNotClear = true;
            }

            if (!evolutionMonster.AbilityCheck(characterLibrary))
            {
                AbilityText.color = new Color32(122, 122, 122, 255); //�������B���̐F�i�D�F)
                GManager.instance.conditionNotClear = true;
            }

            if (!evolutionMonster.ItemCheck())
            {
                ItemText.color = new Color32(122, 122, 122, 255); //�������B���̐F�i�D�F)
                GManager.instance.conditionNotClear = true;
            }

            verificationScreen.SetActive(true);
 

    }



}



