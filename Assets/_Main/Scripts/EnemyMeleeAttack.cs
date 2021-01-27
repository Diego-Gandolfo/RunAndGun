using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [SerializeField] private int _damage = 0;
        private Collider2D _collider2D = null;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var healthController = collision.GetComponent<HealthController>();

                healthController.DoDamage(_damage);
            }
        }
    }
}
