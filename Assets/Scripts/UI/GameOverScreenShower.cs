using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class GameOverScreenShower : MonoBehaviour
{
    [SerializeField] private Player _player;

    private CanvasGroup _gameOverScreen;

    private void Start()
    {
        _gameOverScreen = GetComponent<CanvasGroup>();
        _gameOverScreen.alpha = 0f;
    }

    private void OnEnable()
    {
        _player.PlayerDied += ShowGameOverScreen;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        _gameOverScreen.alpha = 1f;
    }
}
