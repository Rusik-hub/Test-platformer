using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider _sound;
    [SerializeField] private Slider _music;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void MoveSoundVolume(float volume)
    {
        DataHolder.SoundVolume = volume;
    }

    public void MoveMusicVolume(float volume)
    {
        DataHolder.MusicVolume = volume;
    }

    private void Start()
    {
        _sound.value = DataHolder.SoundVolume;
        _music.value = DataHolder.MusicVolume;
    }
}
