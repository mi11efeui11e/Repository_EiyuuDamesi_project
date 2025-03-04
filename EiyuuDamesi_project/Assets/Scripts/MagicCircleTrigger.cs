using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicCircleTrigger : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // 遷移先のシーン名
    public float fadeDuration = 1.5f; // フェードイン・アウトの時間
    public Image fadePanel; // UIの黒いパネル（共通利用）

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 1); // 初期状態は黒（フェードインのため）
            StartCoroutine(FadeIn()); // シーン開始時にフェードイン
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // "Player" タグのキャラクターが入ったら
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private IEnumerator FadeIn() // 黒→透明のフェードイン
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeOutAndLoadScene() // 透明→黒のフェードアウト
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName); // シーンを変更
    }
}
