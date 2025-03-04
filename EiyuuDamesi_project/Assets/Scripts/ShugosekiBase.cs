using System.Collections;
using UnityEngine;

public class ShugosekiBase : CharacterBase
{
    public GameObject shugoseki;
    public float fadeDuration = 1.5f; // フェードアウト時間

    public override void OnHit() // 攻撃を受けた際に呼ばれる関数
    {
        // ここにダメージ処理などを追加
    }

    public override void OnDeath() // 体力が0になった際に呼ばれる関数
    {
        if (shugoseki != null)
        {
            Debug.Log("OnDeth");
            StartCoroutine(FadeOutAndDestroy(shugoseki, fadeDuration));
        }
    }

    private IEnumerator FadeOutAndDestroy(GameObject obj, float duration)
    {
        if (obj == null) yield break;

        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer == null) yield break;

        Material mat = renderer.material;
        Color startColor = mat.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            mat.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        Destroy(obj);
    }
}
