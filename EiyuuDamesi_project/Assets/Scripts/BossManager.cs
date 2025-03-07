using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{

    public AudioSource bossAudioSource;
    public GameObject bossHPBar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[�̂ݔ���
        {
            PlayBossSound();
            bossHPBar.SetActive(true);
        }
    }

    public void PlayBossSound()
    {
        bossAudioSource.Play();
    }

}
