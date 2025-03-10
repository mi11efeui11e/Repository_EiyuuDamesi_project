using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public AttackData attackData; //攻撃データ

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HitBox が " + other.gameObject.name + " に当たった！");

        // HurtBoxを持っているキャラクターにダメージを与える
        HurtBox hurtBox = other.GetComponent<HurtBox>();

        /*if (hurtBox == null)
        {
            Debug.LogError("`HurtBox` が見つからない！ `other` のオブジェクト名: " + other.gameObject.name);
            return;
        }*/

        if (hurtBox != null)
        {
            Debug.Log("HurtBox を検出！ダメージ処理を実行");

            hurtBox.TakeDamage(attackData);
        }
    }

}