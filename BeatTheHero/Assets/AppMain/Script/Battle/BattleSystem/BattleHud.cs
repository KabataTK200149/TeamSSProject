using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �o�g�����̃����X�^�[���̃e�L�X�g�\��
/// </summary>
public class BattleHud : MonoBehaviour
{

    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Character _character;
    

    /// <summary>
    /// ���x���AHP�A���O�̈ʒu�ɉ���\������̂���ݒ�
    /// </summary>
    /// <param name="monster"></param>
    public void SetDate(Character character)
    {
        _character = character;
    }

    /// <summary>
    /// HP�o�[�����̃R���[�`���𔭓�
    /// </summary>
    /// <returns></returns>
    public IEnumerator UpdateHP()
    { 
        yield return hpBar.SetHPSmooth((float)_character.HP / _character.MaxHP);   
    }

}
