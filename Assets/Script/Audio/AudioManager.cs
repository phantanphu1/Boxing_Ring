using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [Header("--------- Audio Source--------")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("--------- Audio Clip--------")]
    [SerializeField] private AudioClip _background;
    [SerializeField] private AudioClip _punch;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        // Application.targetFrameRate = 60;
        // QualitySettings.vSyncCount = 0;

    }
    private void Start()
    {
        _musicSource.clip = _background;
        _musicSource.Play();
    }
    public void PunchMusic()
    {
        SFXSource.PlayOneShot(_punch);
    }
    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }
    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }
    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
    public void MusicVolume(float volume)
    {
        _musicSource.volume = volume;
    }
    public bool IsMusicMuted()
    {
        return _musicSource.mute;
    }

    public bool IsSFXMuted()
    {
        return SFXSource.mute;
    }
}
