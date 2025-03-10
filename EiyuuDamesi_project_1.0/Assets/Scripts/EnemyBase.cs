using System.Collections;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    public GameObject enemy;
    public GameObject hitBox;
    public AudioSource hitAudioSource;
    public AudioSource deathAudioSource;
    public ParticleSystem hitEffect; //hit���G�t�F�N�g
    public Animator animator;          //�A�j���[�V�����R���|�l���g�Ή��̕ϐ�


    public override void OnHit() // �U�����󂯂��ۂɌĂ΂��֐�
    {
        // �����Ƀ_���[�W�����Ȃǂ�ǉ�
        hitAudioSource.Play();
    }

    public override void OnDeath() // �̗͂�0�ɂȂ����ۂɌĂ΂��֐�
    {
        deathAudioSource.Play();
        Invoke("Delete", 2);
        Debug.Log("�[����");
        hitEffect.Play();
        animator.SetBool("Death", true);
    }

    public void HitStart()
    {
        hitBox.SetActive(true);
    }

    public void HitEnd()
    {
        hitBox.SetActive(false);
    }

    public void Delete()
    {
        enemy.SetActive(false);
    }

}