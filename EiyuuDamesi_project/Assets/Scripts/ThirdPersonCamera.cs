using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // �Ǐ]�Ώہi�L�����N�^�[�j
    public Transform target;

    // �J�����ݒ�
    public float distance = 5f;          // �J�����̋���
    public float height = 2f;           // �J�����̍����i�ڐ��ʒu�j
    public float rotationSpeed = 5f;    // �J�����̉�]���x�i�}�E�X���x�j

    // �c�����̉�]�p�x����
    public float verticalMinAngle = -20f; // �J���������������ŏ��p�x
    public float verticalMaxAngle = 60f;  // �J��������������ő�p�x

    // �Փˏ����ݒ�
    public LayerMask collisionLayers;   // �J�������Փ˂��`�F�b�N���郌�C���[�i�ǂ⏰�Ȃǁj
    public float collisionOffset = 0.2f; // �ǂ⏰�Ƃ̍ŏ�����
    public float cameraSmoothSpeed = 10f; // �J�������X���[�Y�Ɉړ����鑬�x

    // �����ϐ�
    private float currentYaw = 0f;       // ���������̉�]�p�x
    private float currentPitch = 0f;     // ���������̉�]�p�x
    private Vector3 currentCameraPosition; // �J�����̌��݂̈ʒu

    void Start()
    {
        // �J�����̏����ʒu��ݒ�
        currentCameraPosition = transform.position;

        // �����̃J�����̌����i�L�����N�^�[�ɒǏ]�j
        currentYaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!target) return; // �^�[�Q�b�g�����ݒ�̏ꍇ�͉������Ȃ�

        // �}�E�X���͂��擾
        float horizontalInput = Input.GetAxis("Mouse X"); // �}�E�XX���̓��́i���������j
        float verticalInput = Input.GetAxis("Mouse Y");   // �}�E�XY���̓��́i���������j

        // ���������̉�]���X�V
        currentYaw += horizontalInput * rotationSpeed;

        // ���������̉�]���X�V���A�p�x������K�p
        currentPitch -= verticalInput * rotationSpeed; // �}�E�XY�͋t�����ɓK�p
        currentPitch = Mathf.Clamp(currentPitch, verticalMinAngle, verticalMaxAngle);

        // �J�����̖ڕW��]���v�Z
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        // �Փˏ�����K�p�����J�����̖ڕW�ʒu���v�Z
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;
        desiredPosition = HandleCollision(target.position, desiredPosition);

        // �J�����̈ʒu���X���[�Y�ɍX�V
        currentCameraPosition = Vector3.Lerp(currentCameraPosition, desiredPosition, Time.deltaTime * cameraSmoothSpeed);
        transform.position = currentCameraPosition;

        // �^�[�Q�b�g�𒍎�
        transform.LookAt(target.position + Vector3.up * height);
    }

    // �J�����̏Փˏ���
    private Vector3 HandleCollision(Vector3 targetPosition, Vector3 desiredCameraPosition)
    {
        // �^�[�Q�b�g�ƃJ�����̊Ԃɏ�Q�������邩�`�F�b�N
        RaycastHit hit;
        if (Physics.Linecast(targetPosition + Vector3.up * height, desiredCameraPosition, out hit, collisionLayers))
        {
            // �Փ˂����ꍇ�A�J�����̈ʒu���Փ˓_�̏�����O�ɒ���
            return hit.point + hit.normal * collisionOffset;
        }

        // �Փ˂��Ȃ��ꍇ�A�ڕW�ʒu�����̂܂ܕԂ�
        return desiredCameraPosition;
    }
}
