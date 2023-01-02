using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLYAER
{
    namespace SYSTEM
    {
        /// <summary>
        /// プレイヤーのアイテムインベントリ
        /// </summary>
        public class InventoryDateBase : MonoBehaviour
        {
            public enum ItemName
            {
                NULL,
                TIKARANOSYO,
                MAMORINOSYO,
                HAYASANOSYO,
                SAINOUNOSYO,

            }

            public ItemName itemName { get; set; }
            public int itemQuantity { get; set; }

            /// <summary>
            /// アイテムインベントリにアイテムを入れるときにすでに持っているアイテムを確認して個数を増やす
            /// </summary>
            /// <param name="ItemNunber"></param>
            /// <param name="itemQuantity"></param>
            /// <param name="save"></param>
            public void ItemInInventory(int ItemNunber, int itemQuantity, SaveAndRoad save)
            {
                InventoryDateBase dateBase = new InventoryDateBase();
                bool itemHave = false; //アイテムをすでに持っているか持っていないか

                //アイテムを持っているかの判別
                for (int i = 0; i < GManager.instance.itemInventory.Count; i++)
                {
                    if (GManager.instance.itemInventory[i].itemName == (InventoryDateBase.ItemName)ItemNunber)
                    {
                        GManager.instance.itemInventory[i].itemQuantity += itemQuantity;
                        itemHave = true;
                        break;
                    }
                }

                if (!itemHave)
                {
                    dateBase.itemName = (InventoryDateBase.ItemName)ItemNunber; //int型の「ItemNunber」をItemName型でキャストする
                    dateBase.itemQuantity = itemQuantity;

                    GManager.instance.itemInventory.Add(dateBase);
                }

                save.savePlayerDate();
            }
        }

    }
}
