using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _gameSounds;
    [SerializeField] private List<AudioSource> _gameMusic;

    private float _soundVolume;
    private float _musicVolume;

    private void Start()
    {
        _soundVolume = DataHolder.SoundVolume;
        _musicVolume = DataHolder.MusicVolume;

        for (int i = 0; i < _gameSounds.Count; i++)
        {
            _gameSounds[i].volume = _soundVolume;
        }

        for (int i = 0; i < _gameMusic.Count; i++)
        {
            _gameMusic[i].volume = _musicVolume;
        }
    }
}
