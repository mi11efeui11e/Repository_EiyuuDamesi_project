using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{

    public AudioSource bossAudioSource;
    public GameObject bossHPBar;
    public GameObject targetObject;

    public string nextSceneName = "NextScene"; // 遷移先のシーン名
    public float fadeDuration = 1.5f; // フェードイン・アウトの時間
    public Image fadePanel; // UIの黒いパネル（共通利用）

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 1); // 初期状態は黒（フェードインのため）
        }
    }

    void Update()
    {
        if (targetObject != null && !targetObject.activeSelf) // オブジェクトが非表示なら
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーのみ判定
        {
            PlayBossSound();
            bossHPBar.SetActive(true);
        }
    }

    public void PlayBossSound()
    {
        bossAudioSource.Play();
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
