using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            print("Hola?");
            var healthController = collision.gameObject.GetComponent<HealthController>();

            if (healthController != null)
            {
                var currentHealth = healthController.GetCurrentHealth();
                healthController.DoDamage(currentHealth);
            }
        }
    }
}
