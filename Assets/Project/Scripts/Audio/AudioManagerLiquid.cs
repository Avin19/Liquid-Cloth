using System;
using UnityEngine;



public class AudioManagerLiquid : MonoBehaviour
{
  [SerializeField] private AudioClip[] _audioClips;
  public static AudioManagerLiquid Instance { get; private set; }
  private AudioSource _audio;


  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
    }

    Instance = this;

    _audio = GetComponent<AudioSource>();
  }

  public void PlayPourSound()
  {
    _audio.PlayOneShot(_audioClips[1]);
  }
  public void PlaySplashSound()
  {
    _audio.PlayOneShot(_audioClips[0]);
  }
}


