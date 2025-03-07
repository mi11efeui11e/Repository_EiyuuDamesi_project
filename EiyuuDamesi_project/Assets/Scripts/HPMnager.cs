using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager instance; // シングルトン
    public float currentHP;
    public float maxHP = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも削除されない
            currentHP = maxHP; // 初期HP設定
        }
        else
        {
            Destroy(gameObject); // 重複を防ぐ
        }
    }

    public void SetHP(float hp)
    {
        currentHP = hp;
    }

    public float GetHP()
    {
        return currentHP;
    }

    // **死亡時に HP を回復するメソッド**
    public void ResetHP()
    {
        Debug.Log("HPリセット");
        currentHP = maxHP;
        Debug.Log($"リセット後のHP: {currentHP}");
        DeathManager.instance.deathCheck = 0; //回復させたあと前シーンでの死亡判定を無くす。
    }
}
