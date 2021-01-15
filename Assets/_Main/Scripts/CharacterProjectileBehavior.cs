using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CharacterProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private int damage = 0;
        [SerializeField] private float autoDestroyTimer = 60;
        private float destroyTimer = 0;

        private Rigidbody2D rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            destroyTimer = Time.time + autoDestroyTimer;
        }

        private void Update()
        {
            if (Time.time > destroyTimer) ProjectileHit();
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rb;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                HealthController healthController = collision.gameObject.GetComponent<HealthController>();
                healthController.DoDamage(damage);
                ProjectileHit();
            }
        }

        private void ProjectileHit()
        {

            Destroy(gameObject);
        }
    }
}
