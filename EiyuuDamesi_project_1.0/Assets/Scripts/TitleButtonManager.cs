using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtonManager : MonoBehaviour
{
    public Button sceneChangeButton; // �V�[���ڍs�{�^��
    public Button otherButton; // ����{�^��
    public Button backButton; //how ����^�C�g���֖߂�{�^��

    public GameObject titleCanvas;
    public GameObject howCanvas;

    public string targetSceneName = "GameScene"; // �J�ڐ�̃V�[�����iInspector �Őݒ�j

    public Image fadeImage; // �t�F�[�h�A�E�g�p�� Image
    public float fadeDuration = 1.5f; // �t�F�[�h�̎���

    public AudioSource buttonAudioSource;

    

    private void Start()
    {
        // �V�[���ڍs�{�^���̃N���b�N�C�x���g
        if (sceneChangeButton != null)
        {
            sceneChangeButton.onClick.AddListener(() => StartCoroutine(FadeOutAndChangeScene()));
        }

        // �܂����܂��Ă��Ȃ��{�^���̏����i���j
        if (otherButton != null)
        {
            otherButton.onClick.AddListener(UnassignedAction);
        }

        // �t�F�[�h�p�̉摜�𓧖���
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true); // Image ���A�N�e�B�u�ɂ���
            fadeImage.color = new Color(0, 0, 0, 0); // ���S�ɓ����ɂ���
        }
    }

    // �t�F�[�h�A�E�g���Ȃ���V�[����ύX����
    private IEnumerator FadeOutAndChangeScene()
    {
        if (fadeImage != null)
        {
            float elapsedTime = 0f;
            Color fadeColor = fadeImage.color;

            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                fadeColor.a = Mathf.Clamp01(elapsedTime / fadeDuration); // �A���t�@�l�𑝉�
                fadeImage.color = fadeColor;
                yield return null;
            }
        }

        // �t�F�[�h�A�E�g���I�������V�[���J��
        SceneManager.LoadScene(targetSceneName);
    }

    // ����̃{�^���̏����i��ŕύX�j
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
