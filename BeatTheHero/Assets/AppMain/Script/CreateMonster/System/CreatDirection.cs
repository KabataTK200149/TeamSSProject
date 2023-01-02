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
        /// ���l�̐������o
        /// </summary>
        public class CreatDirection : MonoBehaviour
        {

            public string characterSprite;

            Vector3 originalMonsterScaleObj;
            Texture2D monsterSprite;

            ImageSelection imageSelection = new ImageSelection();

            /// <summary>
            /// ���������L�����N�^�[�̉摜�̕ύX�i�~���Ă���Ƃ��j
            /// </summary>
            public void ExpansionEnterAnimation(GameObject createMonsterObject, Image image_object)
            {
                originalMonsterScaleObj = createMonsterObject.transform.localPosition;

                monsterSprite = Resources.Load($"{imageSelection.CharacterSelection()}") as Texture2D;

                createMonsterObject.transform.localPosition = new Vector3(originalMonsterScaleObj.x, 1810, originalMonsterScaleObj.z);
                image_object.sprite = Sprite.Create(monsterSprite, new Rect(0, 0, monsterSprite.width, monsterSprite.height), Vector2.zero);
                createMonsterObject.transform.DOLocalMoveY(originalMonsterScaleObj.y, 3f); //�ړ�

            }

            /// <summary>
            /// �����ʂ̑傫����傫������
            /// </summary>
            public void ExpansionCircleEnterAnimation(GameObject createCircleObject)
            {
                createCircleObject.transform.DOScale(new Vector3(7, 7, 0), 1f);
            }

            /// <summary>
            /// �����ʂ̑傫�������������Ė�����
            /// </summary>
            public void ExpansionCircleFainAnimation(GameObject createCircleObject)
            {
                createCircleObject.transform.DOScale(new Vector3(0, 0, 0), 0.8f);
            }

            /// <summary>
            /// �L�����N�^�[�̉摜�����Ɋ񂹂āA�X�P�[�����傫������
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
        /// �����X�^�[�������ɐ��삳��郂���X�^�[�摜�̑I��
        /// </summary>
        public class ImageSelection : MonoBehaviour
        {
           
            public string characterSprite;

            /// <summary>
            /// �L�����N�^�[�̉摜�̏���
            /// </summary>
            public string CharacterSelection()
            {     

                if (GManager.instance.characterType == CharacterLibrary.CharacterType.��)
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
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.��)
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
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.��)
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
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.��)
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
                else if (GManager.instance.characterType == CharacterLibrary.CharacterType.��)
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
