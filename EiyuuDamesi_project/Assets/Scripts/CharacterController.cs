using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    

    // キャラクターの基本設定
    public float walkSpeed = 5f;  // 通常の移動速度
    public float dashSpeed = 10f; // ダッシュ時の移動速度
    public float jumpHeight = 2f; // ジャンプの高さ
    public float gravity = -9.81f; // 重力
    public float rotationSpeed = 10f; // キャラクターの回転速度
    public Animator animator; // Animatorコンポーネント

    // カメラ
    public Transform cameraTransform;

    // 内部変数
    private CharacterController characterController;
    private Vector3 velocity; // 垂直方向の速度（重力、ジャンプなど）
    private bool isGrounded;  // 地面についているか判定
    private bool hitFlag = false; //1，3段階目の攻撃で前に踏み出すためのフラグ


    // Start is called before the first frame update
    void Start()
    {
        // CharacterControllerを取得
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // 地面についているか確認
        isGrounded = characterController.isGrounded;

        // 地面についている場合は垂直速度をリセット
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // 少し負の値にすることで接地を安定させる
        }

        int motion = animator.GetInteger("Motion");//パラメータ取得変数
        //idle == 0, walk == 1, run == 2, jump == 3, fall == 4, attack1 == 5, attack2 == 6, attack3 == 7,Roll == 8

        if(Input.GetMouseButtonDown(0) && isGrounded && motion != 8 && motion != 5) //攻撃中の動き処理、回避後すぐに方向を変更可能にする
        {
            if(motion != 6 && motion != 7) //攻撃の初段だけ、即座に向きを変えられるようにする。
            {
                // 入力取得（WASD）
                float horizontal = Input.GetAxis("Horizontal"); // A, Dキー（または矢印キー左右）
                float vertical = Input.GetAxis("Vertical");     // W, Sキー（または矢印キー上下）

                // カメラの方向を基準に移動方向を計算（Y軸を無視して水平面上の方向のみ取得）
                Vector3 cameraForward = cameraTransform.forward;
                cameraForward.y = 0; // Y軸の影響を無視
                cameraForward.Normalize(); // 正規化

                Vector3 cameraRight = cameraTransform.right;
                cameraRight.y = 0; // Y軸の影響を無視
                cameraRight.Normalize(); // 正規化

                Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

                if (move.magnitude > 0.1f)
                {
                    // キャラクターを移動方向に向ける
                    transform.rotation = Quaternion.LookRotation(move);
                }

            }
        }

        //回避処理
        if (Input.GetMouseButtonDown(1) && isGrounded && motion != 5 && motion != 6 && motion != 7 && motion != 8) //地上かつ攻撃以外の時、motion8中は前に一定動く
        {
            
                // 入力取得（WASD）
                float horizontal = Input.GetAxis("Horizontal"); // A, Dキー（または矢印キー左右）
                float vertical = Input.GetAxis("Vertical");     // W, Sキー（または矢印キー上下）

                // カメラの方向を基準に移動方向を計算（Y軸を無視して水平面上の方向のみ取得）
                Vector3 cameraForward = cameraTransform.forward;
                cameraForward.y = 0; // Y軸の影響を無視
                cameraForward.Normalize(); // 正規化

                Vector3 cameraRight = cameraTransform.right;
                cameraRight.y = 0; // Y軸の影響を無視
                cameraRight.Normalize(); // 正規化

                Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

                if (move.magnitude > 0.1f)
                {
                    // キャラクターを移動方向に向ける
                    transform.rotation = Quaternion.LookRotation(move);
                }
        }

        //攻撃、回避中はWASD移動は無効化する。
        if (motion != 5 && motion != 6 && motion != 7 && motion != 8) 
        {
            MoveCharacter();  // 移動処理

            // ジャンプ処理
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // ジャンプ速度計算
            }
        }

        // 回避中と攻撃中の前進処理(速度はダッシュと同じ)
        if (motion == 8 || hitFlag == true)
        {
            RollForward();

        }

        // 重力を適用
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        
    }

    void MoveCharacter()
    {
        // 入力取得（WASD）
        float horizontal = Input.GetAxis("Horizontal"); // A, Dキー（または矢印キー左右）
        float vertical = Input.GetAxis("Vertical");     // W, Sキー（または矢印キー上下）

        // カメラの方向を基準に移動方向を計算（Y軸を無視して水平面上の方向のみ取得）
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // Y軸の影響を無視
        cameraForward.Normalize(); // 正規化

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0; // Y軸の影響を無視
        cameraRight.Normalize(); // 正規化

        Vector3 move = (cameraForward * vertical + cameraRight * horizontal).normalized;

        // シフトキーでダッシュ
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? dashSpeed : walkSpeed;

        // キャラクターを移動
        characterController.Move(move * currentSpeed * Time.deltaTime);



        // キャラクターが移動方向を向く処理（Y軸回転のみ）
        if (move.magnitude > 0.1f) // 移動入力がある場合のみ回転
        {
            // Y軸方向のみを使用して目標回転を計算
            Quaternion targetRotation = Quaternion.LookRotation(move);

            // 現在の回転から目標回転へスムーズに補間
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

    }

    private void RollForward() //回避中に移動し続けるメソッド
    {
        // キャラクターの前方方向に移動ベクトルを計算
        Vector3 forwardMovement = transform.forward * dashSpeed * Time.deltaTime;

        // CharacterControllerを通して移動
        characterController.Move(forwardMovement);
    }

    public void Attack1Start() //一段目前進開始のイベントメソッド
    {
        hitFlag = true;
    }

    public void Attack3Start() //3段目前進開始のイベントメソッド
    {
        hitFlag = true;
    }

    public void HitMove1()　//攻撃一段階目の前進を止めるタイミングのイベントメソッド
    {
        hitFlag = false;
    }

    public void HitMove3()　//攻撃3段階目の前進を止めるタイミングのイベントメソッド
    {
        hitFlag = false;
    }

}
