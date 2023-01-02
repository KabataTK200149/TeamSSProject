using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 獲得した経験値を戦闘したモンスタの持っている経験値に加算し、経験値バーの変動、次のレベルへ必要な数値のテキスト変更、
/// レベルのテキスト変更をおこなう
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
    /// 獲得した経験値を加算し、経験値バーを変動させる
    /// </summary>
    /// <param name="oldLV"></param>
    /// <param name="newLV"></param>
    /// <param name="monsterLVText"></param>
    /// <param name="monsterXPText"></param>
    /// <param name="experience"></param>
    /// <returns></returns>
    public IEnumerator LevelChange(int oldLV, int newLV, Text monsterLVText, Text monsterXPText, GameObject experience)
    {
        if (!first) //初期値設定
        {
            currentLV = experience.transform.localScale.x; //加算前の経験値バーの位置（最大値：1）
            changeAmount = 1 - currentLV; //今の経験値とそのレベルからレベルアップするのに必要な経験値の割合

            first = true;
        }


        //もし、獲得経験値加算前のレベルと加算後のレベルを比べ、加算前のレベルが小さければ
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
