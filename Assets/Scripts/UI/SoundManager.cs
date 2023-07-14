using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _gameSounds;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private Player _player;

    private float _soundVolume;
    private float _musicVolume;

    private void Start()
    {
        _soundVolume = DataHolder.SoundVolume;
        _musicVolume = DataHolder.MusicVolume;

        UpdateSoundSettings();
        _backgroundMusic.Play();
    }

    private void OnEnable()
    {
        _player.PlayerDied += StopMusic;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= StopMusic;
    }

    private void StopMusic()
    {
        _backgroundMusic.Stop();
    }

    private void UpdateSoundSettings()
    {
        for (int i = 0; i < _gameSounds.Count; i++)
        {
            _gameSounds[i].volume = _soundVolume;
        }

        _backgroundMusic.volume = _musicVolume;
    }
}
