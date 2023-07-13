using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _coinsInterface;
    [SerializeField] private GameObject _pauseMenu;

    private AudioSource _soundPressButton;

    public bool IsPausedGame { get; private set; }

    private void Start()
    {
        _soundPressButton = GetComponent<AudioSource>();
    }

    public void EnablePause()
    {
        _soundPressButton.Play();
        IsPausedGame = true;
        _coinsInterface.SetActive(false);
        _pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DisablePause()
    {
        _soundPressButton.Play();
        IsPausedGame = false;
        _coinsInterface.SetActive(true);
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitInMainMenu()
    {
        _soundPressButton.Play();
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
