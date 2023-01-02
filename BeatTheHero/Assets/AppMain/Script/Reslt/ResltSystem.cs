using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ITEM.ACQUIR;

public class ResltSystem : MonoBehaviour
{
    [SerializeField] public List<GameObject> monsterObjects;
    [SerializeField] public List<Text> monsterLevel;
    [SerializeField] public List<Text> monsterXPText;
    [SerializeField] public List<GameObject> XPPoint;
    [SerializeField] public List<XPBar> xpBar;
    [SerializeField] public List<ExperienceChange> xpBar2;
    [SerializeField] QuestStructure questStructure;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] DisplayMonster displayMonster;
    [SerializeField] SaveAndRoad saveAndroad;
    [SerializeField] ItemDataBase itemData;

    [SerializeField] GameObject originalObj;
    [SerializeField] GameObject parentObj;

    AcquiredItemSystem itemSystem = new AcquiredItemSystem();

    private int exPoint, maxExPoint, overExPoint, oldLV;
    private float oldXP;


    void Start()
    {
        displayMonster.DisplayMonsters();

        if (!GManager.instance.buttolDefeat)
        {
            itemSystem.displayItem(originalObj, parentObj, questStructure, itemData);
            itemSystem.SaveItem(questStructure, saveAndroad); //�l�������A�C�e�����m�F���ĕۑ�
        }


        //�Q�����������X�^�[�̐����������X�^�[��\�����Čo���l�����������Ȃ�
        for (int i = 0; i < questStructure.Quest[GManager.instance.selectQuestNumber].heroQuanity; i++)
        {
            //�o���l�̃o�[�̏����l�ݒ�
            xpBar[i].SetXPSmooth(characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV, characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP, XPPoint[i]);

            //������
            overExPoint = 0;
            oldLV = characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV;
            //float�Ōv�Z�����l���o���l���l�̌ܓ�����int�^�ɕύX���Ă���
            maxExPoint = Mathf.RoundToInt(100 * Mathf.Pow(1.1f, ((float)characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV)));

            if (!GManager.instance.buttolDefeat)
            {
                exPoint = Mathf.RoundToInt((100 * (Mathf.Pow(1.1f, ((float)characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].LV))) + 1) / 5);
            }
            else
            {
                exPoint = Mathf.RoundToInt(((100 * (Mathf.Pow(1.1f, ((float)characterLibrary.Hero[questStructure.Quest[GManager.instance.selectQuestNumber].heroNumber1st].LV))) + 1) / 5) / 10);
            }
           
            oldXP = exPoint;

            //�\���ݒ�
            monsterLevel[i].text = characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV.ToString();
            monsterObjects[i].SetActive(true);
        

            while (overExPoint <= 0 )
            {
     
                if(maxExPoint <= (characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP + exPoint))
                {
                    overExPoint = maxExPoint - (characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP + exPoint);
                    characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV++;
                    characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP = 0;
                    exPoint = (overExPoint * -1);
                }
                else
                {
                    characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP += exPoint;                
                    overExPoint = maxExPoint - (characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP + exPoint);
                }

            }

         
            StartCoroutine(ChangeXPBar(i));


        } 
            
            saveAndroad.saveMonsterDate(GManager.instance.battleMonsterNunber, characterLibrary.Monster[GManager.instance.battleMonsterNunber].name, characterLibrary.Monster[GManager.instance.battleMonsterNunber].evolutionLV, characterLibrary.Monster[GManager.instance.battleMonsterNunber].type, characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV, characterLibrary.Monster[GManager.instance.battleMonsterNunber].HP, characterLibrary.Monster[GManager.instance.battleMonsterNunber].STR, characterLibrary.Monster[GManager.instance.battleMonsterNunber].VIT, characterLibrary.Monster[GManager.instance.battleMonsterNunber].AGI, characterLibrary.Monster[GManager.instance.battleMonsterNunber].INT, characterLibrary.Monster[GManager.instance.battleMonsterNunber].skilPoint, (characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP), characterLibrary.Monster[GManager.instance.battleMonsterNunber].firstMove, characterLibrary.Monster[GManager.instance.battleMonsterNunber].secondMove, characterLibrary.Monster[GManager.instance.battleMonsterNunber].thirdMove, characterLibrary.Monster[GManager.instance.battleMonsterNunber].forceMove, characterLibrary.Monster[GManager.instance.battleMonsterNunber].fifthMove, characterLibrary.Monster[GManager.instance.battleMonsterNunber].firstSkill, characterLibrary.Monster[GManager.instance.battleMonsterNunber].secondSkill, characterLibrary.Monster[GManager.instance.battleMonsterNunber].frontSpriteDateName, characterLibrary.Monster[GManager.instance.battleMonsterNunber].backSpriteDateName);
            
    }
        
    IEnumerator ChangeXPBar(int i)
    {
        yield return xpBar2[i].LevelChange(oldLV, characterLibrary.Monster[GManager.instance.battleMonsterNunber].LV, monsterLevel[i] , monsterXPText[i], XPPoint[i]);
        yield return new WaitForSeconds(3f);
    }

}

  
 

