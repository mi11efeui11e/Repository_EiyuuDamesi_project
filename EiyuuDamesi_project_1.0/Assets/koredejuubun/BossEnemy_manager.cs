using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemy_manager : MonoBehaviour
{
    [SerializeField] Transform Player;  //キャラの追尾先(Inspector編集可)

    //咆哮に関するコード群
    [SerializeField] GameObject Scream_effect;
    [SerializeField] GameObject Scream_range;
    private static int scream_count = 0;

    //private NavMeshAgent agent;         //追尾機能のコンポーネント対応の変数 
    private Animator animator;          //アニメーションコンポネント対応の変数
    //private float speed = 0f;           //キャラの速度
    private float distance;             //オブジェクト間の距離
    public float seach_range;           //索敵範囲  
    //public float attack_distance;       //攻撃範囲
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
