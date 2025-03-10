using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanAudioManager : MonoBehaviour
{
    public AudioSource stepAudioSource;
    public AudioSource rollAudioSource;
    public AudioSource attack1AudioSource;
    public AudioSource attack2AudioSource;
    public AudioSource attack3AudioSource;
    public AudioSource downAudioSource;
    public AudioSource deathAudioSource;

    public void PlayStepSound()
    {
        stepAudioSource.Play();
    }

    public void PlayRollSound()
    {
        rollAudioSource.Play();
    }

    public void PlayAttack1Sound()
    {
        attack1AudioSource.Play();
    }

    public void PlayAttack2Sound()
    {
        attack2AudioSource.Play();
    }

    public void PlayAttack3Sound()
    {
        attack3AudioSource.Play();
    }

    public void PlayDownSound()
    {
        downAudioSource.Play();
    }

    public void PlayDeathSound()
    {
        deathAudioSource.Play();
    }
}
