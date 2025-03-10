using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonManager : MonoBehaviour
{
    public Button sceneChangeButton; // シーン移行ボタン
    public Button otherButton; // 未定ボタン
    public Button backButton; //how からタイトルへ戻るボタン

    public GameObject titleCanvas;
    public GameObject howCanvas;

    public string targetSceneName = "GameScene"; // 遷移先のシーン名（Inspector で設定可）

    public Image fadeImage; // フェードアウト用の Image
    public float fadeDuration = 1.5f; // フェードの時間

    public AudioSource buttonAudioSource;

    

    private void Start()
    {
        // シーン移行ボタンのクリックイベント
        if (sceneChangeButton != null)
        {
            sceneChangeButton.onClick.AddListener(() => StartCoroutine(FadeOutAndChangeScene()));
        }

        // まだ決まっていないボタンの処理（仮）
        if (otherButton != null)
        {
            otherButton.onClick.AddListener(UnassignedAction);
        }

        // フェード用の画像を透明に
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true); // Image をアクティブにする
            fadeImage.color = new Color(0, 0, 0, 0); // 完全に透明にする
        }
    }

    // フェードアウトしながらシーンを変更する
    private IEnumerator FadeOutAndChangeScene()
    {
        if (fadeImage != null)
        {
            float elapsedTime = 0f;
            Color fadeColor = fadeImage.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // アルファ値を増加
                fadeImage.color = fadeColor;
                yield return null;
            }
        }

        // フェードアウトが終わったらシーン遷移
        SceneManager.LoadScene(targetSceneName);
    }

    // 未定のボタンの処理（後で変更）
    public void UnassignedAction()
    {
        titleCanvas.SetActive(false);
        howCanvas.SetActive(true);
    }

    public void BackButtonAction()
    {
        titleCanvas.SetActive(true);
        howCanvas.SetActive(false);
    }

    public void PlayButtonSound()
    {
        buttonAudioSource.Play();
    }

}
