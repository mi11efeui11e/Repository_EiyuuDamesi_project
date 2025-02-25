using UnityEngine;

public class HumanBase : CharacterBase
{
    
    public Animator animator; // Animator�R���|�[�l���g
    public GameObject hurtBox; //�L�����N�^�[�̓����蔻����ꎞ�I�ɖ������Ė��G���Ԃ����B

    public override void OnHit()
    {
        animator.SetInteger("Motion", 10);

        hurtBox.SetActive(false);
    }

    public override void OnDeath()
    {
        Debug.Log("�������|�ꂽ�I�G�t�F�N�g�Đ� & �X�R�A���Z");
        // �����G�t�F�N�g���o��
        // �X�R�A�����Z
        animator.SetInteger("Motion", 9);
    }


}