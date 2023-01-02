using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PLYAER
{
    namespace SYSTEM
    {
        /// <summary>
        /// �v���C���[�̃A�C�e���C���x���g��
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
            /// �A�C�e���C���x���g���ɃA�C�e��������Ƃ��ɂ��łɎ����Ă���A�C�e�����m�F���Č��𑝂₷
            /// </summary>
            /// <param name="ItemNunber"></param>
            /// <param name="itemQuantity"></param>
            /// <param name="save"></param>
            public void ItemInInventory(int ItemNunber, int itemQuantity, SaveAndRoad save)
            {
                InventoryDateBase dateBase = new InventoryDateBase();
                bool itemHave = false; //�A�C�e�������łɎ����Ă��邩�����Ă��Ȃ���

                //�A�C�e���������Ă��邩�̔���
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
                    dateBase.itemName = (InventoryDateBase.ItemName)ItemNunber; //int�^�́uItemNunber�v��ItemName�^�ŃL���X�g����
                    dateBase.itemQuantity = itemQuantity;

                    GManager.instance.itemInventory.Add(dateBase);
                }

                save.savePlayerDate();
            }
        }

    }
}
