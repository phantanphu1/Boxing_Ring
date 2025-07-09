using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    // --- Biến mới cho nút chuyển đổi nhạc ---
    [Header("Music Toggle Button")]
    [SerializeField] private Image _musicToggleButtonImage;
    [SerializeField] private Sprite _musicOnSprite;
    [SerializeField] private Sprite _musicOffSprite;

    // --- Biến mới cho nút chuyển đổi SFX ---
    [Header("SFX Toggle Button")]
    [SerializeField] private Image _sfxToggleButtonImage;
    [SerializeField] private Sprite _sfxOnSprite;
    [SerializeField] private Sprite _sfxOffSprite;
    private void Start()
    {
        UpdateMusicToggleButtonImage(AudioManager.Instance.IsMusicMuted());
        UpdateSFXToggleButtonImage(AudioManager.Instance.IsSFXMuted());
    }
    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        UpdateMusicToggleButtonImage(AudioManager.Instance.IsMusicMuted());
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        UpdateSFXToggleButtonImage(AudioManager.Instance.IsSFXMuted());

    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
    private void UpdateMusicToggleButtonImage(bool isMuted)
    {
        if (_musicToggleButtonImage == null) return;
        _musicToggleButtonImage.sprite = isMuted ? _musicOffSprite : _musicOnSprite;
    }

    private void UpdateSFXToggleButtonImage(bool isMuted)
    {
        if (_sfxToggleButtonImage == null) return;
        _sfxToggleButtonImage.sprite = isMuted ? _sfxOffSprite : _sfxOnSprite;
    }
}
