using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_manager : MonoBehaviour
{
    [SerializeField] Transform target;  //�L�����̒ǔ���(Inspector�ҏW��)
    private NavMeshAgent agent;         //�ǔ��@�\�̃R���|�[�l���g�Ή��̕ϐ� 
    private Animator animator;          //�A�j���[�V�����R���|�l���g�Ή��̕ϐ�
    private float speed = 0f;           //�L�����̑��x
    private float distance;             //�I�u�W�F�N�g�Ԃ̋���
    public float walk_distance;         //���G�͈�
    public float attack_distance;       //�U���͈�
    bool death = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponent<Animator>();
        agent.speed = speed;
    }

    void Update()
    {
        death = animator.GetBool("Death");
        if(death == true)
        {
            animator.SetBool("move", false);
            animator.SetBool("attack", false);
        }
        else
        {
            agent.destination = target.position;
            distance = Vector3.Distance(target.position, this.transform.position);
            //Debug.Log(distance);
            if (distance < walk_distance)
            {
                if (distance <= attack_distance) {
                    speed = 0f; agent.speed = speed;
                    animator.SetBool("move", false);
                    animator.SetBool("attack", true);
                }
                if (distance >= attack_distance) {
                    speed = 2f; agent.speed = speed;
                    animator.SetBool("move", true);
                    animator.SetBool("attack", false);
                }
            }
        }
    }
}
