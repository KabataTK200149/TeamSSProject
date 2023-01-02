using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �L�����N�^�琬�ł̃L�����N�^�X�e�[�^�X�̕\��
/// </summary>
public class SelectMonsterrHub : MonoBehaviour
{
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;
    [SerializeField] StatusPointBase pointBase;
    [SerializeField] XPBar xpBar;

    [SerializeField] GameObject characterPointBox; //�\������GameObject
    [SerializeField] GameObject experience;  //XP�o�[��gameobject�擾

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Text TypeText;
    [SerializeField] Text XPText;
    [SerializeField] Text HPText;
    [SerializeField] Text STRText;
    [SerializeField] Text VITText;
    [SerializeField] Text AGIText;
    [SerializeField] Text INTText;



    private void Update()
    {

        if (GManager.instance.statusBarPush && GManager.instance.sceneTag == GManager.GameSceneTag.STRENGTHEN)
        {
            DecisionStrengthenMonster(GManager.instance.selectMonsterNumber);

            //�X�L������{�b�N�X��\��������bool�̏�����
            GManager.instance.statusBarPush = false;
        }
       
    }

    /// <summary>
    /// �L�����N�^�琬�ɂ�����L�����N�^���\������
    /// </summary>
    /// <param name="i"></param>
    public void DecisionStrengthenMonster(int i)
    {
        road.roadMonsterDate();
        

        nameText.text = characterLibrary.Monster[i].name;
        levelText.text = ($"{characterLibrary.Monster[i].LV.ToString()}/99");
        TypeText.text = characterLibrary.Monster[i].type.ToString();
        xpBar.SetXPSmooth(characterLibrary.Monster[i].LV, characterLibrary.Monster[i].XP, experience);

        pointBase.skillPoint = characterLibrary.Monster[i].skilPoint;
        pointBase.HPPoint = characterLibrary.Monster[i].HP;
        pointBase.STRPoint = characterLibrary.Monster[i].STR;
        pointBase.VITPoint = characterLibrary.Monster[i].VIT;
        pointBase.AGIPoint = characterLibrary.Monster[i].AGI;
        pointBase.INTPoint = characterLibrary.Monster[i].INT;

        characterPointBox.SetActive(true);

    }
}
