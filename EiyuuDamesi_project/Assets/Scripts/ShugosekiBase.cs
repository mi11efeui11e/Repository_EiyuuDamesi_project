using UnityEngine;

public class ShugosekiBase : CharacterBase
{
    public GameObject shugoseki;

    public override void OnHit()
    {

    }

    public override void OnDeath()
    {
        //Debug.Log("�G���|�ꂽ�I�G�t�F�N�g�Đ� & �X�R�A���Z");
        // �����G�t�F�N�g���o��
        // �X�R�A�����Z
        GetComponent<DissolveEffect>().StartDissolve();
    }
}