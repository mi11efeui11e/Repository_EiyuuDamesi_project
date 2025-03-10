using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_manager : MonoBehaviour
{
    [SerializeField] Transform target;  //キャラの追尾先(Inspector編集可)
    private NavMeshAgent agent;         //追尾機能のコンポーネント対応の変数 
    private Animator animator;          //アニメーションコンポネント対応の変数
    private float speed = 0f;           //キャラの速度
    private float distance;             //オブジェクト間の距離
    public float walk_distance;         //索敵範囲
    public float attack_distance;       //攻撃範囲
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
