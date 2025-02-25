using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public CharacterStatus characterStatus;  // キャラのHP情報
    public CharacterBase characterBase;  // キャラのスクリプト（死亡処理を持つ）
    public ParticleSystem hitEffect;  // 被弾パーティクル



    public void TakeDamage(AttackData attackData)
    {
        characterStatus.currentHP -= attackData.damage;
        Debug.Log(gameObject.name + " が " + attackData.damage + " のダメージを受けた！");

        characterBase.OnHit(); //キャラクターのヒット時の処理を追加

        if (hitEffect != null)
        {
            hitEffect.Play();
        }

        if (characterStatus.currentHP <= 0)
        {
            characterBase.OnDeath(); // キャラクターのスクリプトに死亡処理を通知
        }
    }
}

