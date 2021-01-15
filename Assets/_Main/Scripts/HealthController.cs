using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 0;
        [SerializeField] private int currentHealth = 0;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public void DoDamage(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0) Die();
        }

        public void DoHeal(int amount)
        {
            currentHealth += amount;

            if (currentHealth > maxHealth) currentHealth = maxHealth;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
