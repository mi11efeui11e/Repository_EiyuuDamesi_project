using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimetionController : MonoBehaviour
{
    private CharacterController characterController; //isGroundの為に使用
    private bool isGrounded;  // 地面についているか判定
    public Animator animator; // Animatorコンポーネント
    private int combo = 1; //攻撃判定調整用変数、コンボの一つとびを防ぐ。
    private int nextAttack = 1; //endイベントでアニメーションパラメータを動かすための変数。

    public GameObject hurtBox; //無敵時間のために消すコライダー

    //アニメーションパラメータ Motion　下の行が各値
    //idle == 0, walk == 1, run == 2, jump == 3, fall == 4, attack1 == 5, attack2 == 6, attack3 == 7,roll == 8, die == 9;

    //ジャンプが終わった時のイベント
    public void JumpEnd()
    {
        animator.SetInteger("Motion",0);
    }


    public void Attack1End() //一段目の終わりのイベント、ここでモーションパラメータを変える。
    {
        int motion = animator.GetInteger("Motion");//パラメータ取得変数

        combo = 2;

        if (nextAttack ==2) //nextAttackが2ならパラメータを6に変更。
        {
            animator.SetInteger("Motion", 6);
        }

        if (nextAttack == 1)　//１のままならidleに戻る。
        {
            animator.SetInteger("Motion", 0);
            combo = 1;
        }
    }

    public void Attack2End()
    {
        int motion = animator.GetInteger("Motion");//パラメータ取得変数

        if(nextAttack == 3)　//nextAttackが3ならパラメータを7に変更。
        {
            animator.SetInteger("Motion", 7);
        }

        if (nextAttack == 2)　//2のままならidleに戻る。
        {
            combo = 1;
            nextAttack = 1;
            animator.SetInteger("Motion", 0);
        }
    }

    public void Attack3End()　//最終段で攻撃のコンボに関する変数を初期化。
    {
            animator.SetInteger("Motion", 0);
        combo = 1;
        nextAttack = 1;
    }

    public void RollStart()　//回避開始イベントで無敵開始。コライダーを消去。
    {
        hurtBox.SetActive(false);
    }

    public void RollEnd()　//回避終了イベントでパラメータを0に戻す。無敵終了でコライダーを戻す。
    {
        animator.SetInteger("Motion", 0);
        hurtBox.SetActive(true);
    }

    public void EndKnockback()　//ノックバック終了イベントでパラメータを0に戻す。また数秒後までhurtBoxを無効化。
    {
        animator.SetInteger("Motion", 0);
        Invoke("HurtBoxOn", 1f);
        
    }

    public void HurtBoxOn() //ノックバック後１秒間無敵時間、上のincokeのための関数
    {
        hurtBox.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        // CharacterControllerを取得
        characterController = GetComponent<CharacterController>();

        animator.SetInteger("Motion", 0);//初期状態はidle
    }

    // Update is called once per frame
    void Update()
    {
        int motion = animator.GetInteger("Motion");//パラメータ取得変数

        isGrounded = characterController.isGrounded;//着地判定

        if (motion != 9 && motion != 10)
        {

            if (Input.GetMouseButtonDown(1) && isGrounded && (motion != 5 && motion != 6 && motion != 7)) //回避
            {
                animator.SetInteger("Motion", 8);
            }

            //攻撃に関する条件分岐（コンボ可能）
            if (Input.GetMouseButtonDown(0) && isGrounded && (motion != 5 && motion != 6 && motion != 7) && motion != 8) //地上かつ右クリックかつコンボ中じゃなければ一段目に以降
            {
                animator.SetInteger("Motion", 5);

            }
            else if (motion == 5 && Input.GetMouseButtonDown(0)) //一段目の途中かつ左クリックで2段目
            {
                nextAttack = 2;
            }
            else if (combo == 2 && motion == 6 && Input.GetMouseButtonDown(0)) //2段目の途中かつ左クリックで3段目
            {
                nextAttack = 3;
            }

            motion = animator.GetInteger("Motion");//パラメータ取得変数

            if (motion != 5 && motion != 6 && motion != 7 && motion != 8) //攻撃のコンボ受付中は他の動作はできない
            {
                if (Input.GetKeyDown(KeyCode.Space) && motion != 3 && motion != 4) //着地中かつスペースキーでジャンプ
                {
                    animator.SetInteger("Motion", 3);
                }
                else if (isGrounded != true && motion != 3)   //空中かつジャンプ時以外で落下モーション
                {
                    animator.SetInteger("Motion", 4);
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded && Input.GetKey(KeyCode.LeftShift))  //ダッシュ判定
                {
                    animator.SetInteger("Motion", 2);
                }
                else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && isGrounded) //歩き判定
                {
                    animator.SetInteger("Motion", 1);
                }
                else if (isGrounded) //idle判定
                {
                    animator.SetInteger("Motion", 0);
                }
            }

        }

    }
}
