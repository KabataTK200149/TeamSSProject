using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// BattleSystem�̕ϐ�
/// </summary>
public enum BattleStatus
{
    Start,
    TransformHero,
    FirstAction, //Player�s���I��
    PlayerMove,�@//Player�Z�I��
    EnemyMove, //Enemy�s���I��
    Busy,  //���̑�
}

/// <summary>
/// �o�g���̎w���o��
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

    [Header("0�Ȃ�ϐg�A�j���[�V��������A1�Ȃ�퓬����J�n")] public int debugFunction; //�f�o�b�O�p�֐�

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        //������
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
    /// �������ׂčU�����Ԃ����肵�A�U���A��Ԉُ�̏���
    /// </summary>
    IEnumerator FirstAction()
    {
        state = BattleStatus.FirstAction;
        
        //�U�����J�n����O�ɑ������ׂđ���������s�E�x��������U�ɍU�������锻�f��������
        if (currentAction == 0)
        {
            conditionSwith = 0;


            if (playerUnit.character.Speed > enemyUnit.character.Speed) //�v���C���[���j�b�g���������
            {
                currentAction++;
            }
            else if (playerUnit.character.Speed < enemyUnit.character.Speed) //�G���j�b�g���������
            {
                currentAction += 3;
            }
            else //�����������Ȃ烉���_���łǂ��炩��I��
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

        //�U�����߂��o���X�C�b�`�@1�G�v���C���[���j�b�g�����@2�G�v���C���[���j�b�g�񌂁@3�G�G���j�b�g�����@4�G�G���j�b�g�񌂁@5�G�v���C���[���j�b�g��Ԉُ폈���@6�F�G�v���C���[��Ԉُ폈��
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
    /// �v���C���[���j�b�g�̍U���Ə�Ԉُ�t�^����
    /// </summary>
    /// <returns></returns>
    IEnumerator PerformPlayerMove()
    {
        state = BattleStatus.Busy;

        if (playerUnit.character.condition != CharacterLibrary.CharacterCondition.���) //��Ⴢ̂Ƃ�
        {
            yield return dialogBox.TypDialog(($" {playerUnit.character.name} �̍U��"), systemColor);

            //�Z������
            playerRouletObj.SetActive(true); //���[���b�g��\��
            playerRoulet.startRoulett(); //���[���b�g�Ɏg�p����֐��̏�����
            playerRoulet.SelectMove(true); //���[���b�g�̒��g�̌���F����playerMove�Ȃ�true,enemyMove�Ȃ�false
            yield return playerRoulet.RoulettControll(); //�Z�����߂郋�[���b�g�̊J�n

            MoveLibrary.MoveBase move = playerUnit.character.Moves[playerRoulet.selectMoveList[playerRoulet.lostTime]]; //�Z���擾
            yield return new WaitForSeconds(2f);
            playerRouletObj.SetActive(false); //���[���b�g���\��
            yield return dialogBox.TypDialog(($" {playerUnit.character.name} ��{move.name}��������"), systemColor);

            if(Random.Range(0, 100) <= move.accuracy)
            {
                Character.DamageDetails damageDetails = enemyUnit.character.TakeDamage(move, playerUnit.character);  //enemy�_���[�W�v�Z

                //�퓬���[�V����
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

          
                yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.Damage}�̃_���[�W���󂯂�"), systemColor);
                yield return enemyHud.UpdateHP(); //HP���f

                //��Ԉُ�t�^����
                if (move.efficacy != enemyUnit.character.condition)
                {
                    yield return ProcessingStatChange(move, enemyUnit);
                }

                //����/�N���e�B�J���_���[�W
                yield return ShowDamageDetails(damageDetails);

                //�퓬�s�\����
                if (damageDetails.Fainted)
                {
                    GManager.instance.buttolDefeat = false; //�v���C���[�������Afalse
                    enemyUnit.PlayerFaintAnimation(); //�s�k�����[�V����


                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}�͐퓬�s�\"), systemColor);
                    yield return enemyTransform.VictoryAnimation();

                    GManager.instance.sceneTag = GManager.GameSceneTag.RESLT; //����̃Q�[���V�[�����ǂ��Ȃ̂��̔��ʃ^�O
                    SceneManager.LoadScene("ResltScene");
                }
                else if (currentAction == 1) //��s�̍U�� currentAction�̐��l��+1���Č�U�̍U���Ɉڂ�
                {
                    currentAction++;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 4) //��U�̍U�� currentAction�̐��l��0���Ă�����x�������ׂ�
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else  //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
                {
                    playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                    yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);
                }
            }
            else
            {
                yield return dialogBox.TypDialog(($" �������A�����{enemyUnit.character.name} �ɂ͓�����Ȃ�����"), systemColor);

                if (currentAction == 1) //��s�̍U�� currentAction�̐��l��+1���Č�U�̍U���Ɉڂ�
                {
                    currentAction++;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 4) //��U�̍U�� currentAction�̐��l��0���Ă�����x�������ׂ�
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else  //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
                {
                    playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                    yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);
                }
            }
            
        }
        else if(playerUnit.character.condition == CharacterLibrary.CharacterCondition.���) //�v���C���[���j�b�g�̏�Ԃ���ჂȂ�
        {
            yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}��Ԃœ����Ȃ�"), systemColor);

            if (currentAction == 1) //��s�̍U�� currentAction�̐��l��+1���Č�U�̍U���Ɉڂ�
            {
                currentAction++;
                StartCoroutine(FirstAction());
            }
            else if (currentAction == 4) //��U�̍U�� currentAction�̐��l��0���Ă�����x�������ׂ�
            {
                //paralysisMonsterCondition = true;

                currentAction = 5;
                StartCoroutine(FirstAction());
            }
            else  //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
            {
                playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);

            }

        }
    }

    /// <summary>
    /// �G���j�b�g�̍U���Ə�Ԉُ�t�^����
    /// </summary>
    /// <returns></returns>
    IEnumerator EnemyMove()
    {
        state = BattleStatus.EnemyMove;

        if(enemyUnit.character.condition != CharacterLibrary.CharacterCondition.���)
        {
            yield return dialogBox.TypDialog(($" {enemyUnit.character.name} �̍U��"), systemColor);

            //�Z������ : �����_��
            enemyRouletObj.SetActive(true);
            enemyRoulet.startRoulett();
            enemyRoulet.SelectMove(false);
            yield return enemyRoulet.RoulettControll();
            MoveLibrary.MoveBase move = enemyUnit.character.Moves[enemyRoulet.selectMoveList[enemyRoulet.lostTime]];
            yield return new WaitForSeconds(2f);
            enemyRouletObj.SetActive(false);
            yield return dialogBox.TypDialog(($" {enemyUnit.character.name} ��{move.name}��������"), systemColor);

            //����������
            if (Random.Range(0, 100) <= move.accuracy)
            {
                Character.DamageDetails damageDetails = playerUnit.character.TakeDamage(move, enemyUnit.character);   //enemy�_���[�W�v�Z


                //�퓬���[�V����
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


                
                yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.Damage}�̃_���[�W���󂯂�"), systemColor);
                yield return playerHud.UpdateHP(); //HP���f

                //��Ԉُ�t�^����
                if (move.efficacy != playerUnit.character.condition)
                {
                    yield return ProcessingStatChange(move, playerUnit);
                }

                //����/�N���e�B�J���_���[�W
                yield return ShowDamageDetails(damageDetails);

                //�퓬�s�\����
                if (damageDetails.Fainted)
                {
                    GManager.instance.buttolDefeat = true;
                    playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}�͐퓬�s�\"), systemColor);
                    yield return enemyTransform.DefeatAnimation();

                    GManager.instance.sceneTag = GManager.GameSceneTag.RESLT;
                    SceneManager.LoadScene("ResltScene");

                }
                else if (currentAction == 3) // ��s�̍U�� currentAction�̐��l�� + 1���Č�U�̍U���Ɉڂ�
                {
                    currentAction += 1;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 2) //��U�̍U�� currentAction�̐��l��0���Ă�����x�������ׂ�
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
                {
                    playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                    yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);
                }
            }
            else {

                yield return dialogBox.TypDialog(($" �������A�����{playerUnit.character.name} �ɂ͓�����Ȃ�����"), systemColor);

                if (currentAction == 3) // ��s�̍U�� currentAction�̐��l�� + 1���Č�U�̍U���Ɉڂ�
                {
                    currentAction += 1;
                    StartCoroutine(FirstAction());
                }
                else if (currentAction == 2) //��U�̍U�� currentAction�̐��l��0���Ă�����x�������ׂ�
                {
                    currentAction = 5;
                    StartCoroutine(FirstAction());
                }
                else //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
                {
                    playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                    yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);
                }

            } 
            
        }
        else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.���) //�G���j�b�g�̏�Ԃ���ჂȂ�
        {
            yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}��Ԃœ����Ȃ�"), systemColor);

            if (currentAction == 3) //��s�̍U�� currentAction�̐��l��+1���Č�U�̍U���Ɉڂ�
            {
                currentAction++;
                StartCoroutine(FirstAction());
            }
            else if (currentAction == 2) //��U�̍U�� currentAction�̐��l��5�ɂ��Ĉُ��ԏ���
            {
                paralysisHeroCondition = true;
                currentAction = 5;
                StartCoroutine(FirstAction());
            }
            else  //�ςȐ��l���o�Ă�����G���[�Ȃ̂ŋ����I��
            {
                playerUnit.PlayerFaintAnimation(); //�s�k�����[�V����
                yield return dialogBox.TypDialog(($"�ُ�l�����I��"), systemColor);
            }

        }

    }


    /// <summary>
    /// �o�g�����j�b�g�̏�ԕύX
    /// </summary>
    /// <param name="move"></param>
    /// <param name="battleUnit"></param>
    /// <returns></returns>
    IEnumerator ProcessingStatChange(MoveLibrary.MoveBase move, BattleUnit battleUnit)
    {

        if (move.efficacy == CharacterLibrary.CharacterCondition.�Ώ�)
        {
            int r = Random.Range(0, 100);

            if (r <= 15)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.�Ώ�; //�Ώ��ɕύX
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}��{battleUnit.character.condition}�ɂȂ���"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.�W���W��)
        {
            int r = Random.Range(0, 100);

            if (r <= 20)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.�W���W��; //�W���W���ɕύX
                originalStatus = battleUnit.character.Attack;
                battleUnit.character.Attack = Mathf.FloorToInt(battleUnit.character.Attack - (battleUnit.character.Attack * 0.3f)); //�o�g�����j�b�g�̍U���͂�30���_�E��
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}��{battleUnit.character.condition}�ɂȂ���"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.�ǂ���)
        {

            int r = Random.Range(0, 100);

            if (r <= 20)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.�ǂ���; //�ǂ����ɕύX
                originalStatus = battleUnit.character.Speed;
                battleUnit.character.Speed = Mathf.FloorToInt(battleUnit.character.Speed - (battleUnit.character.Speed * 0.3f)); //�o�g�����j�b�g�̑f������30���_�E��
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}��{battleUnit.character.condition}�ɂȂ���"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.���)
        {
            int r = Random.Range(0, 100);

            if (r <= 15)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.���; //��ჂɕύX
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}��{battleUnit.character.condition}�ɂȂ���"), systemColor);
            }

        }
        else if (move.efficacy == CharacterLibrary.CharacterCondition.�h�N�h�N)
        {

            int r = Random.Range(0, 100);

            if (r <= 10)
            {
                battleUnit.character.condition = CharacterLibrary.CharacterCondition.�h�N�h�N; //�h�N�h�N�ɕύX
                yield return dialogBox.TypDialog(($"{battleUnit.character.name}��{battleUnit.character.condition}�ɂȂ���"), systemColor);
            }


        }

    }


    /// <summary>
    /// �v���C���[���j�b�g��Ԉُ폈��
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageStatEfficacyMonster()
    {
        if(playerUnit.character.condition != CharacterLibrary.CharacterCondition.None)
        {
            if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.�Ώ�)
            {
                conditionSwith = 1;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.�W���W��)
            {
                conditionSwith = 2;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.�ǂ���)
            {
                conditionSwith = 3;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.���)
            {
                conditionSwith = 4;
            }
            else if (playerUnit.character.condition == CharacterLibrary.CharacterCondition.�h�N�h�N)
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
                    //�Ώ��_���[�W����
                    Character.StateProcessing stateProcessing = playerUnit.character.statEfficacy(playerUnit);
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.Damage}�̉Ώ��_���[�W���󂯂�"), systemColor);
                    yield return playerHud.UpdateHP(); //HP���f
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�͎�����"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;
                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                break;

            case 4:

                if (paralysisMonsterCondition)
                {
                    
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�̃_���[�W���󂯂�"), systemColor);
                    yield return playerHud.UpdateHP(); //HP���f
                    monsterTurn++;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{playerUnit.character.name}��{playerUnit.character.condition}�͎�����"), systemColor);
                    playerUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 6;
                    StartCoroutine(FirstAction());
                }

                break;
        }
      
    }

    /// <summary>
    /// �G���j�b�g��Ԉُ폈��
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageStatEfficacyHero()
    {
        if (enemyUnit.character.condition != CharacterLibrary.CharacterCondition.None)
        {
            if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.�Ώ�)
            {
                conditionSwith = 6;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.�W���W��)
            {
                conditionSwith = 7;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.�ǂ���)
            {
                conditionSwith = 8;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.���)
            {
                conditionSwith = 9;
            }
            else if (enemyUnit.character.condition == CharacterLibrary.CharacterCondition.�h�N�h�N)
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
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.Damage}�̉Ώ��_���[�W���󂯂�"), systemColor);
                    yield return enemyHud.UpdateHP(); //HP���f
                    heroTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (heroTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�͎�����"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    monsterTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                break;

            case 9:

                if (paralysisHeroCondition)
                {

                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�͎�����"), systemColor);
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
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�̃_���[�W���󂯂�"), systemColor);
                    yield return enemyHud.UpdateHP(); //HP���f 
                    heroTurn++;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }
                else if (monsterTurn == 3)
                {
                    yield return dialogBox.TypDialog(($"{enemyUnit.character.name}��{enemyUnit.character.condition}�͎�����"), systemColor);
                    enemyUnit.character.condition = CharacterLibrary.CharacterCondition.None;
                    heroTurn = 0;

                    currentAction = 0;
                    StartCoroutine(FirstAction());
                }

                break;

        }
    }

    /// <summary>
    /// ���ʏ����ƃN���e�B�J������
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowDamageDetails(Character.DamageDetails damageDetails)
    {
        if(damageDetails.Critical > 1f)
        {
            yield return dialogBox.TypDialog(($"�}���ɓ�������"), systemColor);           
        }

        if(damageDetails.TypeEffectiveness > 1f)
        {
            yield return dialogBox.TypDialog(($"���ʂ̓o�c�O����"), systemColor);
        }
        else if(damageDetails.TypeEffectiveness < 1f)
        {
            yield return dialogBox.TypDialog(($"���ʂ͂��܂ЂƂ�"), systemColor);

        }
       
        
        
    }

    /*
    /// <summary>
    /// �Z�̑I�����ƋZ�̏��̕\���̎w�����������Ă���
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
    /// BattleScene�̍쐬��Fight�I���܂ł̓����̎w���R���[�`��
    /// </summary>
    /// <returns></returns>
    IEnumerator SetupBattle()
    {
        state = BattleStatus.Start;

        //�����X�^�[�̐����ƕ`��
        audioSource.PlayOneShot(monsterBoise);
        playerUnit.SetUp();
        enemyUnit.SetUp();

        //HUD�̕`��
        playerHud.SetDate(playerUnit.character);
        enemyHud.SetDate(enemyUnit.character);

        //dialogBox.SetMoveNames(playerUnit.character.moveLibrary);

        yield return new WaitForSeconds(1);
        //���b�Z�[�W���ꕶ�����\��������
        yield return StartCoroutine(dialogBox.TypDialog(($"{playerUnit.character.name}�I\n���O�̖�]�������ōŌゾ�I"), heroColor));
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
    /// �q�[���[�̕ϐg�A�j���[�V�����R���[�`��
    /// </summary>
    /// <returns></returns>
    IEnumerator HeroTransform()
    {
        state = BattleStatus.TransformHero;

        audioSource.PlayOneShot(hensinBoise);
         yield return StartCoroutine(dialogBox.TypDialog(($"�ϐg�I"), heroColor));
        yield return new WaitForSeconds(0.5f);

        enemyTransform.ChangingHero();
        enemyTransform.EnableTransformHero(true); //�ϐg�ѕ\��
        enemyTransform.ExpansionEnterAnimation();
        enemyTransform.MoveChangingHero();
        yield return enemyTransform.ExpansionEnterAnimation(); //�ϐg�\���i���A�j���[�V����

        audioSource.PlayOneShot(hennsinSound);

        yield return new WaitForSeconds(2f);
        enemyUnit.imageMonster.sprite = Sprite.Create(enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation, new Rect(0, 0, enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation.width, enemyUnit.CharacterLibrary.Hero[enemyUnit.battleHeroNunber].transformation.height), Vector2.zero); //enemyUnit�̉摜��ύX

        yield return enemyTransform.ExpansionFaintAnimation(); //�ϐg�\����ރA�j���[�V����
        enemyTransform.EnableTransformHero(false); //�ϐg�ѕ\��
        yield return new WaitForSeconds(1f);

        yield return enemyTransform.BattleStertAnimation(); //BattleStertText�A�j���[�V����

        StartCoroutine(FirstAction());
    }

    /*
    /// <summary>
    /// PlayerActionSelection�ł̍s������������
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

        //�F�����Ăǂ��炩��I�����Ă��邩�킩��悤�ɂ���
        dialogBox.UpdateActionSelection(currentAction);

        //Z����������Text���Z�I���ɐ��ڂ���
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                PlayerMove();

            }

        }
    }

    /// <summary>
    /// PlayerMoveSelection�ł̍s������������
    /// </summary>
    void HandleMoveSelection()
    {
        //0:����@1�F�����@2�F�E��@3�F�E��
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
        
        //�F�����Ăǂ��炩��I�����Ă��邩�킩��悤�ɂ���
        dialogBox.UpdateMoveSelection(currentMove, playerUnit.Monster.Moves[currentMove]);

        //�Z����
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //�Z�I��p��UI���\��
            dialogBox.EnableMoveSelector(false);

            //���b�Z�\�W�̕���
            dialogBox.EnableDialogText(true);

            //�Z�̌���
            //if(BattleUnit.)
            StartCoroutine(PerformPlayerMove());

        }
    */
}
 


