using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource m_AudioSource;
    public AudioClip attackClip;
    public AudioClip iddleClip;
    public AudioClip damageClip;
    public AudioClip effectClip;
    public AudioClip deathClip;

    void Start()
    {
       m_AudioSource = GetComponent<AudioSource>(); 
    }

    
    void Update()
    {
            
    }

    public void AttackAudio()
    {
       m_AudioSource.clip = attackClip;
       m_AudioSource.Play();
    }

    public void IddleAudio()
    {
        m_AudioSource.clip = iddleClip;
        m_AudioSource.Play();
    }

    public void RecibeDamage()
    {
        m_AudioSource.clip = damageClip;
        m_AudioSource.Play();

    }
}
