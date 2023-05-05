using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpStrength = 5f;

    private Collider2D _collider;
    private Rigidbody2D _rb;
    private Vector3 _moveBy;
    private bool _isGrounded = false;

    private SpriteRenderer _backgroundData;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        _backgroundData = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player
        transform.Translate(_moveBy * (speed * Time.deltaTime));

        KeepPlayerInScreen();
    }

    private void OnMove(InputValue input)
    {
        Vector2 inputValue = input.Get<Vector2>();
        _moveBy = new Vector3(inputValue.x, 0, 0);
    }

    private void OnJump()
    {
        // Player can only jump if they're standing on ground
        if (_isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player is standing on the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void KeepPlayerInScreen()
    {
        // Get properties of the background image
        float fieldWidth = _backgroundData.bounds.size.x;
        float fieldHeight = _backgroundData.bounds.size.y;
        Vector3 origin = _backgroundData.bounds.center;

        // Calculate border positions of the background image
        float start = origin.x - fieldWidth / 2f;
        float end = origin.x + fieldWidth / 2f;
        float top = origin.y + fieldHeight / 2f;
        float bottom = origin.y - fieldHeight / 2f;

        // Get properties of the player
        float halfWidth = _collider.bounds.extents.x;
        float halfHeight = _collider.bounds.extents.y;

        // Set player position
        if (transform.position.x - halfWidth < start)
        {
            transform.position = new Vector3(start + halfWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x + halfWidth > end)
        {
            transform.position = new Vector3(end - halfWidth, transform.position.y, transform.position.z);
        }
    }
}