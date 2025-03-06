using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HumanBase : CharacterBase
{
    
    public Animator animator; // Animator�R���|�[�l���g
    public GameObject hurtBox; //�L�����N�^�[�̓����蔻����ꎞ�I�ɖ������Ė��G���Ԃ����B

    public Image damageImage; // �_���[�W�G�t�F�N�g�p�� Image
    public float fadeSpeed = 2f; // �t�F�[�h�A�E�g���x
    public float maxAlpha = 0.5f; // �ő�̓����x�i1.0 = ���S�ɕs�����j

    public string nextSceneName = "NextScene"; // �J�ڐ�̃V�[����
    public float fadeDuration = 1.5f; // �t�F�[�h�C���E�A�E�g�̎���
    public Image fadePanel; // UI�̍����p�l���i���ʗ��p�j


    private void Start()
    {
        if(DeathManager.instance.deathCheck == 1) //�����O�V�[���Ŏ��S���Ă�����̗͂������p�����ɉ�
        {
            HPManager.instance.ResetHP();
        }

        if (damageImage != null)
        {
            Color c = damageImage.color;
            c.a = 0f; // �ŏ��͓���
            damageImage.color = c;
        }
    }

    public override void OnHit()
    {
        animator.SetInteger("Motion", 10);

        hurtBox.SetActive(false);
        ShowDamageEffect(); //��e����ʂ�Ԃ��_�Łi�S�Q�s�ڂ���L�q�j
    }

    public override void OnDeath()
    {
        Debug.Log("�������|�ꂽ�I�G�t�F�N�g�Đ� & �X�R�A���Z");
        animator.SetInteger("Motion", 9);
        Invoke("StartFadeOutDeath", 2f);
        DeathManager.instance.deathCheck = 1;
    }


    public void ShowDamageEffect()
    {
        StartCoroutine(DamageFlash());
    }

    private IEnumerator DamageFlash()
    {
        // ��ʂ�Ԃ�����
        float elapsedTime = 0f;
        while (elapsedTime < 0.1f) // 0.1�b�����ăt�F�[�h�C��
        {
            elapsedTime += Time.deltaTime;
            Color c = damageImage.color;
            c.a = Mathf.Lerp(0, maxAlpha, elapsedTime / 0.1f);
            damageImage.color = c;
            yield return null;
        }

        // �����Ƀt�F�[�h�A�E�g
        elapsedTime = 0f;
        while (elapsedTime < 0.5f) // 0.5�b�����ăt�F�[�h�A�E�g
        {
            elapsedTime += Time.deltaTime;
            Color c = damageImage.color;
            c.a = Mathf.Lerp(maxAlpha, 0, elapsedTime / 0.5f);
            damageImage.color = c;
            yield return null;
        }
    }

    private void StartFadeOutDeath()
    {
        StartCoroutine(FadeOutDeath()); // �R���[�`�������s
    }

    private IEnumerator FadeOutDeath() // ���S�����������̃t�F�[�h�A�E�g
    {
        Debug.Log("���S���t�F�[�h�����J�n");
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