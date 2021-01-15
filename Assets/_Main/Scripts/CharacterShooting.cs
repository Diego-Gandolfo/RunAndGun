using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private Transform projectileSpawnpoint = null;
        [SerializeField] private CharacterProjectileBehavior prefabProjectile = null;
        [SerializeField] private float projectileImpulse = 0;
        [SerializeField] private float shootCooldown = 0;

        private float shootTimer = 0;

        private CharacterController characterController = null;

        private void Awake()
        {
            characterController = GetComponentInParent<CharacterController>();
            characterController.OnFire.AddListener(OnFireHandler);
        }

        private void Update()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Almacenamos las coordenadas de donde se encuentra el puntero del Mouse
            Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.right = direction;
        }

        private void OnFireHandler()
        {
            if (Time.time > shootTimer)
            {
                Shoot();
                shootTimer = Time.time + shootCooldown;
            }
        }

        private void Shoot()
        {
            CharacterProjectileBehavior clone = Instantiate(prefabProjectile, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            Rigidbody2D rbClone = clone.GetRigidbody2D();
            rbClone.AddForce((Vector2)projectileSpawnpoint.right * projectileImpulse, ForceMode2D.Impulse);
        }
    }
}
