using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private Transform[] _pathPoints;
    private float _moveSpeed = 0.001f;
    private int _currentPoint;

    private void Start()
    {
        _pathPoints = new Transform[_path.childCount];

        for (int i = 0; i < _pathPoints.Length; i++)
        {
            _pathPoints[i] = _path.GetComponent<Transform>().GetChild(i);
        }
    }

    private void Update()
    {
        Transform target = _pathPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _moveSpeed);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _pathPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}
