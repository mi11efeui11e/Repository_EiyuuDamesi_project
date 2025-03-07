using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public bool isPlayer = false; // ���̃I�u�W�F�N�g������L�������ǂ���

    void Start()
    {

        if (DeathManager.instance.deathCheck == 1) //�����O�V�[���Ŏ��S���Ă�����̗͂������p�����ɉ�
        {
            Debug.Log($"�V�[���J�n���X�e�[�^�X��");
            currentHP = maxHP;
            Debug.Log($"�X�e�[�^�X���Z�b�g���HP: {currentHP}");
        }

        // ����L�����Ȃ� `HPManager` ���� HP ���擾
        if (isPlayer && HPManager.instance != null)
        {
            currentHP = HPManager.instance.GetHP();
            Debug.Log($"���Z�b�g���M����擾��HP: {currentHP}");
        }
        else
        {
            currentHP = maxHP; // �ʏ�̓G�L�����E�I�u�W�F�N�g�� maxHP �ŏ�����
        }
    }

    void Update()
    {
        // ����L�����Ȃ� `HPManager` �ɓ���
        if (isPlayer && HPManager.instance != null)
        {
            HPManager.instance.SetHP(currentHP);
        }
    }
}
