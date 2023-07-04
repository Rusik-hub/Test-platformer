using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _collectCoinSound;
    [SerializeField] private AudioSource _deathSound;

    private int _coins = 0;

    public void AddCoin()
    {
        _coins++;
        _collectCoinSound.Play();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("You died");
            _deathSound.Play();
        }
    }

    private void OnEnable()
    {
        _coinCollector.IsCollectCoin += UpdateCoin;
    }

    private void OnDisable()
    {
        _coinCollector.IsCollectCoin -= UpdateCoin;
    }

    private void UpdateCoin()
    {
        _text.text = _coins.ToString();
    }
}
