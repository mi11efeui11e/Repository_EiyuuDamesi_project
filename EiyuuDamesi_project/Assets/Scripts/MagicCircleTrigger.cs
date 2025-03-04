using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicCircleTrigger : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // �J�ڐ�̃V�[����
    public float fadeDuration = 1.5f; // �t�F�[�h�C���E�A�E�g�̎���
    public Image fadePanel; // UI�̍����p�l���i���ʗ��p�j

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 1); // ������Ԃ͍��i�t�F�[�h�C���̂��߁j
            StartCoroutine(FadeIn()); // �V�[���J�n���Ƀt�F�[�h�C��
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // "Player" �^�O�̃L�����N�^�[����������
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private IEnumerator FadeIn() // ���������̃t�F�[�h�C��
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

    private IEnumerator FadeOutAndLoadScene() // ���������̃t�F�[�h�A�E�g
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName); // �V�[����ύX
    }
}
