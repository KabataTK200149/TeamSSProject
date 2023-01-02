using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PLYAER.SYSTEM;

namespace STRENGTHEN
{
    namespace SYSTEM
    {
        /// <summary>
        /// 進化シーンで使用するシステム
        /// </summary>
        public class EvolutionMonsterSet : MonoBehaviour
        {
            InventoryDateBase playerDate = new InventoryDateBase();

            /// <summary>
            /// 進化シーンの時に指定したモンスターの進化先を表示する
            /// </summary>
            /// <param name="createItemImageObj"></param>
            /// <param name="road"></param>
            /// <param name="monsterBoxObj"></param>
            /// <param name="parentObj"></param>
            /// <param name="characterLibrary"></param>
           public void SetSystem(List<GameObject> createItemImageObj, SaveAndRoad road, GameObject monsterBoxObj, GameObject parentObj, CharacterLibrary characterLibrary)
           {
      
                int posX = ((170 / 2) + ((768 - (170 * 4)) / 5));
                int pushPointX = (posX - 384);
                int pushPointY = 75;

                createItemImageObj.Clear();
                road.roadMonsterDate();

                for (int i = 0; i < 4; i++)
                {

                    GameObject instansObj = Instantiate(monsterBoxObj, parentObj.transform); //インスタンスでモンスター画像を表示するオブジェクトを生成
                    instansObj.transform.localPosition = new Vector3(pushPointX, pushPointY, 0); //インスタンスの位置調整

                    instansObj.GetComponent<EvolutionMonsterSelecter>().monsterOrdar = (i + 1); //進化選択のスクリプトの番号を選択

                    //画像変更
                    instansObj.GetComponent<Image>().sprite = Sprite.Create((Resources.Load(ImageSelection(characterLibrary, i)) as Texture2D), new Rect(0, 0, (Resources.Load(ImageSelection(characterLibrary, i)) as Texture2D).width, (Resources.Load(ImageSelection(characterLibrary, i)) as Texture2D).height), Vector2.zero);

                    instansObj.GetComponent<Image>().color = new Color32(0, 0, 0, 255);

                    createItemImageObj.Add(instansObj);

                    pushPointX += posX + (posX - ((768 - (170 * 4)) / 5));

                }
           }

            /// <summary>
            /// 進化条件のLVの文字を返す
            /// </summary>
            /// <param name="characterLibrary"></param>
            /// <returns></returns>
            public string LVStringSetting(CharacterLibrary characterLibrary)
            {

                if (GManager.instance.evolutionNumber == 1 || GManager.instance.evolutionNumber == 2 || GManager.instance.evolutionNumber == 3)
                {
                    return ("25");
                }
                else if (GManager.instance.evolutionNumber == 4)
                {
                    return ("30");
                }
                return null;
            }

            /// <summary>
            /// 進化条件のLVが足りているかを確認して足りていたらtrueを足りていなければfalseを返す
            /// </summary>
            /// <param name="characterLibrary"></param>
            /// <returns></returns>
            public bool LVCheck(CharacterLibrary characterLibrary)
            {
                if(GManager.instance.evolutionNumber == 1 || GManager.instance.evolutionNumber == 2 || GManager.instance.evolutionNumber == 3)
                {
                    if(characterLibrary.Monster[GManager.instance.selectMonsterNumber].LV >= 25)
                    {
                        return true;
                    }
                }
                else if (GManager.instance.evolutionNumber == 4)
                {
                    if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].LV >= 30)
                    {
                        return true;
                    }
                }
                return false;
            }

            /// <summary>
            /// 進化条件のステータスの文字を返す
            /// </summary>
            /// <param name="characterLibrary"></param>
            /// <returns></returns>
            public string AbilityStringSetting(CharacterLibrary characterLibrary)
            {

                if (GManager.instance.evolutionNumber == 1)
                {
                    return ("STR値200以上");
                }
                else if (GManager.instance.evolutionNumber == 2)
                {
                    return ("VIT値200以上");
                }
                else if (GManager.instance.evolutionNumber == 3)
                {
                    return ("AGI値100以上");
                }
                else if (GManager.instance.evolutionNumber == 4)
                {
                    return ("IGN値201以上");
                }
                return null;
            }

