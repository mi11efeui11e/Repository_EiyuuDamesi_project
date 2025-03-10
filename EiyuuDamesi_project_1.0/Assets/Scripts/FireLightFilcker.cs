using UnityEngine;

public class FireLightFlicker : MonoBehaviour
{
    public Light fireLight;
    public float baseIntensity = 3.0f;  // 基本の光量
    public float intensityVariation = 2.0f;  // ゆらぎの範囲
    public float flickerSpeed = 2.0f;  // ゆらぎの速さ
    private float noiseOffset;

    void Start()
    {
        if (fireLight == null)
        {
            fireLight = GetComponent<Light>();
        }
        noiseOffset = Random.Range(0f, 100f);  // ノイズの開始地点をランダムに
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(noiseOffset, Time.time * flickerSpeed);
        fireLight.intensity = baseIntensity + noise * intensityVariation;
    }
}