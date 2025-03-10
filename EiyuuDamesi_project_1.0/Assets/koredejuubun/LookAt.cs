using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public float rotationSpeed = 2f;  // ��]���x

    void Update()
    {
        if (player == null) return;

        // �v���C���[�̕������������߂̃^�[�Q�b�g��]
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);

        // �X���[�Y�ɉ�]�iSlerp�ŕ�ԁj
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
