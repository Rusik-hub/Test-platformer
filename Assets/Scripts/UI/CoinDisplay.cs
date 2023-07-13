using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CoinCollected += UpdateCoinCount;
    }

    private void OnDisable()
    {
        _player.CoinCollected -= UpdateCoinCount;
    }

    private void UpdateCoinCount()
    {
        _text.text = _player.Coins.ToString();
    }
}
