using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��]���x�i�x/�b�j

    void Update()
    {
        // Z���𒆐S�ɉ�]
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
