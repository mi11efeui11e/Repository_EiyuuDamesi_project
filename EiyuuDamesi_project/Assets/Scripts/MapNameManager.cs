using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI コンポーネントを扱う
using TMPro; // TextMeshPro を使う場合

public class FadeUI : MonoBehaviour
{
    public float fadeDuration = 1.0f; // フェードにかかる時間（秒）
    public float displayTime = 2.0f; // 完全に表示される時間
    private CanvasGroup canvasGroup;

    void Start()
    {
        // オブジェクトに CanvasGroup があるか確認し、なければ追加する
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // 開始時は透明
        canvasGroup.alpha = 0;

        // フェードイン処理開始
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // フェードイン
        yield return StartCoroutine(Fade(0, 1, fadeDuration));

        // 一定時間表示
        yield return new WaitForSeconds(displayTime);

        // フェードアウト
        yield return StartCoroutine(Fade(1, 0, fadeDuration));

        // 完全に消えたらオブジェクトを非アクティブ化
        gameObject.SetActive(false);
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            yield return null;
        }
        canvasGroup.alpha = endAlpha; // 最終値をセット
    }
}
