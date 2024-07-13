using UnityEngine;



public class AudioManageCloth : MonoBehaviour
{
    public static AudioManageCloth Instance { get; private set; }
    private AudioSource _audio;
    [SerializeField] private AudioClip _cloth;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }

        Instance = this;

        _audio = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audio.clip = _cloth;
 
        _audio.Play(0);
    }

    public void Stop()
    {
        _audio.Stop();
    }

}


