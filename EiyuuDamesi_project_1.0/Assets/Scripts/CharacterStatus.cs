using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public bool isPlayer = false; // このオブジェクトが操作キャラかどうか

    void Start()
    {

        if (DeathManager.instance.deathCheck == 1) //もし前シーンで死亡していたら体力を引き継がずに回復
        {
            Debug.Log($"シーン開始時ステータス回復");
            currentHP = maxHP;
            Debug.Log($"ステータスリセット後のHP: {currentHP}");
        }

        // 操作キャラなら `HPManager` から HP を取得
        if (isPlayer && HPManager.instance != null)
        {
            currentHP = HPManager.instance.GetHP();
            Debug.Log($"リセット後のMから取得のHP: {currentHP}");
        }
        else
        {
            currentHP = maxHP; // 通常の敵キャラ・オブジェクトは maxHP で初期化
        }
    }

    void Update()
    {
        // 操作キャラなら `HPManager` に同期
        if (isPlayer && HPManager.instance != null)
        {
            HPManager.instance.SetHP(currentHP);
        }
    }
}