            /// <summary>
            /// 進化条件の能力値が足りているかを確認して足りていたらtrueを足りていなければfalseを返す
            /// </summary>
            /// <param name="characterLibrary"></param>
            /// <returns></returns>
            public bool AbilityCheck(CharacterLibrary characterLibrary)
            {
                if (GManager.instance.evolutionNumber == 1 )
                {
                    if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].STR >= 200)
                    {
                        return true;
                    }
                }
                else if (GManager.instance.evolutionNumber == 2)
                {
                    if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].VIT >= 200)
                    {
                        return true;
                    }
                }
                else if (GManager.instance.evolutionNumber == 3)
                {
                    if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].AGI >= 100)
                    {
                        return true;
                    }
                }
                else if (GManager.instance.evolutionNumber == 4)
                {
                    if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].INT > 200)
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// 進化に必要なアイテムを返す
            /// </summary>
            /// <returns></returns>
            public string ItemStringSetting(ItemDataBase itemData)
            {
                if(GManager.instance.evolutionNumber > 0)
                {
                    return itemData.GetItemDataList()[GManager.instance.evolutionNumber].GetItemName();
                }

                return null;
            }

            /// <summary>
            /// 進化に必要なアイテムを持っているならTrue持っていなければFalseを返す
            /// </summary>
            /// <returns></returns>
            public bool ItemCheck()
            {
                if(GManager.instance.evolutionNumber == 1)
                {
                    for(int i = 0; i < GManager.instance.itemInventory.Count; i++)
                    {
                        if (GManager.instance.itemInventory[i].itemName == InventoryDateBase.ItemName.TIKARANOSYO && GManager.instance.itemInventory[i].itemQuantity >= 1)
                        {
                            return true;
                        }
                    }
      
                }
                else if (GManager.instance.evolutionNumber == 2)
                {
                    for (int i = 0; i < GManager.instance.itemInventory.Count; i++)
                    {
                        if (GManager.instance.itemInventory[i].itemName == InventoryDateBase.ItemName.MAMORINOSYO && GManager.instance.itemInventory[i].itemQuantity >= 1)
                        {
                            return true;
                        }
                    }
                }
                else if (GManager.instance.evolutionNumber == 3)
                {
                    for (int i = 0; i < GManager.instance.itemInventory.Count; i++)
                    {
                        if (GManager.instance.itemInventory[i].itemName == InventoryDateBase.ItemName.HAYASANOSYO && GManager.instance.itemInventory[i].itemQuantity >= 1)
                        {
                            return true;
                        }
                    }
                }
                else if (GManager.instance.evolutionNumber == 4)
                {
                    for (int i = 0; i < GManager.instance.itemInventory.Count; i++)
                    {
                        if (GManager.instance.itemInventory[i].itemName == InventoryDateBase.ItemName.SAINOUNOSYO && GManager.instance.itemInventory[i].itemQuantity >= 1)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            /// <summary>
            /// 進化先のモンスター画像を選択されたモンスターを確認して変更する
            /// </summary>
            /// <param name="characterLibrary"></param>
            public string ImageSelection(CharacterLibrary characterLibrary, int attempts)
            {
                if(characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-1-bef-red")
                {
                    if(attempts == 0)
                    {
                        return "vil-1-af-pow-red";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-1-af-def-red";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-1-af-spd-red";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-1-af-int-red";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-1-bef-blu")
                {
                    if (attempts == 0)
                    {
                        return "vil-1-af-pow-blu";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-1-af-def-blu";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-1-af-spd-blu";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-1-af-int-blu";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-1-bef-gm")
                {
                    if (attempts == 0)
                    {
                        return "vil-1-af-pow-gm";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-1-af-def-gm";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-1-af-spd-gm";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-1-af-int-gm";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-1-bef-ppl")
                {
                    if (attempts == 0)
                    {
                        return "vil-1-af-pow-ppl";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-1-af-def-ppl";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-1-af-spd-ppl";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-1-af-int-ppl";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-1-bef-yel")
                {
                    if (attempts == 0)
                    {
                        return "vil-1-af-pow-yel";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-1-af-def-yel";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-1-af-spd-yel";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-1-af-int-yel";
                    }
                }

                if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-2-bef-red")
                {
                    if (attempts == 0)
                    {
                        return "vil-2-af-pow-red";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-2-af-def-red";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-2-af-spd-red";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-2-af-int-red";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-2-bef-blu")
                {
                    if (attempts == 0)
                    {
                        return "vil-2-af-pow-blu";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-2-af-def-blu";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-2-af-spd-blu";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-2-af-int-blu";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-2-bef-gm")
                {
                    if (attempts == 0)
                    {
                        return "vil-2-af-pow-gm";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-2-af-def-gm";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-2-af-spd-gm";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-2-af-int-gm";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-2-bef-ppl")
                {
                    if (attempts == 0)
                    {
                        return "vil-2-af-pow-ppl";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-2-af-def-ppl";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-2-af-spd-ppl";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-2-af-int-ppl";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-2-bef-yel")
                {
                    if (attempts == 0)
                    {
                        return "vil-2-af-pow-yel";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-2-af-def-yel";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-2-af-spd-yel";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-2-af-int-yel";
                    }
                }

                if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-3-bef-red")
                {
                    if (attempts == 0)
                    {
                        return "vil-3-af-pow-red";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-3-af-def-red";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-3-af-spd-red";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-3-af-int-red";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-3-bef-blu")
                {
                    if (attempts == 0)
                    {
                        return "vil-3-af-pow-blu";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-3-af-def-blu";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-3-af-spd-blu";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-3-af-int-blu";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-3-bef-gm")
                {
                    if (attempts == 0)
                    {
                        return "vil-3-af-pow-gm";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-3-af-def-gm";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-3-af-spd-gm";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-3-af-int-gm";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-3-bef-ppl")
                {
                    if (attempts == 0)
                    {
                        return "vil-3-af-pow-ppl";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-3-af-def-ppl";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-3-af-spd-ppl";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-3-af-int-ppl";
                    }
                }
                else if (characterLibrary.Monster[GManager.instance.selectMonsterNumber].frontSpriteDateName == "vil-3-bef-yel")
                {
                    if (attempts == 0)
                    {
                        return "vil-3-af-pow-yel";
                    }
                    else if (attempts == 1)
                    {
                        return "vil-3-af-def-yel";
                    }
                    else if (attempts == 2)
                    {
                        return "vil-3-af-spd-yel";
                    }
                    else if (attempts == 3)
                    {
                        return "vil-3-af-int-yel";
                    }
                }
                return null;
            }
        }
    }
}

