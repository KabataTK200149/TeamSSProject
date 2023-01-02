using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HP�̑����̕`��
/// </summary>
public class HPBar : MonoBehaviour
{
    //HP�o�[��gameobject�擾
    [SerializeField] GameObject health;

    /// <summary>
    /// HP�o�[�����X�Ɍ��炵�Ă����v�Z�����Ă���R���[�`��
    /// </summary>
    /// <param name="newHP"></param>
    /// <returns></returns>
    public IEnumerator SetHPSmooth(float newHP)
    {
        float currentHP = health.transform.localScale.x;
        float changeAmount = currentHP - newHP;

        //currerHP��newHP�ɍ�������Ȃ�J��Ԃ�
        while(currentHP - newHP > Mathf.Epsilon)
        {
            currentHP -= changeAmount * Time.deltaTime;
            health.transform.localScale = new Vector3(currentHP, 1, 1);
            yield return null;
        }

        health.transform.localScale = new Vector3(newHP, 1, 1);
    }
}
