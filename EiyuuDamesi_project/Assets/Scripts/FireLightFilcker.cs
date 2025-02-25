using UnityEngine;

public class FireLightFlicker : MonoBehaviour
{
    public Light fireLight;
    public float baseIntensity = 3.0f;  // ��{�̌���
    public float intensityVariation = 2.0f;  // ��炬�͈̔�
    public float flickerSpeed = 2.0f;  // ��炬�̑���
    private float noiseOffset;

    void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light>();
        }
        noiseOffset = Random.Range(0f, 100f);  // �m�C�Y�̊J�n�n�_�������_����
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(noiseOffset, Time.time * flickerSpeed);
        fireLight.intensity = baseIntensity + noise * intensityVariation;
    }
}