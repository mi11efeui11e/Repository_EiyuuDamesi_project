using System.Collections;
using UnityEngine;

public class ShugoKabe : MonoBehaviour
{
    public GameObject shugoseki1;
    public GameObject shugoseki2;
    public GameObject shugoseki3;
    public GameObject shugoKabe;
    public float fadeDuration = 1.5f; // �t�F�[�h�A�E�g����

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

        // �e�I�u�W�F�N�g���g�� ParticleSystem ���擾���邽�߁A�e�Ǝq�̗����� ParticleSystem ���擾
        ParticleSystem[] particles = obj.GetComponentsInChildren<ParticleSystem>(true);

        if (particles.Length == 0) yield break; // �p�[�e�B�N����������Ȃ���ΏI��

        float elapsedTime = 0f;

        // �t�F�[�h�A�E�g����
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

        // �t�F�[�h�A�E�g������ɃI�u�W�F�N�g���폜
        Destroy(obj);
    }
}
