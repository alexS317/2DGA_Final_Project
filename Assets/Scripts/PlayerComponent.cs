using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Spine.Unity;

public class PlayerComponent : MonoBehaviour
{
    [SpineAnimation] public string idleAnimation;
    [SpineAnimation] public string runAnimation;
    [SpineAnimation] public string jumpAnimation;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpStrength = 5f;

    private Collider2D _collider;
    private Rigidbody2D _rb;
    private Vector3 _moveBy;
    private bool _isGrounded;

    private SkeletonAnimation _skeletonAnimation;
    private Spine.AnimationState _animationState;
    private Spine.Skeleton _skeleton;

    private SpriteRenderer _backgroundData;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        _animationState = _skeletonAnimation.AnimationState;
        _skeleton = _skeletonAnimation.skeleton;

        _backgroundData = GameObject.Find("Background").GetComponent<SpriteRenderer>();

        _animationState.SetAnimation(0, idleAnimation, true);
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

        if (inputValue.x == 0)
        {
            _animationState.SetAnimation(0, idleAnimation, true);
        }
        else
        {
            _animationState.SetAnimation(0, runAnimation, true);
        }

        // Flip the facing direction of the character
        if (inputValue.x > 0)
        {
            _skeleton.ScaleX = 1;
        }
        else if (inputValue.x < 0)
        {
            _skeleton.ScaleX = -1;
        }
        else
        {
            _skeleton.ScaleX = _skeleton.ScaleX;
        }
    }

    private void OnJump()
    {
        // Player can only jump if they're standing on ground
        if (_isGrounded)
        {
            _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            _animationState.SetAnimation(0, jumpAnimation, true);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player is standing on the ground
        if (other.gameObject.CompareTag("Ground"))
        {
            if (_moveBy.x == 0)
            {
                _animationState.SetAnimation(0, idleAnimation, true);
            }

            _isGrounded = true;
        }
    }

    // Prevent the player from running off the screen
    private void KeepPlayerInScreen()
    {
        Vector3 currentPosition = transform.position;

        // Get properties of the background image
        Bounds backgroundBounds = _backgroundData.bounds;
        float fieldWidth = backgroundBounds.size.x;
        float fieldHeight = backgroundBounds.size.y;
        Vector3 origin = backgroundBounds.center;

        // Calculate border positions of the background image
        float start = origin.x - fieldWidth / 2f;
        float end = origin.x + fieldWidth / 2f;
        float top = origin.y + fieldHeight / 2f;
        float bottom = origin.y - fieldHeight / 2f;
        // float start = PlayingFieldData.GetPlayingField().start;
        // float end = origin.x + fieldWidth / 2f;
        // float top = origin.y + fieldHeight / 2f;
        // float bottom = origin.y - fieldHeight / 2f;

        // Get properties of the player
        Bounds playerBounds = _collider.bounds;
        float halfWidth = playerBounds.extents.x;
        float halfHeight = playerBounds.extents.y;

        // Set player position to not move off screen
        if (currentPosition.x - halfWidth < start)
        {
            transform.position = new Vector3(start + halfWidth, currentPosition.y, currentPosition.z);
        }

        if (currentPosition.x + halfWidth > end)
        {
            transform.position = new Vector3(end - halfWidth, currentPosition.y, currentPosition.z);
        }

        // If the player falls down, the game is over
        if (currentPosition.y + halfHeight < bottom)
        {
            GlobalDataStorage.Instance.playerLives = 0;
            ScenesManager.Instance.LoadScene(ScenesManager.Scene.EndScreen);
        }
    }
}