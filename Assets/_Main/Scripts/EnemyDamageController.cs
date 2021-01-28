using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyDamageController : MonoBehaviour
    {
        private HealthController _healthController = null;

        private void Awake()
        {
            _healthController = GetComponent<HealthController>();
            _healthController.OnHit.AddListener(OnHitHandler);
            _healthController.OnDie.AddListener(OnDieHandler);
        }

        private void OnHitHandler()
        {

        }

        private void OnDieHandler()
        {
            Destroy(gameObject);
        }
    }
}
