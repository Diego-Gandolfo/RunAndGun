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
        private float _moveVelocityOriginal = 0;
        private float _moveX = 0;

        [Header("Jump")]
        [SerializeField] private float _jumpImpulse = 0;
        [SerializeField] private float _moveReduction = 0;
        [SerializeField] private LayerMask _floorLayer = 0;
        [SerializeField] private float _jumpDelay = 0;
        private float _jumpTimer = 0;
        private bool _isGrounded = true;


        private Rigidbody2D _rb = null;

        public UnityEvent OnFire;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _moveVelocityOriginal = _moveVelocity;
        }

        private void Update()
        {
            _moveX = Input.GetAxis("Horizontal") * _moveVelocity;
            
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

            var raycastHit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, _floorLayer);
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

        public void InitializePlayer()
        {
            _rb.velocity = Vector2.zero;
            _moveVelocity = _moveVelocityOriginal;
            _moveX = 0;
            _isGrounded = true;
        }
    }
}
