using UnityEngine;

namespace Gameplay
{
    public class CharacterProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private int _damage = 0;
        [SerializeField] private float _autoDestroyTimer = 60;
        private float _destroyTimer = 0;

        private Rigidbody2D _rb = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _destroyTimer = Time.time + _autoDestroyTimer;
        }

        private void Update()
        {
            if (Time.time > _destroyTimer) ProjectileHit();
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return _rb;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                var healthController = collision.gameObject.GetComponent<HealthController>();
                healthController.DoDamage(_damage);
                ProjectileHit();
            }
        }

        private void ProjectileHit()
        {

            Destroy(gameObject);
        }
    }
}
