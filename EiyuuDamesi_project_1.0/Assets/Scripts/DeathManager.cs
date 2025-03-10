using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager instance; // �V���O���g��
    public int deathCheck; //�O�V�[���Ŏ��S���Ă��邩�̔���ϐ��@0�����Ă��Ȃ��@1�����S����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��폜����Ȃ�
            deathCheck = 0; // �����͎��S����0�i�O�V�[���Ŏ��S���Ă��Ȃ��Ƃ������Ɓj
        }
        else
        {
            Destroy(gameObject); // �d����h��
        }
    }

}
