using System.Collections;
using UnityEngine;

public class ParticleToggle : MonoBehaviour
{
    public ParticleSystem particleEffect; // パーティクルエフェクト
    public GameObject toggleObject; // 通常オブジェクト（エフェクトやモデルなど）
    public float onTime = 2f; // ONの時間（Inspectorで調整）
    public float offTime = 3f; // OFFの時間（Inspectorで調整）

    private void Start()
    {
        StartCoroutine(ToggleEffect());
    }

    private IEnumerator ToggleEffect()
    {
        while (true) // 無限ループ
        {
            // パーティクル ON
            if (particleEffect != null)
            {
                particleEffect.Play();
            }

            // 通常オブジェクト ON
            if (toggleObject != null)
            {
                toggleObject.SetActive(true);
            }

            yield return new WaitForSeconds(onTime); // ON時間待つ

            // パーティクル OFF
            if (particleEffect != null)
            {
                particleEffect.Stop();
            }

            // 通常オブジェクト OFF
            if (toggleObject != null)
            {
                toggleObject.SetActive(false);
            }

            yield return new WaitForSeconds(offTime); // OFF時間待つ
        }
    }
}
