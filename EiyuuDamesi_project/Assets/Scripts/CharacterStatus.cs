using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public bool isPlayer = false; // このオブジェクトが操作キャラかどうか

    void Start()
    {
        // 操作キャラなら `HPManager` から HP を取得
        if (isPlayer && HPManager.instance != null)
        {
            currentHP = HPManager.instance.GetHP();
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
