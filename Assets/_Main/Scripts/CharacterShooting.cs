using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnpoint = null;
        [SerializeField] private CharacterProjectileBehavior _prefabProjectile = null;
        [SerializeField] private float _projectileImpulse = 0;
        [SerializeField] private float _shootCooldown = 0;

        private float _shootTimer = 0;

        private CharacterController _characterController = null;

        private void Awake()
        {
            _characterController = GetComponentInParent<CharacterController>();
            _characterController.OnFire.AddListener(OnFireHandler);
        }

        private void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse
            var direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.right = direction;
        }

        private void OnFireHandler()
        {
            if (Time.time > _shootTimer)
            {
                Shoot();
                _shootTimer = Time.time + _shootCooldown;
            }
        }

        private void Shoot()
        {
            var clone = Instantiate(_prefabProjectile, _projectileSpawnpoint.position, _projectileSpawnpoint.rotation);
            var rbClone = clone.GetRigidbody2D();
            rbClone.AddForce((Vector2)_projectileSpawnpoint.right * _projectileImpulse, ForceMode2D.Impulse);
        }
    }
}
