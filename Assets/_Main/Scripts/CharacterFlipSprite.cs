using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterFlipSprite : MonoBehaviour
    {
        private bool _isFacingRight = true;

        private SpriteRenderer _spriteRenderer = null;

        private void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = mousePosition.x - transform.position.x;

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
    }
}
