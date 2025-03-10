using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // �V���O���g���i�I�v�V�����j

    public AudioSource audioSource; // AudioSource
    public AudioClip attackSound;  // �U���̉�
    public AudioClip damageSound;  // �_���[�W�̉�
    public AudioClip jumpSound;    // �W�����v�̉�

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
            audioSource.PlayOneShot(clip); // SE���Đ�
        }
    }
}
