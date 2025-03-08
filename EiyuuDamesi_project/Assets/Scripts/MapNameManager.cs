using System.Collections;
using UnityEngine;
using UnityEngine.UI; // UI �R���|�[�l���g������
using TMPro; // TextMeshPro ���g���ꍇ

public class FadeUI : MonoBehaviour
{
    public float fadeDuration = 1.0f; // �t�F�[�h�ɂ����鎞�ԁi�b�j
    public float displayTime = 2.0f; // ���S�ɕ\������鎞��
    private CanvasGroup canvasGroup;

    void Start()
    {
        // �I�u�W�F�N�g�� CanvasGroup �����邩�m�F���A�Ȃ���Βǉ�����
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        // �J�n���͓���
        canvasGroup.alpha = 0;

        // �t�F�[�h�C�������J�n
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // �t�F�[�h�C��
        yield return StartCoroutine(Fade(0, 1, fadeDuration));

        // ��莞�ԕ\��
        yield return new WaitForSeconds(displayTime);

        // �t�F�[�h�A�E�g
        yield return StartCoroutine(Fade(1, 0, fadeDuration));

        // ���S�ɏ�������I�u�W�F�N�g���A�N�e�B�u��
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
        canvasGroup.alpha = endAlpha; // �ŏI�l���Z�b�g
    }
}
