using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// BattleSystemの変数
/// </summary>
public enum BattleStatus
{
    Start,
    TransformHero,
    FirstAction, //Player行動選択
    PlayerMove,　//Player技選択
    EnemyMove, //Enemy行動選択
    Busy,  //その他
}

/// <summary>
/// バトルの指示出し
/// </summary>
public class BattleSystem : MonoBehaviour
{

    public AudioClip crithikaruSound, hitSound, hennsinSound, hensinBoise, monsterBoise;
    AudioSource audioSource;
    [SerializeField] float transitionStopTime;
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] EnemyTransform enemyTransform;
    [SerializeField] Roulet playerRoulet;
    [SerializeField] Roulet enemyRoulet;
    [SerializeField] GameObject playerRouletObj;
    [SerializeField] GameObject enemyRouletObj;

    BattleStatus state;
    int currentAction, conditionSwith, monsterTurn, heroTurn, originalStatus;
    bool paralysisMonsterCondition, paralysisHeroCondition;
    Color32 systemColor = new Color32(0, 0, 0, 255);
    Color32 monsterColor = new Color32(255, 69, 0, 255);
    Color32 heroColor = new Color32(65, 105, 255, 255);

    [Header("0なら変身アニメーションあり、1なら戦闘から開始")] public int debugFunction; //デバッグ用関数

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        //初期化
        StartCoroutine(SetupBattle());
        currentAction = 0; 
        conditionSwith = 0;
        paralysisMonsterCondition = false;
        paralysisHeroCondition = false;
        monsterTurn = 0;
        heroTurn = 0;
        originalStatus = 0;

        
    }

    void TransformHero()
    {
        state = BattleStatus.TransformHero;

    }


    /// <summary>
    /// 速さを比べて攻撃順番を決定し、攻撃、状態異常の処理
    /// </summary>
    IEnumerator FirstAction()
    {
        state = BattleStatus.FirstAction;
        
        //攻撃を開始する前に速さを比べて早い方が先行・遅い方が後攻に攻撃をする判断をくだす
        if (currentAction == 0)
        {
            conditionSwith = 0;


            if (playerUnit.character.Speed > enemyUnit.character.Speed) //プレイヤーユニットが早ければ
            {
                currentAction++;
            }
            else if (playerUnit.character.Speed < enemyUnit.character.Speed) //敵ユニットが早ければ
            {
                currentAction += 3;
            }
            else //速さが同じならランダムでどちらかを選ぶ
            {
                int moveOrderSelection = Random.Range(0, 2);

                if (moveOrderSelection == 0)
                {
                    currentAction++;
                }
                else
                {
                    currentAction += 3;
                }
            }
        }

        //攻撃命令を出すスイッチ　1；プレイヤーユニット初撃　2；プレイヤーユニット二撃　3；敵ユニット初撃　4；敵ユニット二撃　5；プレイヤーユニット状態異常処理　6：敵プレイヤー状態異常処理
        switch (currentAction)
        {
 
            case 1:

                yield return StartCoroutine(PerformPlayerMove());
                
                break;

            case 2:

                yield return StartCoroutine(EnemyMove());

                break;

            case 3:

                yield return StartCoroutine(EnemyMove());
                
                break;

            case 4:

                yield return StartCoroutine(PerformPlayerMove());

                break;

            case 5:

                yield return StartCoroutine(DamageStatEfficacyMonster());

                break;


            case 6:

                yield return StartCoroutine(DamageStatEfficacyHero());

                break;

        }
        
    }

    /// <summary>
    /// プレイヤーユニットの攻撃と状態異常付与処理
    /// </summary>
    /// <returns></returns>
    IEnumerator PerformPlayerMove()
    {
        state = BattleStatus.Busy;

        if (playerUnit.character.condition != CharacterLibrary.CharacterCondition.麻痺) //麻痺のとき
        {
            yield return dialogBox.TypDialog(($" {playerUnit.character.name} の攻撃"), systemColor);

            //技を決定
            playerRouletObj.SetActive(true); //ルーレットを表示
            playerRoulet.startRoulett(); //ルーレットに使用する関数の初期化
            playerRoulet.SelectMove(true); //ルーレットの中身の決定：引数playerMoveならtrue,enemyMoveならfalse
            yield return playerRoulet.RoulettControll(); //技を決めるルーレットの開始

            MoveLibrary.MoveBase move = playerUnit.character.Moves[playerRoulet.selectMoveList[playerRoulet.lostTime]]; //技情報取得
            yield return new WaitForSeconds(2f);
            playerRouletObj.SetActive(false); //ルーレットを非表示
            yield return dialogBox.TypDialog(($" {playerUnit.character.name} は{move.name}をつかった"), systemColor);

            if(Random.Range(0, 100) <= move.accuracy)
            {
                Character.DamageDetails damageDetails = enemyUnit.character.TakeDamage(move, playerUnit.character);  //enemyダメージ計算

                //戦闘モーション
                playerUnit.PlayerAttackAnimation();
                yield return new WaitForSeconds(0.7f);

                if(damageDetails.Critical > 1f)
                {
                    audioSource.PlayOneShot(crithikaruSound);
                }
                else
                {
                    audioSource.PlayOneShot(hitSound);
                }
                enemyUnit.PlayerHitAnimation();

          
                yield return dialogBox.TypDialog(($"{enemyUnit.character.name}は{enemyUnit.character.Damage}のダメージを受けた"), systemColor);
                yield return enemyHud.UpdateHP(); //HP反映

                //状態異常付与処理
                if (move.efficacy != enemyUnit.character.condition)
                {
                    yield return ProcessingStatChange(move, enemyUnit);
                }

                //相性/クリティカルダメージ
                yield return ShowDamageDetails(damageDetails);

                //戦闘不能処理
                if (damageDetails.Fainted)
                {
                    GManager.instance.buttolDefeat = false; //プレイヤー勝利時、false
                    enemyUnit.PlayerFaintAnimation(); //敗北時モーション


                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}は戦闘不能"), systemColor);
                    yield return enemyTransform.VictoryAnimation();

                    GManager.instance.sceneTag = GManager.GameSceneTag.RESLT; //現状のゲームシーンがどこなのかの判別タグ
                    SceneManager.LoadScene("ResltScene");
                }
                else if (currentAction == 1) //先行の攻撃 currentActionの数値に+1して後攻の攻撃に移る
                {
                    currentAction++;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 4) //後攻の攻撃 currentActionの数値を0してもう一度速さを比べる
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else  //変な数値が出てきたらエラーなので強制終了
                {
                    playerUnit.PlayerFaintAnimation(); //敗北時モーション
                    yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);
                }
            }
            else
            {
                yield return dialogBox.TypDialog(($" しかし、相手の{enemyUnit.character.name} には当たらなかった"), systemColor);

                if (currentAction == 1) //先行の攻撃 currentActionの数値に+1して後攻の攻撃に移る
                {
                    currentAction++;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 4) //後攻の攻撃 currentActionの数値を0してもう一度速さを比べる
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else  //変な数値が出てきたらエラーなので強制終了
                {
                    playerUnit.PlayerFaintAnimation(); //敗北時モーション
                    yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);
                }
            }
            
        }
        else if(playerUnit.character.condition == CharacterLibrary.CharacterCondition.麻痺) //プレイヤーユニットの状態が麻痺なら
        {
            yield return dialogBox.TypDialog(($"{playerUnit.character.name}は{playerUnit.character.condition}状態で動けない"), systemColor);

            if (currentAction == 1) //先行の攻撃 currentActionの数値に+1して後攻の攻撃に移る
            {
                currentAction++;
                StartCoroutine(FirstAction());
            }
            else if (currentAction == 4) //後攻の攻撃 currentActionの数値を0してもう一度速さを比べる
            {
                //paralysisMonsterCondition = true;

                currentAction = 5;
                StartCoroutine(FirstAction());
            }
            else  //変な数値が出てきたらエラーなので強制終了
            {
                playerUnit.PlayerFaintAnimation(); //敗北時モーション
                yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);

            }

        }
    }

    /// <summary>
    /// 敵ユニットの攻撃と状態異常付与処理
    /// </summary>
    /// <returns></returns>
    IEnumerator EnemyMove()
    {
        state = BattleStatus.EnemyMove;

        if(enemyUnit.character.condition != CharacterLibrary.CharacterCondition.麻痺)
        {
            yield return dialogBox.TypDialog(($" {enemyUnit.character.name} の攻撃"), systemColor);

            //技を決定 : ランダム
            enemyRouletObj.SetActive(true);
            enemyRoulet.startRoulett();
            enemyRoulet.SelectMove(false);
            yield return enemyRoulet.RoulettControll();
            MoveLibrary.MoveBase move = enemyUnit.character.Moves[enemyRoulet.selectMoveList[enemyRoulet.lostTime]];
            yield return new WaitForSeconds(2f);
            enemyRouletObj.SetActive(false);
            yield return dialogBox.TypDialog(($" {enemyUnit.character.name} は{move.name}をつかった"), systemColor);

            //命中率処理
            if (Random.Range(0, 100) <= move.accuracy)
            {
                Character.DamageDetails damageDetails = playerUnit.character.TakeDamage(move, enemyUnit.character);   //enemyダメージ計算


                //戦闘モーション
                enemyUnit.PlayerAttackAnimation();
                yield return new WaitForSeconds(0.7f);
                if (damageDetails.Critical > 1f)
                {
                    audioSource.PlayOneShot(crithikaruSound);
                }
                else
                {
                    audioSource.PlayOneShot(hitSound);
                }
                playerUnit.PlayerHitAnimation();


                
                yield return dialogBox.TypDialog(($"{playerUnit.character.name}は{playerUnit.character.Damage}のダメージを受けた"), systemColor);
                yield return playerHud.UpdateHP(); //HP反映

                //状態異常付与処理
                if (move.efficacy != playerUnit.character.condition)
                {
                    yield return ProcessingStatChange(move, playerUnit);
                }

                //相性/クリティカルダメージ
                yield return ShowDamageDetails(damageDetails);

                //戦闘不能処理
                if (damageDetails.Fainted)
                {
                    GManager.instance.buttolDefeat = true;
                    playerUnit.PlayerFaintAnimation(); //敗北時モーション
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}は戦闘不能"), systemColor);
                    yield return enemyTransform.DefeatAnimation();

                    GManager.instance.sceneTag = GManager.GameSceneTag.RESLT;
                    SceneManager.LoadScene("ResltScene");

                }
                else if (currentAction == 3) // 先行の攻撃 currentActionの数値に + 1して後攻の攻撃に移る
                {
                    currentAction += 1;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 2) //後攻の攻撃 currentActionの数値を0してもう一度速さを比べる
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else //変な数値が出てきたらエラーなので強制終了
                {
                    playerUnit.PlayerFaintAnimation(); //敗北時モーション
                    yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);
                }
            }
            else {

                yield return dialogBox.TypDialog(($" しかし、相手の{playerUnit.character.name} には当たらなかった"), systemColor);

                if (currentAction == 3) // 先行の攻撃 currentActionの数値に + 1して後攻の攻撃に移る
                {
                    currentAction += 1;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 2) //後攻の攻撃 currentActionの数値を0してもう一度速さを比べる
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else //変な数値が出てきたらエラーなので強制終了
                {
                    playerUnit.PlayerFaintAnimation(); //敗北時モーション
                    yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);
                }

            } 
            
        }
        else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.麻痺) //敵ユニットの状態が麻痺なら
        {
            yield return dialogBox.TypDialog(($"{enemyUnit.character.name}は{enemyUnit.character.condition}状態で動けない"), systemColor);

            if (currentAction == 3) //先行の攻撃 currentActionの数値に+1して後攻の攻撃に移る
            {
                currentAction++;
                StartCoroutine(FirstAction());
            }
            else if (currentAction == 2) //後攻の攻撃 currentActionの数値を5にして異常状態処理
            {
                paralysisHeroCondition = true;
                currentAction = 5;
                StartCoroutine(FirstAction());
            }
            else  //変な数値が出てきたらエラーなので強制終了
            {
                playerUnit.PlayerFaintAnimation(); //敗北時モーション
                yield return dialogBox.TypDialog(($"異常値強制終了"), systemColor);
            }

        }

    }


    /// <summary>
    /// バトルユニットの状態変更
    /// </summary>
    /// <param name="move"></param>
    /// <param name="battleUnit"></param>
    /// <returns></returns>
    IEnumerator ProcessingStatChange(MoveLibrary.MoveBase move, BattleUnit battleUnit)
    {

        if (move.efficacy == CharacterLibrary.CharacterCondition.火傷)
        {
            int r = Random.Range(0, 100);

            if (r <= 15)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.火傷; //火傷に変更
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}は{battleUnit.character.condition}になった"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.ジメジメ)
        {
            int r = Random.Range(0, 100);

            if (r <= 20)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.ジメジメ; //ジメジメに変更
                originalStatus = battleUnit.character.Attack;
                battleUnit.character.Attack = Mathf.FloorToInt(battleUnit.character.Attack - (battleUnit.character.Attack * 0.3f)); //バトルユニットの攻撃力を30％ダウン
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}は{battleUnit.character.condition}になった"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.追い風)
        {

            int r = Random.Range(0, 100);

            if (r <= 20)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.追い風; //追い風に変更
                originalStatus = battleUnit.character.Speed;
                battleUnit.character.Speed = Mathf.FloorToInt(battleUnit.character.Speed - (battleUnit.character.Speed * 0.3f)); //バトルユニットの素早さを30％ダウン
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}は{battleUnit.character.condition}になった"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.麻痺)
        {
            int r = Random.Range(0, 100);

            if (r <= 15)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.麻痺; //麻痺に変更
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}は{battleUnit.character.condition}になった"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.ドクドク)
        {

            int r = Random.Range(0, 100);

            if (r <= 10)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.ドクドク; //ドクドクに変更
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}は{battleUnit.character.condition}になった"), systemColor);
            }


        }

    }


    /// <summary>
    /// プレイヤーユニット状態異常処理
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageStatEfficacyMonster()
    {
        if(playerUnit.character.condition != CharacterLibrary.CharacterCondition.None)
        {
            if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.火傷)
            {
                conditionSwith = 1;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.ジメジメ)
            {
                conditionSwith = 2;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.追い風)
            {
                conditionSwith = 3;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.麻痺)
            {
                conditionSwith = 4;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.ドクドク)
            {
                conditionSwith = 5;
            }    

        }
        else
        {
            currentAction = 6;
            StartCoroutine(FirstAction());
        }

        switch (conditionSwith)
        {

            case 1:

                if (monsterTurn < 3)
                {
                    //火傷ダメージ処理
                    Character.StateProcessing stateProcessing = playerUnit.character.statEfficacy(playerUnit);
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}は{playerUnit.character.Damage}の火傷ダメージを受けた"), systemColor);
                    yield return playerHud.UpdateHP(); //HP反映
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}の{playerUnit.character.condition}は治った"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }

                break;

            case 2:

                if (monsterTurn < 3)
                {
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    playerUnit.character.Attack = originalStatus;
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}の{playerUnit.character.condition}は治った"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }

                break;

            case 3:

                if (monsterTurn < 3)
                {
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    playerUnit.character.Speed = originalStatus;
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}の{playerUnit.character.condition}は治った"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;
                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                break;

            case 4:

                if (paralysisMonsterCondition)
                {
                    
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}の{playerUnit.character.condition}は治った"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;


                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else
                {
                    paralysisMonsterCondition = true;
                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }

                break;

            case 5:

                if (monsterTurn < 3)
                {
                    Character.StateProcessing stateProcessing = playerUnit.character.statEfficacy(playerUnit);
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}は{playerUnit.character.condition}のダメージを受けた"), systemColor);
                    yield return playerHud.UpdateHP(); //HP反映
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}の{playerUnit.character.condition}は治った"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }

                break;
        }
      
    }

    /// <summary>
    /// 敵ユニット状態異常処理
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageStatEfficacyHero()
    {
        if (enemyUnit.character.condition != CharacterLibrary.CharacterCondition.None)
        {
            if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.火傷)
            {
                conditionSwith = 6;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.ジメジメ)
            {
                conditionSwith = 7;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.追い風)
            {
                conditionSwith = 8;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.麻痺)
            {
                conditionSwith = 9;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.ドクドク)
            {
                conditionSwith = 10;
            }
        }
        else
        {
            currentAction = 0;
            StartCoroutine(FirstAction());

        }

        switch (conditionSwith)
        {

            case 6:

                if (heroTurn < 3)
                {
                    Character.StateProcessing stateProcessing = enemyUnit.character.statEfficacy(enemyUnit);
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}は{enemyUnit.character.Damage}の火傷ダメージを受けた"), systemColor);
                    yield return enemyHud.UpdateHP(); //HP反映
                    heroTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (heroTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}の{enemyUnit.character.condition}は治った"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    heroTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }

                break;

            case 7:

                if (monsterTurn < 3)
                {
                    monsterTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    enemyUnit.character.Attack = originalStatus;
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}の{enemyUnit.character.condition}は治った"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }

                break;

            case 8:

                if (monsterTurn < 3)
                {
                    monsterTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    enemyUnit.character.Speed = originalStatus;
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}の{enemyUnit.character.condition}は治った"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                break;

            case 9:

                if (paralysisHeroCondition)
                {

                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}の{enemyUnit.character.condition}は治った"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else
                {
                    paralysisHeroCondition = true;
                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }

                break;

            case 10:

                if (heroTurn < 3)
                {
                    Character.StateProcessing stateProcessing = enemyUnit.character.statEfficacy(enemyUnit);
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}は{enemyUnit.character.condition}のダメージを受けた"), systemColor);
                    yield return enemyHud.UpdateHP(); //HP反映 
                    heroTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}の{enemyUnit.character.condition}は治った"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    heroTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }

                break;

        }
    }

    /// <summary>
    /// 効果処理とクリティカル処理
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowDamageDetails(Character.DamageDetails damageDetails)
    {
        if(damageDetails.Critical > 1f)
        {
            yield return dialogBox.TypDialog(($"急所に当たった"), systemColor);           
        }

        if(damageDetails.TypeEffectiveness > 1f)
        {
            yield return dialogBox.TypDialog(($"効果はバツグンだ"), systemColor);
        }
        else if(damageDetails.TypeEffectiveness < 1f)
        {
            yield return dialogBox.TypDialog(($"効果はいまひとつだ"), systemColor);

        }
       
        
        
    }

    /*
    /// <summary>
    /// 技の選択肢と技の情報の表示の指示だしをしている
    /// </summary>
    void PlayerMove()
    {
        state = BattleStatus.PlayerMove;
        dialogBox.EnableDialogText(false);
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableMoveSelector(true);
    }
    */

    /// <summary>
    /// BattleSceneの作成とFight選択までの導入の指示コルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator SetupBattle()
    {
        state = BattleStatus.Start;

        //モンスターの生成と描画
        audioSource.PlayOneShot(monsterBoise);
        playerUnit.SetUp();
        enemyUnit.SetUp();

        //HUDの描画
        playerHud.SetDate(playerUnit.character);
        enemyHud.SetDate(enemyUnit.character);

        //dialogBox.SetMoveNames(playerUnit.character.moveLibrary);

        yield return new WaitForSeconds(1);
        //メッセージを一文字ずつ表示させる
        yield return StartCoroutine(dialogBox.TypDialog(($"{playerUnit.character.name}！\nお前の野望も今日で最後だ！"), heroColor));
        yield return new WaitForSeconds(0.5f);

        if(debugFunction == 0)
        {
            StartCoroutine(HeroTransform());
        }
        else if(debugFunction == 1)
        {
            StartCoroutine(FirstAction());
        }

        
    }

    /// <summary>
    /// ヒーローの変身アニメーションコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator HeroTransform()
    {
        state = BattleStatus.TransformHero;

        audioSource.PlayOneShot(hensinBoise);
         yield return StartCoroutine(dialogBox.TypDialog(($"変身！"), heroColor));
        yield return new WaitForSeconds(0.5f);

        enemyTransform.ChangingHero();
        enemyTransform.EnableTransformHero(true); //変身帯表示
        enemyTransform.ExpansionEnterAnimation();
        enemyTransform.MoveChangingHero();
        yield return enemyTransform.ExpansionEnterAnimation(); //変身表示進入アニメーション

        audioSource.PlayOneShot(hennsinSound);

        yield return new WaitForSeconds(2f);
        enemyUnit.imageMonster.sprite = Sprite.Create(enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation, new Rect(0, 0, enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation.width, enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation.height), Vector2.zero); //enemyUnitの画像を変更

        yield return enemyTransform.ExpansionFaintAnimation(); //変身表示後退アニメーション
        enemyTransform.EnableTransformHero(false); //変身帯表示
        yield return new WaitForSeconds(1f);

        yield return enemyTransform.BattleStertAnimation(); //BattleStertTextアニメーション

        StartCoroutine(FirstAction());
    }

    /*
    /// <summary>
    /// PlayerActionSelectionでの行動を処理する
    /// </summary>
    void HandleActionSelection()
    {
        ////0:Fight 1:Run
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                currentAction++;
            }

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
            {
                currentAction--;
            }

        }

        //色をつけてどちらかを選択しているかわかるようにする
        dialogBox.UpdateActionSelection(currentAction);

        //Zを押したらTextが技選択に推移する
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                PlayerMove();

            }

        }
    }

    /// <summary>
    /// PlayerMoveSelectionでの行動を処理する
    /// </summary>
    void HandleMoveSelection()
    {
        //0:左上　1：左下　2：右上　3：右下
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Monster.Moves.Count - 1)
            {
                currentMove++;
            }

        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 0)
            {
                currentMove--;
            }

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Monster.Moves.Count - 2)
            {
                currentMove += 2;
            }


        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;
            }

        }                    
        
        //色をつけてどちらかを選択しているかわかるようにする
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Monster.Moves[currentMove]);

        //技決定
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //技選択用のUIを非表示
            dialogBox.EnableMoveSelector(false);

            //メッセ―ジの復活
            dialogBox.EnableDialogText(true);

            //技の決定
            //if(BattleUnit.)
            StartCoroutine(PerformPlayerMove());

        }
    */
}
 


