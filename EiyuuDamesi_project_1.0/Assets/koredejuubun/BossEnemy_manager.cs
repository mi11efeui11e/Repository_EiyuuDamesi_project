using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy_manager : MonoBehaviour
{
    [SerializeField] Transform Player;  //�L�����̒ǔ���(Inspector�ҏW��)

    //���K�Ɋւ���R�[�h�Q
    [SerializeField] GameObject Scream_effect;
    [SerializeField] GameObject Scream_range;
    private static int scream_count = 0;

    //private NavMeshAgent agent;         //�ǔ��@�\�̃R���|�[�l���g�Ή��̕ϐ� 
    private Animator animator;          //�A�j���[�V�����R���|�l���g�Ή��̕ϐ�
    //private float speed = 0f;           //�L�����̑��x
    private float distance;             //�I�u�W�F�N�g�Ԃ̋���
    public float seach_range;           //���G�͈�  
    //public float attack_distance;       //�U���͈�
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //agent.speed = speed;
    }

    void Update()
    {
        //agent.destination = Player.position;
        distance = Vector3.Distance(Player.position, this.transform.position);
        //Debug.Log(distance);
        if (distance < seach_range)
        {
            if (scream_count == 0){
                Scream();
            }
        }
    }

    private void Scream()
    {
        animator.SetTrigger("Scream");
        Scream_effect.SetActive(true);
        ScreamDelay(0.8f);
        scream_count++;
    }
    public void ScreamDelay(float time)
    {
        Invoke("Scream_Knockbackon", time);
        Invoke("Scream_Knockbackoff", time+2.0f);
    }
    void Scream_Knockbackon()
    {
        Scream_range.SetActive(true);
    }
    void Scream_Knockbackoff()
    {
        Scream_range.SetActive(false);
    }
}
