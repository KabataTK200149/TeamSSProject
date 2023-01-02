using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 中央に帯を表示・非表示させる
/// 効果をつける
/// </summary>
public class EnemyTransform : MonoBehaviour
{
    [SerializeField] CharacterLibrary character;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] Color victoryColor;
    [SerializeField] Color defeatColor;
    [SerializeField] Color battleColor;
    [SerializeField] GameObject transformHero;
    [SerializeField] GameObject heroImageObj;
    [SerializeField] GameObject battleStertText;
    [SerializeField] Text dialogTex;
    [SerializeField] Text situationText;
    public Image heroImage;

   public float centralPosy;

    Vector3 originalScaleObi, originalScaleImage, originalPosBattle;
    Vector2 NowScale;
    Texture2D transformHeroSprite;

    public void Awake()
    {
        originalScaleObi = transformHero.transform.localScale; //TransformDirectingの元々のスケールを取得
        originalScaleImage = heroImageObj.transform.localScale;
        originalPosBattle = battleStertText.transform.localPosition;

        GameObject image_objectMonster = GameObject.Find("HeroTransform");
        heroImage = heroImage.GetComponent<Image>();

    }

    /// <summary>
    /// 変身帯表示・非表示設定
    /// </summary>
    /// <param name="enabled"></param>
    public void EnableTransformHero(bool enabled)
    {
        transformHero.SetActive(enabled);
    }

    /// <summary>
    /// 変身帯表示アニメーション
    /// </summary>
    /// <returns></returns>
    public IEnumerator ExpansionEnterAnimation()
    {
        transformHero.transform.localScale = new Vector2(originalScaleObi.x, 0); //帯の大きさScaleを最小にする
        dialogTex.text = ("");

        //帯の大きさScaleを徐々に大きくしていく
        while (transformHero.transform.localScale.y <= originalScaleObi.y)
        {
            NowScale = transformHero.transform.localScale;
            transformHero.transform.localScale = new Vector2(originalScaleObi.x, NowScale.y + 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
        
    }

    public void ChangingHero()
    {
       
        transformHeroSprite = Resources.Load(character.Hero[enemyUnit.battleHeroNunber].transformationDateName) as Texture2D;

        heroImage.sprite = Sprite.Create(transformHeroSprite, new Rect(0, 0, transformHeroSprite.width, transformHeroSprite.height), Vector2.zero);

    }

    public void MoveChangingHero()
    {
        heroImageObj.transform.DOScale(new Vector3(1.4f, 1.4f, 0), 3f);
    }

    /// <summary>
    /// 変身帯収縮アニメーション
    /// </summary>
    /// <returns></returns>
    public IEnumerator ExpansionFaintAnimation()
    {
        //帯の大きさScaleを徐々に小さくしていく
        while(transformHero.transform.localScale.y >= 0.1f)
        {
            NowScale = transformHero.transform.localScale;
            transformHero.transform.localScale = new Vector2(originalScaleObi.x, NowScale.y - 0.1f);
            yield return new WaitForSeconds(0.05f);
        }
    }

    /// <summary>
    /// BattlestertTextを画面右から左へ移動させる
    /// </summary>
    /// <returns></returns>
    public IEnumerator BattleStertAnimation()
    {
        situationText.text = ($"BATTLE START");
        situationText.color = battleColor;
        situationText.fontSize = 180;
        battleStertText.transform.localPosition = new Vector3(1658, originalPosBattle.y); //画面右端にTextを移動
        battleStertText.SetActive(true); //Text表示

        battleStertText.transform.DOLocalMoveX(originalPosBattle.x, 1f);
        yield return new WaitForSeconds(1f);

        yield return new WaitForSeconds(0.8f); //画面中央でTextを待機させる秒

        battleStertText.transform.DOLocalMoveX(-1658f, 1f);
        yield return new WaitForSeconds(1f);

        battleStertText.SetActive(false); //Text非表示
    }

    public IEnumerator VictoryAnimation()
    {
        situationText.text = ($"勝利!");
        situationText.color = victoryColor;
        situationText.fontSize = 0;
        battleStertText.transform.localPosition = new Vector3( 0, originalPosBattle.y ); //画面右端にTextを移動
        battleStertText.SetActive(true); //Text表示

        while(situationText.fontSize <= 170)
        {
            situationText.fontSize += 10;
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

    }

    public IEnumerator DefeatAnimation()
    {
        situationText.text = ($"敗北");
        situationText.color = defeatColor;
        situationText.fontSize = 0;
        battleStertText.transform.localPosition = new Vector3(0, originalPosBattle.y ); //画面右端にTextを移動
        battleStertText.SetActive(true); //Text表示

        while (situationText.fontSize <= 180)
        {
            situationText.fontSize += 10;
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

    }
}
