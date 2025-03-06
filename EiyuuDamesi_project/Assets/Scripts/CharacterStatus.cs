using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP;
    public bool isPlayer = false; // ���̃I�u�W�F�N�g������L�������ǂ���

    void Start()
    {
        // ����L�����Ȃ� `HPManager` ���� HP ���擾
        if (isPlayer && HPManager.instance != null)
        {
            currentHP = HPManager.instance.GetHP();
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
