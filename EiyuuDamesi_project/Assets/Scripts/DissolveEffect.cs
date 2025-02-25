using UnityEngine;
using System.Collections;

public class DissolveEffect : MonoBehaviour
{
    public Material dissolveMaterial;  // Dissolve 用マテリアル
    public float dissolveSpeed = 1.0f; // 消滅速度

    private float dissolveAmount = 0f;
    private bool isDissolving = false;

    void Start()
    {
        if (dissolveMaterial == null)
        {
            dissolveMaterial = GetComponent<Renderer>().material;  // オブジェクトのマテリアルを取得
        }

        dissolveMaterial.SetFloat("_Cutoff", 0f);  // シェーダーの Dissolve パラメータを初期化

    }

    public void StartDissolve()
    {
        if (!isDissolving)
        {
            StartCoroutine(DissolveAndDestroy());
        }
    }

    private IEnumerator DissolveAndDestroy()
    {
        isDissolving = true;

        while (dissolveAmount < 1.0f)
        {
            dissolveAmount += Time.deltaTime * dissolveSpeed;
            dissolveMaterial.SetFloat("_Cutoff", dissolveAmount);  // シェーダーの Dissolve パラメータを更新
            yield return null;
        }

        Destroy(gameObject); // 完全に消えたら削除
    }
}
