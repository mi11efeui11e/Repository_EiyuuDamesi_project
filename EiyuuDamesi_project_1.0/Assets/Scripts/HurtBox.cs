using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public CharacterStatus characterStatus;  // �L������HP���
    public CharacterBase characterBase;  // �L�����̃X�N���v�g�i���S���������j
    public ParticleSystem hitEffect;  // ��e�p�[�e�B�N��



    public void TakeDamage(AttackData attackData)
    {
        characterStatus.currentHP -= attackData.damage;
        Debug.Log(gameObject.name + " �� " + attackData.damage + " �̃_���[�W���󂯂��I");

        characterBase.OnHit(); //�L�����N�^�[�̃q�b�g���̏�����ǉ�

        if (hitEffect != null)
        {
            hitEffect.Play();
        }

        if (characterStatus.currentHP <= 0)
        {
            characterBase.OnDeath(); // �L�����N�^�[�̃X�N���v�g�Ɏ��S������ʒm
        }
    }
}

