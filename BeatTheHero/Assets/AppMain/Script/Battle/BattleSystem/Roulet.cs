using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulet : MonoBehaviour
{
    [SerializeField] Image[] commandImageList;
    [SerializeField] Text[] commandTextList;

    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;

    public List<int> selectMoveList = new List<int>();
    private float countTime, fireTime, speed, lottery, stopTime, elapsedTime, tenmetu;
    private bool isStop, justOnce, stopBool, end;
    public int lostTime;

    public AudioClip rouletSE, confirmSE;
    AudioSource audioSource;

    public IEnumerator RoulettControll()
    {
        while(!end)
        {
            if (!stopBool)
            {
                stopTime = Random.Range(2f, 3.5f);
                Debug.Log(stopTime);
                stopBool = true;
            }

            //タイマーA
            countTime += Time.deltaTime * speed;

            if (countTime > commandImageList.Length)
            {
                countTime = 0f;
            }

            //タイマーB
            fireTime += Time.deltaTime;

            if (lostTime != (int)countTime)
            {
                fireTime = 0f;
                foreach (var command in commandImageList)
                {
                    command.color = new Color(1, 1, 1);
                }
                lostTime = (int)countTime;
                audioSource.PlayOneShot(rouletSE);
                commandImageList[(int)countTime].color = new Color(1, 0, 0);

            }

            if (stopTime <= elapsedTime && !isStop)
            {
                isStop = true;
                lottery = Random.Range(990, 997) * 0.001f;
            }
            if (isStop)
            {
                speed *= lottery;
            }
            if (fireTime >= 2.5 && justOnce)
            {
                fireTime = 0;
                justOnce = false;
            }

            if(isStop && lostTime == (int)countTime)
            {
                audioSource.PlayOneShot(confirmSE);
                end = true;
            }

            elapsedTime += Time.deltaTime;
            yield return null;

        }


    }
    public void startRoulett()
    {
        audioSource = GetComponent<AudioSource>();
        isStop = false;
        speed = 10;
        justOnce = true;
        countTime = 0;
        fireTime = 0;
        elapsedTime = 0;
        end = false;
        stopBool = false;

    }

    public void SelectMove(bool player)
    {
        selectMoveList = new List<int>();

        if (player)
        {
            foreach (var unit in commandTextList)
            {
                int move = Random.Range(0, playerUnit.character.Moves.Count);
                unit.text = playerUnit.character.Moves[move].name;
                selectMoveList.Add(move);

            }
        }
        else
        {
            foreach (var unit in commandTextList)
            {
                int move = Random.Range(0, enemyUnit.character.Moves.Count);
                unit.text = enemyUnit.character.Moves[move].name;
                selectMoveList.Add(move);

            }
        }
    }

  
}
