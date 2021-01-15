using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile;

namespace Character
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private Transform projectileSpawnpoint = null;
        [SerializeField] private ProjectileBehavior prefabProjectile = null;
        [SerializeField] private float projectileImpulse = 0;
        [SerializeField] private float shootCooldown = 0;

        private float shootTimer = 0;

        private CharacterController characterController = null;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            characterController.OnFire.AddListener(OnFireHandler);
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
            ProjectileBehavior clone = Instantiate(prefabProjectile, projectileSpawnpoint.position, projectileSpawnpoint.rotation);
            Rigidbody2D rbClone = clone.GetRigidbody2D();
            rbClone.AddForce((Vector2)projectileSpawnpoint.right * projectileImpulse, ForceMode2D.Impulse);
        }
    }
}
