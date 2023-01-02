using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MonsterCreat.Selection;


namespace MonsterCreat
{
    namespace Move
    {
        /// <summary>
        /// 怪人の生成演出
        /// </summary>
        public class CreatDirection : MonoBehaviour
        {

            public string characterSprite;

            Vector3 originalMonsterScaleObj;
            Texture2D monsterSprite;

            ImageSelection imageSelection = new ImageSelection();

            /// <summary>
            /// 生成されるキャラクターの画像の変更（降ってくるとき）
            /// </summary>
            public void ExpansionEnterAnimation(GameObject createMonsterObject, Image image_object)
            {
                originalMonsterScaleObj = createMonsterObject.transform.localPosition;

                monsterSprite = Resources.Load($"{imageSelection.CharacterSelection()}") as Texture2D;

                createMonsterObject.transform.localPosition = new Vector3(originalMonsterScaleObj.x, 1810, originalMonsterScaleObj.z);
                image_object.sprite = Sprite.Create(monsterSprite, new Rect(0, 0, monsterSprite.width, monsterSprite.height), Vector2.zero);
                createMonsterObject.transform.DOLocalMoveY(originalMonsterScaleObj.y, 3f); //移動

            }

            /// <summary>
            /// 黒い玉の大きさを大きくする
            /// </summary>
            public void ExpansionCircleEnterAnimation(GameObject createCircleObject)
            {
                createCircleObject.transform.DOScale(new Vector3(7, 7, 0), 1f);
            }

            /// <summary>
            /// 黒い玉の大きさを小さくして無くす
            /// </summary>
            public void ExpansionCircleFainAnimation(GameObject createCircleObject)
            {
                createCircleObject.transform.DOScale(new Vector3(0, 0, 0), 0.8f);
            }

            /// <summary>
            /// キャラクターの画像を左に寄せて、スケールも大きくする
            /// </summary>
            public void ExpansionDetailAnimation(GameObject createCharacterBase)
            {
                createCharacterBase.transform.DOScale(new Vector3(0.006f, 0.006f, 0), 1f);
                createCharacterBase.transform.DOLocalMove(new Vector3(-2.4f, -0.6f, 0), 1f);
            }

        }
        

    }

    namespace Selection
    {
        /// <summary>
        /// モンスター生成時に制作されるモンスター画像の選択
        /// </summary>
        public class ImageSelection : MonoBehaviour
        {
           
            public string characterSprite;

            /// <summary>
            /// キャラクターの画像の条件
            /// </summary>
            public string CharacterSelection()
            {     

                if (GManager.instance.characterType == CharacterLibrary.CharacterType.炎)
                {
                    if (GManager.instance.monsterDate[2] >= 0 && GManager.instance.monsterDate[2] <= 10)
                    {
                        characterSprite = "vil-1-bef-red";
                    }
                    else if (GManager.instance.monsterDate[2] >= 11 && GManager.instance.monsterDate[2] <= 20)
                    {
                        characterSprite = "vil-2-bef-red";
                    }
                    else if (GManager.instance.monsterDate[2] >= 21 && GManager.instance.monsterDate[2] <= 50)
                    {
                        characterSprite = "vil-3-bef-red";
                    }
                    else if (GManager.instance.monsterDate[2] >= 51 && GManager.instance.monsterDate[2] <= 100)
                    {
                        characterSprite = "vil-1-bef-red";
                    }
                }
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.風)
                {
                    if (GManager.instance.monsterDate[2] >= 0 && GManager.instance.monsterDate[2] <= 10)
                    {
                        characterSprite = "vil-2-bef-grn";
                    }
                    else if (GManager.instance.monsterDate[2] >= 11 && GManager.instance.monsterDate[2] <= 20)
                    {
                        characterSprite = "vil-3-bef-grn";
                    }
                    else if (GManager.instance.monsterDate[2] >= 21 && GManager.instance.monsterDate[2] <= 50)
                    {
                        characterSprite = "vil-1-bef-grn";
                    }
                    else if (GManager.instance.monsterDate[2] >= 51 && GManager.instance.monsterDate[2] <= 100)
                    {
                        characterSprite = "vil-2-bef-grn";
                    }
                }
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.水)
                {
                    if (GManager.instance.monsterDate[2] >= 0 && GManager.instance.monsterDate[2] <= 10)
                    {
                        characterSprite = "vil-3-bef-blu";
                    }
                    else if (GManager.instance.monsterDate[2] >= 11 && GManager.instance.monsterDate[2] <= 20)
                    {
                        characterSprite = "vil-2-bef-blu";
                    }
                    else if (GManager.instance.monsterDate[2] >= 21 && GManager.instance.monsterDate[2] <= 50)
                    {
                        characterSprite = "vil-1-bef-blu";
                    }
                    else if (GManager.instance.monsterDate[2] >= 51 && GManager.instance.monsterDate[2] <= 100)
                    {
                        characterSprite = "vil-3-bef-blu";
                    }
                }
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.雷)
                {
                    if (GManager.instance.monsterDate[2] >= 0 && GManager.instance.monsterDate[2] <= 10)
                    {
                        characterSprite = "vil-1-bef-yel";
                    }
                    else if (GManager.instance.monsterDate[2] >= 11 && GManager.instance.monsterDate[2] <= 20)
                    {
                        characterSprite = "vil-1-bef-yel";
                    }
                    else if (GManager.instance.monsterDate[2] >= 21 && GManager.instance.monsterDate[2] <= 50)
                    {
                        characterSprite = "vil-2-bef-yel";
                    }
                    else if (GManager.instance.monsterDate[2] >= 51 && GManager.instance.monsterDate[2] <= 100)
                    {
                        characterSprite = "vil-3-bef-yel";
                    }
                }
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.毒)
                {
                    if (GManager.instance.monsterDate[2] >= 0 && GManager.instance.monsterDate[2] <= 10)
                    {
                        characterSprite = "vil-1-bef-ppl";
                    }
                    else if (GManager.instance.monsterDate[2] >= 11 && GManager.instance.monsterDate[2] <= 20)
                    {
                        characterSprite = "vil-3-bef-ppl";
                    }
                    else if (GManager.instance.monsterDate[2] >= 21 && GManager.instance.monsterDate[2] <= 50)
                    {
                        characterSprite = "vil-3-bef-ppl";
                    }
                    else if (GManager.instance.monsterDate[2] >= 51 && GManager.instance.monsterDate[2] <= 100)
                    {
                        characterSprite = "vil-2-bef-ppl";
                    }
                }

                return characterSprite;
            }
        }
    }

}
