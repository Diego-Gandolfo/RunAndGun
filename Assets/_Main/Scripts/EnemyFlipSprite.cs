using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyFlipSprite : MonoBehaviour
    {
        [SerializeField] private bool _lookAtPlayer = false;
        [SerializeField] private CharacterController _characterController = null;
        private SpriteRenderer _spriteRenderer = null;
        private bool _isFacingRight = true;
        private Vector3 lastPosition = Vector3.zero;  

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (_lookAtPlayer)
            {
                var direction = _characterController.transform.position.x - transform.position.x;

                if (direction > 0 && !_isFacingRight)
                {
                    _isFacingRight = true;
                    _spriteRenderer.flipX = false;
                }
                else if (direction < 0 && _isFacingRight)
                {
                    _isFacingRight = false;
                    _spriteRenderer.flipX = true;
                }
            }
            else
            {
                var currentPosition = transform.position;

                if (currentPosition.x > lastPosition.x && !_isFacingRight)
                {
                    _isFacingRight = true;
                    _spriteRenderer.flipX = false;
                }
                else if (currentPosition.x < lastPosition.x && _isFacingRight)
                {
                    _isFacingRight = false;
                    _spriteRenderer.flipX = true;
                }

                lastPosition = currentPosition;
            }

        }
    }
}
