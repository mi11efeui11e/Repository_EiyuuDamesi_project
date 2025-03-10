using UnityEngine;

public class OscillatingRotation : MonoBehaviour
{
    public float minAngle = -75f; // �ŏ��p�x�i���S����-75�x�j
    public float maxAngle = 75f;  // �ő�p�x�i���S����+75�x�j
    public float speed = 1f;      // ��]���x�i�����\�j

    private float angleOffset;    // ���S�p�x
    private float amplitude;      // �U��

    void Start()
    {
        angleOffset = transform.eulerAngles.y; // ���݂�Z����]����Ƃ���
        amplitude = (maxAngle - minAngle) / 2f; // �U���̌v�Z
    }

    void Update()
    {
        float angle = angleOffset + amplitude * Mathf.Sin(Time.time * speed);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, angle, transform.eulerAngles.z);
    }
}
