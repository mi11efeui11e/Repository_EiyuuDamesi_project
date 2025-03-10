using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public AttackData attackData; //�U���f�[�^

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HitBox �� " + other.gameObject.name + " �ɓ��������I");

        // HurtBox�������Ă���L�����N�^�[�Ƀ_���[�W��^����
        HurtBox hurtBox = other.GetComponent<HurtBox>();

        /*if (hurtBox == null)
        {
            Debug.LogError("`HurtBox` ��������Ȃ��I `other` �̃I�u�W�F�N�g��: " + other.gameObject.name);
            return;
        }*/

        if (hurtBox != null)
        {
            Debug.Log("HurtBox �����o�I�_���[�W���������s");

            hurtBox.TakeDamage(attackData);
        }
    }

}