using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using PLYAER.SYSTEM;

public class SaveAndRoad : MonoBehaviour
{
    [SerializeField] CharacterLibrary characterLibrary;

    InventoryDateBase playerDate = new InventoryDateBase();

    string[] monsterSaveDate;
    string playerSaveDate;
    string strget;

    public void Awake()
    {
        monsterSaveDate = new string[100];
    }

    /// <summary>
    /// モンスタのセーブ用処理
    /// </summary>
    /// <param name="monsterNumber"></param>
    /// <param name="name"></param>
    /// <param name="evolutionLv"></param>
    /// <param name="type"></param>
    /// <param name="LV"></param>
    /// <param name="HP"></param>
    /// <param name="STR"></param>
    /// <param name="VIT"></param>
    /// <param name="AGI"></param>
    /// <param name="INT"></param>
    /// <param name="skilPoint"></param>
    /// <param name="XP"></param>
    /// <param name="firstMove"></param>
    /// <param name="secondMove"></param>
    /// <param name="thirdMove"></param>
    /// <param name="forceMove"></param>
    /// <param name="fifthMove"></param>
    /// <param name="firstSkill"></param>
    /// <param name="secondSkill"></param>
    /// <param name="frontSpriteDateName"></param>
    /// <param name="backSpriteDateName"></param>
    public void saveMonsterDate(int monsterNumber, string name, int evolutionLv, CharacterLibrary.CharacterType type, int LV, int HP, int STR, int VIT, int AGI, int INT, int skilPoint, int XP, int firstMove, int secondMove, int thirdMove, int forceMove, int fifthMove, int firstSkill, int secondSkill, string frontSpriteDateName, string backSpriteDateName)
    {
        strget = null;
        
        strget = strget + name.ToString() + ",";
        strget = strget + LV.ToString() + ",";
        strget = strget + evolutionLv.ToString() + ",";
        strget = strget + type.ToString() + ",";
        strget = strget + HP.ToString() + ",";
        strget = strget + STR.ToString() + ",";
        strget = strget + VIT.ToString() + ",";
        strget = strget + AGI.ToString() + ",";
        strget = strget + INT.ToString() + ",";
        strget = strget + skilPoint.ToString() + ",";
        strget = strget + XP.ToString() + ",";
        strget = strget + firstMove.ToString() + ",";
        strget = strget + secondMove.ToString() + ",";
        strget = strget + thirdMove.ToString() + ",";
        strget = strget + forceMove.ToString() + ",";
        strget = strget + fifthMove.ToString() + ",";
        strget = strget + firstSkill.ToString() + ",";
        strget = strget + secondSkill.ToString() + ",";
        strget = strget + frontSpriteDateName + ",";
        strget = strget + backSpriteDateName + ",";
       
        PlayerPrefs.SetString("monsterSaveDate" + monsterNumber , strget);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// プレイヤのセーブ用処理
    /// </summary>
    public void savePlayerDate()
    {
        strget = null;

        strget = strget + GManager.instance.monsterNumber.ToString();

        for (int i = 0; i < GManager.instance.itemInventory.Count; i++)
        {
            strget = strget + "," + GManager.instance.itemInventory[i].itemName.ToString();
            strget = strget + "," + GManager.instance.itemInventory[i].itemQuantity.ToString();

        }

        PlayerPrefs.SetString("PlaySaveDate", strget);
        PlayerPrefs.Save();

    }

    /// <summary>
    /// モンスタデータロード用処理
    /// </summary>
    public void roadMonsterDate()
    {

       // GManager.instance.monsterNumber = PlayerPrefs.GetInt("PlaySaveDate", 0);

        for (int i = 0; i < GManager.instance.monsterNumber; i++)
        {
            monsterSaveDate[i] = PlayerPrefs.GetString("monsterSaveDate" + (i + 1), null);
            string[] setArray = monsterSaveDate[i].Split(',');

            characterLibrary.Monster[i + 1].name = setArray[0];
            characterLibrary.Monster[i + 1].LV = int.Parse(setArray[1]);
            characterLibrary.Monster[i + 1].evolutionLV = int.Parse(setArray[2]);
            characterLibrary.Monster[i + 1].type = (CharacterLibrary.CharacterType)Enum.Parse(typeof(CharacterLibrary.CharacterType), setArray[3]);
            characterLibrary.Monster[i + 1].HP = int.Parse(setArray[4]);
            characterLibrary.Monster[i + 1].STR = int.Parse(setArray[5]);
            characterLibrary.Monster[i + 1].VIT = int.Parse(setArray[6]);
            characterLibrary.Monster[i + 1].AGI = int.Parse(setArray[7]);
            characterLibrary.Monster[i + 1].INT = int.Parse(setArray[8]);
            characterLibrary.Monster[i + 1].skilPoint = int.Parse(setArray[9]);
            characterLibrary.Monster[i + 1].XP = int.Parse(setArray[10]);
            characterLibrary.Monster[i + 1].firstMove= int.Parse(setArray[11]);
            characterLibrary.Monster[i + 1].secondMove = int.Parse(setArray[12]);
            characterLibrary.Monster[i + 1].thirdMove = int.Parse(setArray[13]);
            characterLibrary.Monster[i + 1].forceMove = int.Parse(setArray[14]);
            characterLibrary.Monster[i + 1].fifthMove = int.Parse(setArray[15]);
            characterLibrary.Monster[i + 1].firstSkill = int.Parse(setArray[16]);
            characterLibrary.Monster[i + 1].secondSkill = int.Parse(setArray[17]);
            characterLibrary.Monster[i + 1].frontSpriteDateName = setArray[18];
            characterLibrary.Monster[i + 1].backSpriteDateName = setArray[19];
            

        }
    }

    /// <summary>
    /// プレイヤデータロード用処理
    /// </summary>
    public void roadPlayerDate()
    {
        playerSaveDate = PlayerPrefs.GetString("PlaySaveDate", null);
        string[] setArray = playerSaveDate.Split(',');

        GManager.instance.monsterNumber = int.Parse(setArray[0]);

        for(int i = 1; i < setArray.Length; i++)
        {
            InventoryDateBase menber = new InventoryDateBase();

            menber.itemName = (InventoryDateBase.ItemName)Enum.Parse(typeof(InventoryDateBase.ItemName), setArray[i]);
            menber.itemQuantity = int.Parse(setArray[i + 1]);
            GManager.instance.itemInventory.Add(menber);

            i++;
        }

    }

   
}
