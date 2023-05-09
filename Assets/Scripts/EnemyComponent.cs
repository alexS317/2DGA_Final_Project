using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private Vector3 movementDistance;
    [SerializeField] private float time;

    private Vector3 _originalStartPosition;
    private Vector3 _originalTargetPosition;
    private Vector3 _currentStartPosition;
    private Vector3 _currentTargetPosition;
    private float _passedTime;
    private bool _moveForward = true;

    // Start is called before the first frame update
    void Start()
    {
        _originalStartPosition = transform.position;
        _originalTargetPosition = _originalStartPosition + movementDistance;
        ChangeMovementDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (_passedTime >= time)
        {
            ChangeMovementDirection();
        }

        // Move between positions
        transform.position = Vector3.Lerp(_currentStartPosition, _currentTargetPosition, _passedTime / time);
        _passedTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GlobalDataStorage.Instance.AttackPlayer();  // Attack the player
        
        if (GlobalDataStorage.Instance.playerLives <= 0)
        {
            ScenesManager.Instance.LoadScene(ScenesManager.Scene.EndScreen);    // Game over
        }
    }

    // Switch the movement direction
    private void ChangeMovementDirection()
    {
        if (_moveForward)
        {
            _currentStartPosition = _originalStartPosition;
            _currentTargetPosition = _originalTargetPosition;
        }
        else
        {
            _currentStartPosition = _originalTargetPosition;
            _currentTargetPosition = _originalStartPosition;
        }

        _passedTime = 0;
        _moveForward = !_moveForward;
    }
}