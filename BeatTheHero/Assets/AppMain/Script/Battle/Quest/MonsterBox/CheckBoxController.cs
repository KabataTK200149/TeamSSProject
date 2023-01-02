using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    namespace Entry
    {
        public class CheckBoxController : MonoBehaviour
        {
            /// <summary>
            ///  �{�^���������ꂽ�Ƃ��I�𐔂𑝂₷
            /// </summary>
            /// <param name="monsterNumber"></param>
            /// <param name="toggle"></param>
            public void OnToggleChanged(int monsterNumber, bool toggle)
            {
                QuestSystem questSystem = GameObject.FindGameObjectWithTag("QuestSystem").GetComponent<QuestSystem>();

                if (toggle)
                {
                    questSystem.checkBosTotalNumber++;
                    GManager.instance.battleMonsterNunber = monsterNumber;
                }
                else
                {
                    questSystem.checkBosTotalNumber--;
                    GManager.instance.battleMonsterNunber = 0;
                }

            }


            /// <summary>
            /// �퓬����L�����N�^�[����I�����Ă�����F���D�F�ɂ���&
            /// �i������L�����N�^�[�����łɑI������Ă���̂Ȃ�΃`�F�b�N�}�[�N��\������
            /// </summary>
            public void SurveillanceCheckBox(GameObject characterIconObject = null, bool toggle = true)
            {

                if(GManager.instance.sceneTag == GManager.GameSceneTag.BATTLE)
                {
                    QuestSystem questSystem = GameObject.FindGameObjectWithTag("QuestSystem").GetComponent<QuestSystem>();

                    if (GManager.instance.battleMonsterNunber != 0 && !toggle && questSystem.checkBoxNoReaction)
                    {
                        characterIconObject.gameObject.GetComponent<Image>().color = new Color32(122, 122, 122, 255);
                    }
                    else if (GManager.instance.battleMonsterNunber == 0 && !toggle && !questSystem.checkBoxNoReaction)
                    {
                        characterIconObject.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    }
                }
               
            }
        }
    }
    
}

