using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    // 追従対象（キャラクター）
    public Transform target;

    // カメラ設定
    public float distance = 5f;          // カメラの距離
    public float height = 2f;           // カメラの高さ（目線位置）
    public float rotationSpeed = 5f;    // カメラの回転速度（マウス感度）

    // 縦方向の回転角度制限
    public float verticalMinAngle = -20f; // カメラが下を向く最小角度
    public float verticalMaxAngle = 60f;  // カメラが上を向く最大角度

    // 衝突処理設定
    public LayerMask collisionLayers;   // カメラが衝突をチェックするレイヤー（壁や床など）
    public float collisionOffset = 0.2f; // 壁や床との最小距離
    public float cameraSmoothSpeed = 10f; // カメラがスムーズに移動する速度

    // 内部変数
    private float currentYaw = 0f;       // 水平方向の回転角度
    private float currentPitch = 0f;     // 垂直方向の回転角度
    private Vector3 currentCameraPosition; // カメラの現在の位置

    void Start()
    {
        // カメラの初期位置を設定
        currentCameraPosition = transform.position;

        // 初期のカメラの向き（キャラクターに追従）
        currentYaw = target.eulerAngles.y;
    }

    void LateUpdate()
    {
        if (!target) return; // ターゲットが未設定の場合は何もしない

        // マウス入力を取得
        float horizontalInput = Input.GetAxis("Mouse X"); // マウスX軸の入力（水平方向）
        float verticalInput = Input.GetAxis("Mouse Y");   // マウスY軸の入力（垂直方向）

        // 水平方向の回転を更新
        currentYaw += horizontalInput * rotationSpeed;

        // 垂直方向の回転を更新し、角度制限を適用
        currentPitch -= verticalInput * rotationSpeed; // マウスYは逆方向に適用
        currentPitch = Mathf.Clamp(currentPitch, verticalMinAngle, verticalMaxAngle);

        // カメラの目標回転を計算
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);

        // 衝突処理を適用したカメラの目標位置を計算
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;
        desiredPosition = HandleCollision(target.position, desiredPosition);

        // カメラの位置をスムーズに更新
        currentCameraPosition = Vector3.Lerp(currentCameraPosition, desiredPosition, Time.deltaTime * cameraSmoothSpeed);
        transform.position = currentCameraPosition;

        // ターゲットを注視
        transform.LookAt(target.position + Vector3.up * height);
    }

    // カメラの衝突処理
    private Vector3 HandleCollision(Vector3 targetPosition, Vector3 desiredCameraPosition)
    {
        // ターゲットとカメラの間に障害物があるかチェック
        RaycastHit hit;
        if (Physics.Linecast(targetPosition + Vector3.up * height, desiredCameraPosition, out hit, collisionLayers))
        {
            // 衝突した場合、カメラの位置を衝突点の少し手前に調整
            return hit.point + hit.normal * collisionOffset;
        }

        // 衝突がない場合、目標位置をそのまま返す
        return desiredCameraPosition;
    }
}
