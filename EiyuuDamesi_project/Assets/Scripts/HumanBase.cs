using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HumanBase : CharacterBase
{
    
    public Animator animator; // Animatorコンポーネント
    public GameObject hurtBox; //キャラクターの当たり判定を一時的に無くして無敵時間を作る。

    public Image damageImage; // ダメージエフェクト用の Image
    public float fadeSpeed = 2f; // フェードアウト速度
    public float maxAlpha = 0.5f; // 最大の透明度（1.0 = 完全に不透明）

    public string nextSceneName = "NextScene"; // 遷移先のシーン名
    public float fadeDuration = 1.5f; // フェードイン・アウトの時間
    public Image fadePanel; // UIの黒いパネル（共通利用）


    private void Start()
    {
        if(DeathManager.instance.deathCheck == 1) //もし前シーンで死亡していたら体力を引き継がずに回復
        {
            HPManager.instance.ResetHP();
        }

        if (damageImage != null)
        {
            Color c = damageImage.color;
            c.a = 0f; // 最初は透明
            damageImage.color = c;
        }
    }

    public override void OnHit()
    {
        animator.SetInteger("Motion", 10);

        hurtBox.SetActive(false);
        ShowDamageEffect(); //被弾時画面を赤く点滅（４２行目から記述）
    }

    public override void OnDeath()
    {
        Debug.Log("自分が倒れた！エフェクト再生 & スコア加算");
        animator.SetInteger("Motion", 9);
        Invoke("StartFadeOutDeath", 2f);
        DeathManager.instance.deathCheck = 1;
    }


    public void ShowDamageEffect()
    {
        StartCoroutine(DamageFlash());
    }

    private IEnumerator DamageFlash()
    {
        // 画面を赤くする
        float elapsedTime = 0f;
        while (elapsedTime < 0.1f) // 0.1秒かけてフェードイン
        {
            elapsedTime += Time.deltaTime;
            Color c = damageImage.color;
            c.a = Mathf.Lerp(0, maxAlpha, elapsedTime / 0.1f);
            damageImage.color = c;
            yield return null;
        }

        // すぐにフェードアウト
        elapsedTime = 0f;
        while (elapsedTime < 0.5f) // 0.5秒かけてフェードアウト
        {
            elapsedTime += Time.deltaTime;
            Color c = damageImage.color;
            c.a = Mathf.Lerp(maxAlpha, 0, elapsedTime / 0.5f);
            damageImage.color = c;
            yield return null;
        }
    }

    private void StartFadeOutDeath()
    {
        StartCoroutine(FadeOutDeath()); // コルーチンを実行
    }

    private IEnumerator FadeOutDeath() // 死亡時透明→黒のフェードアウト
    {
        Debug.Log("死亡時フェード処理開始");
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(nextSceneName); // シーンを変更
    }


}