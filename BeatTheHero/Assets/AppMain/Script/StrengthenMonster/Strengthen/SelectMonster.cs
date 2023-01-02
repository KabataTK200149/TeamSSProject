using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 進化のボックスに表示されるモンスターを表示させる
/// </summary>
public class SelectMonster : MonoBehaviour
{
    [SerializeField] GameObject monsterBoxObj;
    [SerializeField] GameObject parentObj;
    [SerializeField] SelectMonsterrHub monsterrHub;
    [SerializeField] CharacterLibrary characterLibrary;
    [SerializeField] SaveAndRoad road;

    private List<GameObject> createItemImageObj = new List<GameObject>();

    public void Start()
    {
        //モンスター番号を初期化
        GManager.instance.selectMonsterNumber = 0;
        GManager.instance.evolutionNumber = 0;
  
        //モンスターボックスの配置
        int posX = ((340 / 2) + ((1920 - (340 * 4)) / 5));
        int pushPointY = 600;
        int pushPointX = (posX - 960) ;
        createItemImageObj.Clear();

        //road.roadPlayerDate();
        road.roadMonsterDate();

        for(int i = 0; i < GManager.instance.monsterNumber; i++)
        {
            int monsterNo = i + 1; //モンスターのライブラリの0番がNULLなので+1してあげる

            GameObject instansObj = Instantiate(monsterBoxObj, parentObj.transform); //モンスターボックスの生成
            instansObj.transform.localPosition = new Vector3(pushPointX, pushPointY, 0); //生成したボックスの位置を調整

            instansObj.GetComponent<SelectMonsterButton>().monsterNumber = (monsterNo); //生成したボックスに個別番号を付与

            //テキスト変更
            characterLibrary.Monster[monsterNo].frontSprite = Resources.Load(characterLibrary.Monster[monsterNo].frontSpriteDateName) as Texture2D;
            instansObj.GetComponent<Image>().sprite = Sprite.Create(characterLibrary.Monster[monsterNo].frontSprite, new Rect(0, 0, characterLibrary.Monster[monsterNo].frontSprite.width, characterLibrary.Monster[monsterNo].frontSprite.height), Vector2.zero);

            //進化出来るか確認して出来ないなら色を変える
            if(characterLibrary.Monster[monsterNo].evolutionLV != 1 && GManager.instance.sceneTag == GManager.GameSceneTag.EVOLUTION)
            {
                instansObj.GetComponent<Image>().color = new Color32(122, 122, 122, 255); //進化不可能なモンスターの色（灰色)
            }

            createItemImageObj.Add(instansObj);
     
            //モンスターボックスの位置を調整
            if ((monsterNo) % 4 == 0)
            {
                pushPointY -= 400;
                pushPointX = (posX - 960);
            }
            else
            {
                pushPointX += posX + (posX - ((1920 - (340 * 4)) / 5));
            }

        }
        
        
    }

}
