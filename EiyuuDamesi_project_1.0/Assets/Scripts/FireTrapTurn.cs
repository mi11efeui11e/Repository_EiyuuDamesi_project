using System.Collections;
using UnityEngine;

public class ParticleToggle : MonoBehaviour
{
    public ParticleSystem particleEffect; // �p�[�e�B�N���G�t�F�N�g
    public GameObject toggleObject; // �ʏ�I�u�W�F�N�g�i�G�t�F�N�g�⃂�f���Ȃǁj
    public float onTime = 2f; // ON�̎��ԁiInspector�Œ����j
    public float offTime = 3f; // OFF�̎��ԁiInspector�Œ����j

    private void Start()
    {
        StartCoroutine(ToggleEffect());
    }

    private IEnumerator ToggleEffect()
    {
        while (true) // �������[�v
        {
            // �p�[�e�B�N�� ON
            if (particleEffect != null)
            {
                particleEffect.Play();
            }

            // �ʏ�I�u�W�F�N�g ON
            if (toggleObject != null)
            {
                toggleObject.SetActive(true);
            }

            yield return new WaitForSeconds(onTime); // ON���ԑ҂�

            // �p�[�e�B�N�� OFF
            if (particleEffect != null)
            {
                particleEffect.Stop();
            }

            // �ʏ�I�u�W�F�N�g OFF
            if (toggleObject != null)
            {
                toggleObject.SetActive(false);
            }

            yield return new WaitForSeconds(offTime); // OFF���ԑ҂�
        }
    }
}
