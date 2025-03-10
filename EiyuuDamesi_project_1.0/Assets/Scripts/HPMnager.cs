using UnityEngine;

public class HPManager : MonoBehaviour
{
    public static HPManager instance; // �V���O���g��
    public float currentHP;
    public float maxHP = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����܂����ł��폜����Ȃ�
            currentHP = maxHP; // ����HP�ݒ�
        }
        else
        {
            Destroy(gameObject); // �d����h��
        }
    }

    public void SetHP(float hp)
    {
        currentHP = hp;
    }

    public float GetHP()
    {
        return currentHP;
    }

    // **���S���� HP ���񕜂��郁�\�b�h**
    public void ResetHP()
    {
        Debug.Log("HP���Z�b�g");
        currentHP = maxHP;
        Debug.Log($"���Z�b�g���HP: {currentHP}");
        DeathManager.instance.deathCheck = 0; //�񕜂��������ƑO�V�[���ł̎��S����𖳂����B
    }
}
