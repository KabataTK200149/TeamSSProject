using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLYAER.SYSTEM;

public class HomeSystem : MonoBehaviour
{
    [SerializeField] SaveAndRoad road;
    [SerializeField] CharacterLibrary characterLibrary;

    InventoryDateBase playerDate = new InventoryDateBase();


    // Start is called before the first frame update
    void Start()
    {
      // PlayerPrefs.DeleteAll();
  

        if (GManager.instance.homePlay)
        {
            //GManager.instance.monsterNumber = PlayerPrefs.GetInt("PlaySaveDate", 1);


            //road.savePlayerDate(GManager.instance.itemInventory);
            //road.roadPlayerDate();
            /*
            for (int i = 0; i < 4; i++)
            {
                playerDate.ItemInInventory(i, 1, road);
            }
            */
           // road.savePlayerDate();
            
            
            for (int i = 1; i < 2; i++)
            {
 
                road.saveMonsterDate(i, characterLibrary.Monster[i].name, characterLibrary.Monster[i].evolutionLV, characterLibrary.Monster[i].type, characterLibrary.Monster[i].LV, characterLibrary.Monster[i].HP, characterLibrary.Monster[i].STR, characterLibrary.Monster[i].VIT, characterLibrary.Monster[i].AGI, characterLibrary.Monster[i].INT, characterLibrary.Monster[i].skilPoint, characterLibrary.Monster[i].XP, characterLibrary.Monster[i].firstMove, characterLibrary.Monster[i].secondMove, characterLibrary.Monster[i].thirdMove, characterLibrary.Monster[i].forceMove, characterLibrary.Monster[i].fifthMove, characterLibrary.Monster[i].firstSkill, characterLibrary.Monster[i].secondSkill, characterLibrary.Monster[i].frontSpriteDateName, characterLibrary.Monster[i].backSpriteDateName);
                

            }
            GManager.instance.homePlay = false;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
