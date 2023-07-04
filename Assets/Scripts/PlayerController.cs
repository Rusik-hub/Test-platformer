using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _speed = 5f;
    private Rigidbody2D _rb2d;

    private void OnEnable()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal");

        _rb2d.velocity = new Vector2(horizontalMove * _speed, _rb2d.velocity.y);
    }
}
