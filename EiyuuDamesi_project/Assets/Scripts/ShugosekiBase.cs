using System.Collections;
using UnityEngine;

public class ShugosekiBase : CharacterBase
{
    public GameObject shugoseki;
    public float fadeDuration = 1.5f; // �t�F�[�h�A�E�g����

    public override void OnHit() // �U�����󂯂��ۂɌĂ΂��֐�
    {
        // �����Ƀ_���[�W�����Ȃǂ�ǉ�
    }

    public override void OnDeath() // �̗͂�0�ɂȂ����ۂɌĂ΂��֐�
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
