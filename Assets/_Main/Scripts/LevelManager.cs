using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController = null;

        [Header("Spawnpoint")]
        [SerializeField] private Transform _spawnpoint = null;

        private GameManager _gameManager = null;

        private void Awake()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            if (_gameManager != null) _gameManager.InitializeLevel(this);
        }

        public CharacterController GetCharacterController()
        {
            return _characterController;
        }

        public Transform GetSpawnpoint()
        {
            return _spawnpoint;
        }
    }
}
