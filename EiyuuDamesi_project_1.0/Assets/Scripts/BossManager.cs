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

    public string nextSceneName = "NextScene"; // �J�ڐ�̃V�[����
    public float fadeDuration = 1.5f; // �t�F�[�h�C���E�A�E�g�̎���
    public Image fadePanel; // UI�̍����p�l���i���ʗ��p�j

    private void Start()
    {
        if (fadePanel != null)
        {
            fadePanel.color = new Color(0, 0, 0, 1); // ������Ԃ͍��i�t�F�[�h�C���̂��߁j
        }
    }

    void Update()
    {
        if (targetObject != null && !targetObject.activeSelf) // �I�u�W�F�N�g����\���Ȃ�
        {
            StartCoroutine(FadeOutAndLoadScene());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�̂ݔ���
        {
            PlayBossSound();
            bossHPBar.SetActive(true);
        }
    }

    public void PlayBossSound()
    {
        bossAudioSource.Play();
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
