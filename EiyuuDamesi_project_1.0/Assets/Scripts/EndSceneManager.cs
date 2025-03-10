using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要

public class SceneChangeOnDisable : MonoBehaviour
{
    public GameObject targetObject; // 監視するオブジェクト
    public string nextSceneName = "NextScene"; // 移動先のシーン名

    void Update()
    {
        if (targetObject != null && !targetObject.activeSelf) // オブジェクトが非表示なら
        {
            SceneManager.LoadScene(nextSceneName); // 次のシーンに移動
        }
    }
}
