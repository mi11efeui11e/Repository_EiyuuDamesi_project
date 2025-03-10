using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���Ǘ��ɕK�v

public class SceneChangeOnDisable : MonoBehaviour
{
    public GameObject targetObject; // �Ď�����I�u�W�F�N�g
    public string nextSceneName = "NextScene"; // �ړ���̃V�[����

    void Update()
    {
        if (targetObject != null && !targetObject.activeSelf) // �I�u�W�F�N�g����\���Ȃ�
        {
            SceneManager.LoadScene(nextSceneName); // ���̃V�[���Ɉړ�
        }
    }
}
