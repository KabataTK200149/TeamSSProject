using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PLYAER.SYSTEM;

namespace ITEM
{
    namespace ACQUIR
    {
        /// <summary>
        /// クエストで獲得するアイテムの情報を返すスクリプト
        /// </summary>
        public class AcquiredItemSystem : MonoBehaviour
        {
            InventoryDateBase inventoryDate = new InventoryDateBase();

            /// <summary>
            /// 獲得したアイテムを確認して保存する
            /// </summary>
            /// <param name="questStructure"></param>
            /// <param name="save"></param>
            public void SaveItem(QuestStructure questStructure, SaveAndRoad save)
            {
                int crearRewardNumber = questStructure.Quest[GManager.instance.selectQuestNumber].questCrearRewardNumber;

                if (questStructure.QuestCrearRewardItems[crearRewardNumber, 0] != 0 )
                {
                    for (int i = 0; i < questStructure.QuestCrearRewardItems.GetLength(1); i++)
                    {
                        if(questStructure.QuestCrearRewardItems[crearRewardNumber, i] == 0)
                        {
                            break;
                        }

                        inventoryDate.ItemInInventory(questStructure.QuestCrearRewardItems[crearRewardNumber, i], 1, save);
                    }
                }

            }


            /// <summary>
            /// 獲得したアイテムを表示させる
            /// </summary>
            /// <param name="originObj"></param>
            /// <param name="parentObj"></param>
            /// <param name="questStructure"></param>
            /// <param name="itemDataBase"></param>
            public void displayItem(GameObject originObj, GameObject parentObj , QuestStructure questStructure, ItemDataBase itemDataBase)
            {
                int crearRewardNumber = questStructure.Quest[GManager.instance.selectQuestNumber].questCrearRewardNumber;

                int posX = (((int)originObj.GetComponent<RectTransform>().sizeDelta.x / 2) + ((((int)parentObj.GetComponent<RectTransform>().sizeDelta.x) - (((int)originObj.GetComponent<RectTransform>().sizeDelta.x) * 4)) / 5));
                int pushPointX = posX - (((int)parentObj.GetComponent<RectTransform>().sizeDelta.x) / 2);

                if(GManager.instance.sceneTag == GManager.GameSceneTag.RESLT)
                {
                    int pushPointY = 170;

                    for(int i = 1; i < questStructure.QuestCrearRewardItems.GetLength(1); i++)
                    {
                        if(questStructure.QuestCrearRewardItems[crearRewardNumber, (i - 1)] == 0)
                        {
                            break;
                        }

                        GameObject instansObj = Instantiate(originObj, parentObj.transform);
                        instansObj.transform.localPosition = new Vector3(pushPointX, pushPointY, 0);


                        instansObj.GetComponent<Image>().sprite = itemDataBase.GetItemDataList()[questStructure.QuestCrearRewardItems[crearRewardNumber, (i - 1)]].GetSprite();

                        if(i % 4 == 0)
                        {
                            pushPointX = posX - (((int)parentObj.GetComponent<RectTransform>().sizeDelta.x) / 2);
  
                            pushPointY -= 70;

                        }
                        else
                        {
                            pushPointX += posX + (((int)originObj.GetComponent<RectTransform>().sizeDelta.x) / 2);
                        }

        
                    }

                }


            }
        }
    }
}

