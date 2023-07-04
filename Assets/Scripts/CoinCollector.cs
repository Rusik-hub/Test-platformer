using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private UnityEvent _isCollectCoin;

    public event UnityAction IsCollectCoin
    {
        add => _isCollectCoin.AddListener(value);
        remove => _isCollectCoin.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            Destroy(collision.gameObject);
            _isCollectCoin?.Invoke();
        }
    }
}
