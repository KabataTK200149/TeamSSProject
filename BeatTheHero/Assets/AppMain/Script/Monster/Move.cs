using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Monster�����ۂɎg���Ƃ��̋Z�f�[�^
///�g���₷���悤�ɂ��邽�߂�PP������
/// </summary>
public class Move : MonoBehaviour
{

    //Monster.cs���Q�Ƃ���̂�public�ɂ��Ă���
    public MoveLibrary Base { get; set; }
    public int PP { get; set; }

    //������
    public Move(MoveLibrary pBase)
    {
        Base = pBase; 
    }
}
