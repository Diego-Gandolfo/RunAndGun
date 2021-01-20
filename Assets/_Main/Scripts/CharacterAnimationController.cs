using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private CharacterController _characterController = null;
        private Animator _animator = null;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
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
            }
            else if (characterVelocityY < 0)
            {
                _animator.SetBool("IsJumping", false);
                _animator.SetBool("IsFalling", true);
            }
            else
            {
                _animator.SetBool("IsFalling", false);
            }

            // TODO: Animacion de Daño
        }
    }
}
