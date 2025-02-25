using UnityEngine;

public class HumanBase : CharacterBase
{
    
    public Animator animator; // Animatorコンポーネント
    public GameObject hurtBox; //キャラクターの当たり判定を一時的に無くして無敵時間を作る。

    public override void OnHit()
    {
        animator.SetInteger("Motion", 10);

        hurtBox.SetActive(false);
    }

    public override void OnDeath()
    {
        Debug.Log("自分が倒れた！エフェクト再生 & スコア加算");
        // 爆発エフェクトを出す
        // スコアを加算
        animator.SetInteger("Motion", 9);
    }


}