using System.Collections;
using UnityEngine;

public class ShugoKabe : MonoBehaviour
{
    public GameObject shugoseki1;
    public GameObject shugoseki2;
    public GameObject shugoseki3;
    public GameObject shugoKabe;
    public float fadeDuration = 1.5f; // フェードアウト時間

    void Update()
    {
        if (shugoseki1 == null && shugoseki2 == null && shugoseki3 == null)
        {
            StartCoroutine(FadeOutAndDestroyParticles(shugoKabe, fadeDuration));
        }
    }

    private IEnumerator FadeOutAndDestroyParticles(GameObject obj, float duration)
    {
        if (obj == null) yield break;

        // 親オブジェクト自身の ParticleSystem も取得するため、親と子の両方の ParticleSystem を取得
        ParticleSystem[] particles = obj.GetComponentsInChildren<ParticleSystem>(true);

        if (particles.Length == 0) yield break; // パーティクルが見つからなければ終了

        float elapsedTime = 0f;

        // フェードアウト処理
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);

            foreach (ParticleSystem ps in particles)
            {
                var main = ps.main;
                Color startColor = main.startColor.color;
                main.startColor = new Color(startColor.r, startColor.g, startColor.b, alpha);
            }

            yield return null;
        }

        // フェードアウト完了後にオブジェクトを削除
        Destroy(obj);
    }
}
