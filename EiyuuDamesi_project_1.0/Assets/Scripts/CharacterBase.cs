using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    public abstract void OnDeath(); // キャラごとに異なる死亡処理を実装するためのメソッド
    public abstract void OnHit(); // キャラごとに異なる被弾処理を実装するためのメソッド
}
