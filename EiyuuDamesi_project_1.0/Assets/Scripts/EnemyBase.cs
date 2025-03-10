using System.Collections;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    public GameObject enemy;
    public GameObject hitBox;
    public AudioSource hitAudioSource;
    public AudioSource deathAudioSource;
    public ParticleSystem hitEffect; //hit時エフェクト
    public Animator animator;          //アニメーションコンポネント対応の変数


    public override void OnHit() // 攻撃を受けた際に呼ばれる関数
    {
        // ここにダメージ処理などを追加
        hitAudioSource.Play();
    }

    public override void OnDeath() // 体力が0になった際に呼ばれる関数
    {
        deathAudioSource.Play();
        Invoke("Delete", 2);
        Debug.Log("骸骨死");
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