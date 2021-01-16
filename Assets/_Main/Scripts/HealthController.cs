using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 0;
        [SerializeField] private int _currentHealth = 0;

        public UnityEvent OnDie;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void DoDamage(int amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0) Die();
        }

        public void DoHeal(int amount)
        {
            _currentHealth += amount;

            if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }

        private void Die()
        {
            OnDie.Invoke();
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}
