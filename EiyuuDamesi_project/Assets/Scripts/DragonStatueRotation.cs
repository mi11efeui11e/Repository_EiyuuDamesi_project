using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public float minAngle = -75f; // 最小角度（中心から-75度）
    public float maxAngle = 75f;  // 最大角度（中心から+75度）
    public float speed = 1f;      // 回転速度（調整可能）

    private float angleOffset;    // 中心角度
    private float amplitude;      // 振幅

    void Start()
    {
        angleOffset = transform.eulerAngles.y; // 現在のZ軸回転を基準とする
        amplitude = (maxAngle - minAngle) / 2f; // 振幅の計算
    }

    void Update()
    {
        float angle = angleOffset + amplitude * Mathf.Sin(Time.time * speed);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}
