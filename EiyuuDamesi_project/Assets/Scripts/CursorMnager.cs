using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        // �}�E�X�J�[�\�����\���ɂ��ă��b�N
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // ESC�L�[�ŃJ�[�\�����ĕ\�����ĉ����i�J������f�o�b�O�p�j
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // �Ăу}�E�X�����b�N�i�Q�[���v���C���ɍĐݒ肷���j
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}

