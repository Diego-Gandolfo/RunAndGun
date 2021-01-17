using UnityEngine;

namespace Gameplay
{
    public class CharacterShooting : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawnpoint = null;
        [SerializeField] private CharacterProjectileBehavior _prefabProjectile = null;
        [SerializeField] private float _projectileImpulse = 0;
        [SerializeField] private float _shootCooldown = 0;

        private float _shootTimer = 0;
        private bool _freeRotation = false;

        private CharacterController _characterController = null;

        private void Awake()
        {
            _characterController = GetComponentInParent<CharacterController>();
            _characterController.OnFire.AddListener(OnFireHandler);
        }

        private void Update()
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y).normalized;

            if (_freeRotation)
            {
                transform.right = direction;
            }
            else
            {
                if ((direction.x > 0.75f && direction.x <= 1f) && (direction.y > -0.25f) && (direction.y <= 0.25f))
                {
                    transform.right = new Vector2(1f, 0f); // Derecha
                }
                else if ((direction.x > 0.25f && direction.x <= 0.75f) && (direction.y > 0.25f) && (direction.y <= 0.75f))
                {
                    transform.right = new Vector2(0.5f, 0.5f); // Derecha-Arriba
                }
                else if ((direction.x > -0.25f && direction.x <= 0.25f) && (direction.y > 0.75f) && (direction.y <= 1f))
                {
                    transform.right = new Vector2(0f, 1f); // Arriba
                }
                else if ((direction.x > -0.75f && direction.x <= -0.25f) && (direction.y > 0.25f) && (direction.y <= 0.75f))
                {
                    transform.right = new Vector2(-0.5f, 0.5f); // Arriba-Izquierda
                }
                else if ((direction.x > -1f && direction.x <= -0.75f) && (direction.y > -0.25f) && (direction.y <= 0.25f))
                {
                    transform.right = new Vector2(-1f, 0f); // Izquierda
                }
                else if ((direction.x > -0.75f && direction.x <= -0.25f) && (direction.y > -0.75f) && (direction.y <= -0.25f))
                {
                    transform.right = new Vector2(-0.5f, -0.5f); // Izquierda-Abajo
                }
                else if ((direction.x > -0.25f && direction.x <= 0.25f) && (direction.y > -1f) && (direction.y <= -0.75f))
                {
                    transform.right = new Vector2(0f, -1f); // Abajo
                }
                else if ((direction.x > 0.25f && direction.x <= 0.75f) && (direction.y > -0.75f) && (direction.y <= -0.25f))
                {
                    transform.right = new Vector2(0.5f, -0.5f); // Abajo-Derecha
                }
            }
        }

        private void OnFireHandler()
        {
            if (Time.time > _shootTimer)
            {
                Shoot();
                _shootTimer = Time.time + _shootCooldown;
            }
        }

        private void Shoot()
        {
            var clone = Instantiate(_prefabProjectile, _projectileSpawnpoint.position, _projectileSpawnpoint.rotation);
            var rbClone = clone.GetRigidbody2D();
            rbClone.AddForce((Vector2)_projectileSpawnpoint.right * _projectileImpulse, ForceMode2D.Impulse);
        }
    }
}
