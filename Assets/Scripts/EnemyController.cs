using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
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

        transform.position = Vector3.Lerp(_currentStartPosition, _currentTargetPosition, _passedTime / time);
        _passedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        GlobalDataStorage.Instance.AttackPlayer();
        if (GlobalDataStorage.Instance.playerLives <= 0)
        {
            Destroy(other.gameObject);
        }
    }

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