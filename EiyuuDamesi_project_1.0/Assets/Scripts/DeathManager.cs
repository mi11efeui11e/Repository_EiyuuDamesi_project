using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager instance; // シングルトン
    public int deathCheck; //前シーンで死亡しているかの判定変数　0→していない　1→死亡した

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでも削除されない
            deathCheck = 0; // 初期は死亡判定0（前シーンで死亡していないということ）
        }
        else
        {
            Destroy(gameObject); // 重複を防ぐ
        }
    }

}
