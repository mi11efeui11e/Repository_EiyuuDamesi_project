using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // 回転速度（度/秒）

    void Update()
    {
        // Z軸を中心に回転
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
