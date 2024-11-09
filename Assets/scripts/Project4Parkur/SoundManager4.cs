using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager4 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip coinClip, monsterHitClip, lifeClip, waterSplashClip, dieClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();       
    }

    public void PlayCoinSound() {

        audioSource.PlayOneShot(coinClip);
    }
    public void PlayMonsterHitSound() {
        audioSource.PlayOneShot(monsterHitClip);
    }

    public void PlayLifeSound() {
        audioSource.PlayOneShot(lifeClip);
    }

    public void PlayWaterSplashSound() {
        audioSource.PlayOneShot(waterSplashClip);
    }

    public void PlayDieSound() {
        audioSource.PlayOneShot(dieClip);
    }
}
