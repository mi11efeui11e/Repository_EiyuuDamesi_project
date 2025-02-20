using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    

    // �L�����N�^�[�̊�{�ݒ�
    public float walkSpeed = 5f;  // �ʏ�̈ړ����x
    public float dashSpeed = 10f; // �_�b�V�����̈ړ����x
    public float jumpHeight = 2f; // �W�����v�̍���
    public float gravity = -9.81f; // �d��
    public float rotationSpeed = 10f; // �L�����N�^�[�̉�]���x
    public Animator animator; // Animator�R���|�[�l���g

    // �J����
    public Transform cameraTransform;

    // �����ϐ�
    private CharacterController characterController;
    private Vector3 velocity; // ���������̑��x�i�d�́A�W�����v�Ȃǁj
    private bool isGrounded;  // �n�ʂɂ��Ă��邩����
    private bool hitFlag = false; //1�C3�i�K�ڂ̍U���őO�ɓ��ݏo�����߂̃t���O


    // Start is called before the first frame update
    void Start()
    {
        // CharacterController���擾
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // �n�ʂɂ��Ă��邩�m�F
        isGrounded = characterController.isGrounded;

        // �n�ʂɂ��Ă���ꍇ�͐������x�����Z�b�g
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // �������̒l�ɂ��邱�ƂŐڒn�����肳����
        }

        int motion = animator.GetInteger("Motion");//�p�����[�^�擾�ϐ�
        //idle == 0, walk == 1, run == 2, jump == 3, fall == 4, attack1 == 5, attack2 == 6, attack3 == 7,Roll == 8

        if(Input.GetMouseButtonDown(0) && isGrounded && motion != 8 && motion != 5) //�U�����̓��������A����シ���ɕ�����ύX�\�ɂ���
        {
            if(motion != 6 && motion != 7) //�U���̏��i�����A�����Ɍ�����ς�����悤�ɂ���B
            {
                // ���͎擾�iWASD�j
                float horizontal = Input.GetAxis("Horizontal"); // A, D�L�[�i�܂��͖��L�[���E�j
                float vertical = Input.GetAxis("Vertical");     // W, S�L�[�i�܂��͖��L�[�㉺�j

                // �J�����̕�������Ɉړ��������v�Z�iY���𖳎����Đ����ʏ�̕����̂ݎ擾�j
                Vector3 cameraForward = cameraTransform.forward;
                cameraForward.y = 0; // Y���̉e���𖳎�
                cameraForward.Normalize(); // ���K��

                Vector3 cameraRight = cameraTransform.right;
                cameraRight.y = 0; // Y���̉e���𖳎�
                cameraRight.Normalize(); // ���K��

                Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

                if (move.magnitude > 0.1f)
                {
                    // �L�����N�^�[���ړ������Ɍ�����
                    transform.rotation = Quaternion.LookRotation(move);
                }

            }
        }

        //�������
        if (Input.GetMouseButtonDown(1) && isGrounded && motion != 5 && motion != 6 && motion != 7 && motion != 8) //�n�ォ�U���ȊO�̎��Amotion8���͑O�Ɉ�蓮��
        {
            
                // ���͎擾�iWASD�j
                float horizontal = Input.GetAxis("Horizontal"); // A, D�L�[�i�܂��͖��L�[���E�j
                float vertical = Input.GetAxis("Vertical");     // W, S�L�[�i�܂��͖��L�[�㉺�j

                // �J�����̕�������Ɉړ��������v�Z�iY���𖳎����Đ����ʏ�̕����̂ݎ擾�j
                Vector3 cameraForward = cameraTransform.forward;
                cameraForward.y = 0; // Y���̉e���𖳎�
                cameraForward.Normalize(); // ���K��

                Vector3 cameraRight = cameraTransform.right;
                cameraRight.y = 0; // Y���̉e���𖳎�
                cameraRight.Normalize(); // ���K��

                Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

                if (move.magnitude > 0.1f)
                {
                    // �L�����N�^�[���ړ������Ɍ�����
                    transform.rotation = Quaternion.LookRotation(move);
                }
        }

        //�U���A��𒆂�WASD�ړ��͖���������B
        if (motion != 5 && motion != 6 && motion != 7 && motion != 8) 
        {
            MoveCharacter();  // �ړ�����

            // �W�����v����
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // �W�����v���x�v�Z
            }
        }

        // ��𒆂ƍU�����̑O�i����(���x�̓_�b�V���Ɠ���)
        if (motion == 8 || hitFlag == true)
        {
            RollForward();

        }

        // �d�͂�K�p
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        
    }

    void MoveCharacter()
    {
        // ���͎擾�iWASD�j
        float horizontal = Input.GetAxis("Horizontal"); // A, D�L�[�i�܂��͖��L�[���E�j
        float vertical = Input.GetAxis("Vertical");     // W, S�L�[�i�܂��͖��L�[�㉺�j

        // �J�����̕�������Ɉړ��������v�Z�iY���𖳎����Đ����ʏ�̕����̂ݎ擾�j
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // Y���̉e���𖳎�
        cameraForward.Normalize(); // ���K��

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0; // Y���̉e���𖳎�
        cameraRight.Normalize(); // ���K��

        Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

        // �V�t�g�L�[�Ń_�b�V��
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? dashSpeed : walkSpeed;

        // �L�����N�^�[���ړ�
        characterController.Move(move * currentSpeed * Time.deltaTime);



        // �L�����N�^�[���ړ����������������iY����]�̂݁j
        if (move.magnitude > 0.1f) // �ړ����͂�����ꍇ�̂݉�]
        {
            // Y�������݂̂��g�p���ĖڕW��]���v�Z
            Quaternion targetRotation = Quaternion.LookRotation(move);

            // ���݂̉�]����ڕW��]�փX���[�Y�ɕ��
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }

    private void RollForward() //��𒆂Ɉړ��������郁�\�b�h
    {
        // �L�����N�^�[�̑O�������Ɉړ��x�N�g�����v�Z
        Vector3 forwardMovement = transform.forward * dashSpeed * Time.deltaTime;

        // CharacterController��ʂ��Ĉړ�
        characterController.Move(forwardMovement);
    }

    public void Attack1Start() //��i�ڑO�i�J�n�̃C�x���g���\�b�h
    {
        hitFlag = true;
    }

    public void Attack3Start() //3�i�ڑO�i�J�n�̃C�x���g���\�b�h
    {
        hitFlag = true;
    }

    public void HitMove1()�@//�U����i�K�ڂ̑O�i���~�߂�^�C�~���O�̃C�x���g���\�b�h
    {
        hitFlag = false;
    }

    public void HitMove3()�@//�U��3�i�K�ڂ̑O�i���~�߂�^�C�~���O�̃C�x���g���\�b�h
    {
        hitFlag = false;
    }

}
