using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;

    public static bool MuteMusic
    {
        get => PlayerPrefs.GetInt("MuteMusic", 1) != 0;
        set => PlayerPrefs.SetInt("MuteMusic", value ? 1 : 0) ;
    }
    public static bool MuteSfx 
    {
        get => PlayerPrefs.GetInt("MuteSfx", 1) != 0;
        set => PlayerPrefs.SetInt("MuteSfx", value ? 1 : 0);
    }

    private void Start()
    {
        SetMusicVolume(MuteMusic ? 0.0001f : 1);
        SetSfxVolume(MuteSfx ? 0.0001f : 1);
    }

    private void SetMusicVolume(float value)
    {
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    private void SetSfxVolume(float value)
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20);
    }

    public void ToggleMusic()
    {
        MuteMusic = !MuteMusic;
        SetMusicVolume(MuteMusic ? 0.0001f : 1);
    }

    public void ToggleSfx()
    {
        MuteSfx = !MuteSfx;
        SetSfxVolume(MuteSfx ? 0.0001f : 1);
    }

    public void ToggleSFX(bool enabled)
    {
        MuteSfx = enabled;
        SetSfxVolume(MuteSfx ? 1 : 0.0001f);
    }

    public void ToggleMusic(bool enabled)
    {
        MuteMusic = enabled;
        SetMusicVolume(MuteMusic ? 1 : 0.0001f);
    }
}
