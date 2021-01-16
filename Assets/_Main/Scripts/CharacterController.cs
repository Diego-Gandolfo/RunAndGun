using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Gameplay
{
    public class CharacterController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _moveVelocity = 0;
        private float _moveX = 0;
        private bool _isFacingRight = true;

        [Header("Jump")]
        [SerializeField] private float _jumpImpulse = 0;
        [SerializeField] private float _moveReduction = 0;
        [SerializeField] private LayerMask _floorLayer = 0;
        [SerializeField] private float _jumpDelay = 0;
        private float _jumpTimer = 0;
        private bool _isGrounded = false;

        private SpriteRenderer _spriteRenderer = null;
        private Rigidbody2D _rb = null;

        public UnityEvent OnFire;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            _moveX = Input.GetAxis("Horizontal") * _moveVelocity;

            FlipPlayer();
            
            if (Input.GetAxis("Fire1") > 0) OnFire?.Invoke();

            if (!_isGrounded || _rb.velocity.y < 0) DetectGround();
            else if (Input.GetKeyDown(KeyCode.Space) && Time.time > _jumpTimer) DoJump();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_moveX, _rb.velocity.y);
        }

        private void DetectGround()
        {
            var rayOrigin = new Vector2(transform.position.x, transform.position. y - (transform.localScale.y / 2));
            var rayDirection = -Vector2.up;
            var rayDistance = 0.1f;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, _floorLayer);
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.blue);
            
            if (raycastHit2D)
            {
                if (raycastHit2D.collider.gameObject.CompareTag("Floor") && Time.time > _jumpTimer)
                {
                    raycastHit2D.collider.isTrigger = false;

                    if (!_isGrounded) _moveVelocity += _moveReduction;

                    _isGrounded = true;
                }
            }
        }

        private void DoJump()
        {
            _jumpTimer = Time.time + _jumpDelay;

            _rb.velocity = Vector2.zero;
            _rb.AddForce(transform.up * _jumpImpulse, ForceMode2D.Impulse);

            _moveVelocity -= _moveReduction;

            _isGrounded = false;
        }

        private void FlipPlayer()
        {
            if (_moveX > 0 && !_isFacingRight)
            {
                _isFacingRight = true;
                _spriteRenderer.flipX = false;
            }
            else if (_moveX < 0 && _isFacingRight)
            {
                _isFacingRight = false;
                _spriteRenderer.flipX = true;
            }
        }
    }
}
