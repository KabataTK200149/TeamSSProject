using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �l�������o���l��퓬���������X�^�̎����Ă���o���l�ɉ��Z���A�o���l�o�[�̕ϓ��A���̃��x���֕K�v�Ȑ��l�̃e�L�X�g�ύX�A
/// ���x���̃e�L�X�g�ύX�������Ȃ�
/// </summary>
public class ExperienceChange : MonoBehaviour
{
    [SerializeField] GameObject experience;
    [SerializeField] CharacterLibrary characterLibrary;

    public bool first, Second;
    public float currentLV, changeAmount;
    public AudioClip EXpointSound;
    AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    /// <summary>
    /// �l�������o���l�����Z���A�o���l�o�[��ϓ�������
    /// </summary>
    /// <param name="oldLV"></param>
    /// <param name="newLV"></param>
    /// <param name="monsterLVText"></param>
    /// <param name="monsterXPText"></param>
    /// <param name="experience"></param>
    /// <returns></returns>
    public IEnumerator LevelChange(int oldLV, int newLV, Text monsterLVText, Text monsterXPText, GameObject experience)
    {
        if (!first) //�����l�ݒ�
        {
            currentLV = experience.transform.localScale.x; //���Z�O�̌o���l�o�[�̈ʒu�i�ő�l�F1�j
            changeAmount = 1 - currentLV; //���̌o���l�Ƃ��̃��x�����烌�x���A�b�v����̂ɕK�v�Ȍo���l�̊���

            first = true;
        }


        //�����A�l���o���l���Z�O�̃��x���Ɖ��Z��̃��x�����ׁA���Z�O�̃��x�������������
        if (oldLV < newLV)
        {

            while (currentLV < 1 && oldLV != newLV)
            {
                currentLV += changeAmount * Time.deltaTime;
                experience.transform.localScale = new Vector3(currentLV, 1, 1);
                monsterXPText.text = ($"{Mathf.Round((100 * Mathf.Pow(1.1f, oldLV)) - (currentLV * (100 * Mathf.Pow(1.1f, oldLV)))) }");
                yield return null;
       
                if (currentLV >= 1)
                {
                    oldLV++;
                    monsterLVText.text = oldLV.ToString();
                    monsterXPText.text = ($"{(100 * Mathf.Pow(1.1f, oldLV))}");
                    audioSource.PlayOneShot(EXpointSound);
                    currentLV = 0;
                    experience.transform.localScale = new Vector3(currentLV, 1, 1);
                }
            }
 
        }
        
        if(oldLV == newLV)
        {
            changeAmount = characterLibrary.Monster[GManager.instance.battleMonsterNunber].XP / (100 * Mathf.Pow(1.1f, newLV));

            while (currentLV < changeAmount)
            {

                currentLV += changeAmount * Time.deltaTime;
                experience.transform.localScale = new Vector3(currentLV, 1, 1);
                monsterXPText.text = ($"{Mathf.Round((100 * Mathf.Pow(1.1f, oldLV)) - (currentLV * (100 * Mathf.Pow(1.1f, newLV)))) }");
                yield return null;

                if (currentLV >= 1)
                {
                    oldLV++;
                    currentLV = 0;
                }
            }
        }


       
    }
}
