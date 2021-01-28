using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private int _maxLifes = 0;
        private int _currentLifes = 0;

        [Header("Spawnpoint")]
        private Transform _spawnpoint = null;

        private LevelManager _levelManager = null;
        private CharacterController _characterController = null;
        private HealthController _healthController = null;

        private void Start()
        {
            _currentLifes = _maxLifes;
        }

        public void InitializeLevel(LevelManager levelManager)
        {
            _levelManager = levelManager;

            _characterController = _levelManager.GetCharacterController();
            _healthController = _characterController.GetComponent<HealthController>();
            _healthController.OnDie.AddListener(OnDieHandler);

            _spawnpoint = _levelManager.GetSpawnpoint();
        }

        private void OnDieHandler()
        {
            _currentLifes--;

            if (_currentLifes <= 0)
            {
                Gameover();
            }
            else
            {
                _healthController.InitializeHealth();
                _characterController.InitializePlayerMovement();
                _healthController.gameObject.transform.position = _spawnpoint.position;
                _healthController.gameObject.transform.rotation = _spawnpoint.rotation;
            }
        }

        private void Gameover()
        {
            print("Gameover");
        }

        private void Victory()
        {
            print("Victory");
        }
    }
}
