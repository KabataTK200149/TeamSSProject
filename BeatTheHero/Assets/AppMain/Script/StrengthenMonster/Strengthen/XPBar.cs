using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPBar : MonoBehaviour
{
    public float changeAmount;

    /// <summary>
    /// �o���l�̃o�[�̊������v�Z���ē��Ă͂߂�
    /// </summary>
    /// <param name="LV"></param>
    /// <param name="XP"></param>
    public void SetXPSmooth(int LV, int XP, GameObject experience)
    {
        float currentXP = experience.transform.localScale.x; //�o�[�̃X�P�[��
        float developXP = (100 * Mathf.Pow(1.1f, ((float)LV))); //���̃��x���ɑ΂��ĕK�v�Ȍo���l pow:�w���v�Z
        
        
        if(LV == 1)
        {
            developXP -= 10;
        }

        changeAmount = (XP / developXP); //���̌o���l�Ƃ��̃��x�����烌�x���A�b�v����̂ɕK�v�Ȍo���l�̊���

        if(currentXP - changeAmount > Mathf.Epsilon)
        {
            experience.transform.localScale = new Vector3(changeAmount, 1, 1); //���������炷:�ύX���ő傪1�ōŏ���0�Ȃ̂ŏ����_�������Ȃ�����
        }



    }
}
