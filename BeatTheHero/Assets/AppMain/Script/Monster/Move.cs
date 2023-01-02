using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Monsterが実際に使うときの技データ
///使いやすいようにするためにPPをもつ
/// </summary>
public class Move : MonoBehaviour
{

    //Monster.csが参照するのでpublicにしておく
    public MoveLibrary Base { get; set; }
    public int PP { get; set; }

    //初期化
    public Move(MoveLibrary pBase)
    {
        Base = pBase; 
    }
}
