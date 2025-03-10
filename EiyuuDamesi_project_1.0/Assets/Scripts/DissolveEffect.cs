using UnityEngine;
using System.Collections;

public class DissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;  // Dissolve �p�}�e���A��
    public float dissolveSpeed = 1.0f; // ���ő��x

    private float dissolveAmount = 0f;
    private bool isDissolving = false;

    void Start()
    {
        if (dissolveMaterial == null)
        {
            dissolveMaterial = GetComponent<Renderer>().material;  // �I�u�W�F�N�g�̃}�e���A�����擾
        }

        dissolveMaterial.SetFloat("_Cutoff", 0f);  // �V�F�[�_�[�� Dissolve �p�����[�^��������

    }

    public void StartDissolve()
    {
        if (!isDissolving)
        {
            StartCoroutine(DissolveAndDestroy());
        }
    }

    private IEnumerator DissolveAndDestroy()
    {
        isDissolving = true;

        while (dissolveAmount < 1.0f)
        {
            dissolveAmount += Time.deltaTime * dissolveSpeed;
            dissolveMaterial.SetFloat("_Cutoff", dissolveAmount);  // �V�F�[�_�[�� Dissolve �p�����[�^���X�V
            yield return null;
        }

        Destroy(gameObject); // ���S�ɏ�������폜
    }
}
