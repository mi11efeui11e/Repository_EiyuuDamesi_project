using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // シングルトン（オプション）

    public AudioSource audioSource; // AudioSource
    public AudioClip attackSound;  // 攻撃の音
    public AudioClip damageSound;  // ダメージの音
    public AudioClip jumpSound;    // ジャンプの音

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // SEを再生
        }
    }
}
