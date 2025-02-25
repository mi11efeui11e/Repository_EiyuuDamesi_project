using UnityEngine;

public class ShugosekiBase : CharacterBase
{
    public GameObject shugoseki;

    public override void OnHit()
    {

    }

    public override void OnDeath()
    {
        //Debug.Log("敵が倒れた！エフェクト再生 & スコア加算");
        // 爆発エフェクトを出す
        // スコアを加算
        GetComponent<DissolveEffect>().StartDissolve();
    }
}