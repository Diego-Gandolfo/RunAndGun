using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private CharacterController _characterController = null;
        private HealthController _healthController = null;
        private Animator _animator = null;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            _healthController = GetComponent<HealthController>();
            _healthController.OnHit.AddListener(OnHitHandler);

            _animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            var characterVelocityX = _characterController.GetCharacterVelocityX();

            if (characterVelocityX != 0)
            {
                _animator.SetBool("IsMoving", true);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
            }

            var characterVelocityY = _characterController.GetCharacterVelocityY();

            if (characterVelocityY > 0)
            {
                _animator.SetBool("IsJumping", true);
                _animator.SetTrigger("DoJump");
            }
            else if (characterVelocityY < 0)
            {
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsFalling", true);
                _animator.SetTrigger("DoFall");
            }
            else
            {
                _animator.SetBool("IsFalling", false);
                _animator.SetTrigger("DoGrounded");
            }
        }

        private void OnHitHandler()
        {
            _animator.SetTrigger("DoHit");
        }
    }
}
