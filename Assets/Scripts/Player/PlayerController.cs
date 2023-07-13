using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

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

        if (Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                _animator.SetTrigger("Walk");
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                _animator.SetTrigger("Walk");
            }
        }
    }
}
