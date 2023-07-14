using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Slider _sound;
    [SerializeField] private Slider _music;

    private void Start()
    {
        _sound.value = DataHolder.SoundVolume;
        _music.value = DataHolder.MusicVolume;
    }

    public void PlayGame()
    {
        //SceneTransition.SwitchToScene("SampleScene");
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
}
