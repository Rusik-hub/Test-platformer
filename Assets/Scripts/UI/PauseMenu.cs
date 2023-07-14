using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _coinInterface;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private AudioSource _soundPressButton;

    public bool IsPausedGame { get; private set; }

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    public void RestartLevel()
    {
        _soundPressButton.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void EnablePause()
    {
        _soundPressButton.Play();
        IsPausedGame = true;
        _coinInterface.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisablePause()
    {
        _soundPressButton.Play();
        IsPausedGame = false;
        _coinInterface.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitInMainMenu()
    {
        _soundPressButton.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
