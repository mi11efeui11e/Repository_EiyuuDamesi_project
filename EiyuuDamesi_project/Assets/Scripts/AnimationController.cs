using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionController : MonoBehaviour
{
    private CharacterController characterController; //isGround�ׂ̈Ɏg�p
    private bool isGrounded;  // �n�ʂɂ��Ă��邩����
    public Animator animator; // Animator�R���|�[�l���g
    private int combo = 1; //�U�����蒲���p�ϐ��A�R���{�̈�Ƃт�h���B
    private int nextAttack = 1; //end�C�x���g�ŃA�j���[�V�����p�����[�^�𓮂������߂̕ϐ��B

    public GameObject hurtBox; //���G���Ԃ̂��߂ɏ����R���C�_�[

    //�A�j���[�V�����p�����[�^ Motion�@���̍s���e�l
    //idle == 0, walk == 1, run == 2, jump == 3, fall == 4, attack1 == 5, attack2 == 6, attack3 == 7,roll == 8, die == 9;

    //�W�����v���I��������̃C�x���g
    public void JumpEnd()
    {
        animator.SetInteger("Motion",0);
    }


    public void Attack1End() //��i�ڂ̏I���̃C�x���g�A�����Ń��[�V�����p�����[�^��ς���B
    {
        int motion = animator.GetInteger("Motion");//�p�����[�^�擾�ϐ�

        combo = 2;

        if (nextAttack ==2) //nextAttack��2�Ȃ�p�����[�^��6�ɕύX�B
        {
            animator.SetInteger("Motion", 6);
        }

        if (nextAttack == 1)�@//�P�̂܂܂Ȃ�idle�ɖ߂�B
        {
            animator.SetInteger("Motion", 0);
            combo = 1;
        }
    }

    public void Attack2End()
    {
        int motion = animator.GetInteger("Motion");//�p�����[�^�擾�ϐ�

        if(nextAttack == 3)�@//nextAttack��3�Ȃ�p�����[�^��7�ɕύX�B
        {
            animator.SetInteger("Motion", 7);
        }

        if (nextAttack == 2)�@//2�̂܂܂Ȃ�idle�ɖ߂�B
        {
            combo = 1;
            nextAttack = 1;
            animator.SetInteger("Motion", 0);
        }
    }

    public void Attack3End()�@//�ŏI�i�ōU���̃R���{�Ɋւ���ϐ����������B
    {
            animator.SetInteger("Motion", 0);
        combo = 1;
        nextAttack = 1;
    }

    public void RollStart()�@//����J�n�C�x���g�Ŗ��G�J�n�B�R���C�_�[�������B
    {
        hurtBox.SetActive(false);
    }

    public void RollEnd()�@//����I���C�x���g�Ńp�����[�^��0�ɖ߂��B���G�I���ŃR���C�_�[��߂��B
    {
        animator.SetInteger("Motion", 0);
        hurtBox.SetActive(true);
    }

    public void EndKnockback()�@//�m�b�N�o�b�N�I���C�x���g�Ńp�����[�^��0�ɖ߂��B�܂����b��܂�hurtBox�𖳌����B
    {
        animator.SetInteger("Motion", 0);
        Invoke("HurtBoxOn", 1f);
        
    }

    public void HurtBoxOn() //�m�b�N�o�b�N��P�b�Ԗ��G���ԁA���incoke�̂��߂̊֐�
    {
        hurtBox.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // CharacterController���擾
        characterController = GetComponent<CharacterController>();

        animator.SetInteger("Motion", 0);//������Ԃ�idle
    }

    // Update is called once per frame
    void Update()
    {
        int motion = animator.GetInteger("Motion");//�p�����[�^�擾�ϐ�

        isGrounded = characterController.isGrounded;//���n����

        if (motion != 9 && motion != 10)
        {

            if (Input.GetMouseButtonDown(1) && isGrounded && (motion != 5 && motion != 6 && motion != 7)) //���
            {
                animator.SetInteger("Motion", 8);
            }

            //�U���Ɋւ����������i�R���{�\�j
            if (Input.GetMouseButtonDown(0) && isGrounded && (motion != 5 && motion != 6 && motion != 7) && motion != 8) //�n�ォ�E�N���b�N���R���{������Ȃ���Έ�i�ڂɈȍ~
            {
                animator.SetInteger("Motion", 5);

            }
            else if (motion == 5 && Input.GetMouseButtonDown(0)) //��i�ڂ̓r�������N���b�N��2�i��
            {
                nextAttack = 2;
            }
            else if (combo == 2 && motion == 6 && Input.GetMouseButtonDown(0)) //2�i�ڂ̓r�������N���b�N��3�i��
            {
                nextAttack = 3;
            }

            motion = animator.GetInteger("Motion");//�p�����[�^�擾�ϐ�

            if (motion != 5 && motion != 6 && motion != 7 && motion != 8) //�U���̃R���{��t���͑��̓���͂ł��Ȃ�
            {
                if (Input.GetKeyDown(KeyCode.Space) && motion != 3 && motion != 4) //���n�����X�y�[�X�L�[�ŃW�����v
                {
                    animator.SetInteger("Motion", 3);
                }
                else if (isGrounded != true && motion != 3)   //�󒆂��W�����v���ȊO�ŗ������[�V����
                {
                    animator.SetInteger("Motion", 4);
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded && Input.GetKey(KeyCode.LeftShift))  //�_�b�V������
                {
                    animator.SetInteger("Motion", 2);
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded) //��������
                {
                    animator.SetInteger("Motion", 1);
                }
                else if (isGrounded) //idle����
                {
                    animator.SetInteger("Motion", 0);
                }
            }

        }

    }
}
