using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // マウスカーソルを非表示にしてロック
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ESCキーでカーソルを再表示して解除（開発中やデバッグ用）
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // 再びマウスをロック（ゲームプレイ中に再設定する例）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

