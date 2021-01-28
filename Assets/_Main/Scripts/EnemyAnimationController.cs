using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyAnimationController : MonoBehaviour
    {
        private HealthController _healthController = null;
        private Animator _animator = null;

        private void Awake()
        {
            _healthController = GetComponent<HealthController>();
            _healthController.OnHit.AddListener(OnHitHandler);
            _healthController.OnDie.AddListener(OnDieHandler);

            _animator = GetComponentInChildren<Animator>();
        }

        private void OnHitHandler()
        {
            _animator.SetTrigger("DoHit");
        }

        private void OnDieHandler()
        {
            Destroy(gameObject);
        }
    }
}
