using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 0;
        [SerializeField] private int _currentHealth = 0;

        public UnityEvent OnHit;
        public UnityEvent OnDie;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void DoDamage(int amount)
        {
            _currentHealth -= amount;

            if (_currentHealth <= 0) Die();
            else Hit();
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

        private void Hit()
        {
            OnHit.Invoke();
        }

        public int GetCurrentHealth()
        {
            return _currentHealth;
        }
    }
}
