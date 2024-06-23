
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip------------")]
    public AudioClip background;
    public AudioClip walk;
    public AudioClip jump;
    public AudioClip attack;
    public AudioClip hurt;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
       
    }
    public void StopSFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Stop();

    }
    public void WalkSound() 
    {
        SFXSource.clip = walk;
        if(!SFXSource.isPlaying) SFXSource.Play();
    }
}
