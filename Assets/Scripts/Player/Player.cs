using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _coinCollected;
    [SerializeField] private UnityEvent _playerDied;
    [SerializeField] private AudioSource _collectCoinSound;
    [SerializeField] private AudioSource _deathSound;

    private int _coins = 0;

    public int Coins => _coins;

    public event UnityAction CoinCollected
    {
        add => _coinCollected.AddListener(value);
        remove => _coinCollected.RemoveListener(value);
    }

    public event UnityAction PlayerDied
    {
        add => _playerDied.AddListener(value);
        remove => _playerDied.RemoveListener(value);
    }

    private void CollectCoin()
    {
        _collectCoinSound.Play();
        _coins++;
        _coinCollected?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            CollectCoin();
            Destroy(collision.gameObject);
        }

        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Die();
            _playerDied?.Invoke();
        }
    }

    private void Die()
    {
        Time.timeScale = 0f;
        _deathSound.Play();
    }
}
