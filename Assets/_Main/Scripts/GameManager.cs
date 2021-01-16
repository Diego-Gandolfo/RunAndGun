using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        [Header("Player Settings")]
        [SerializeField] private CharacterController characterController = null;
        [SerializeField] private int maxLifes = 0;
        private int currentLifes = 0;
        private HealthController healthController = null;

        private void Awake()
        {
            healthController = characterController.gameObject.GetComponent<HealthController>();
            healthController.OnDie.AddListener(OnDieHandler);
        }

        private void Start()
        {
            currentLifes = maxLifes;
        }

        private void OnDieHandler()
        {
            currentLifes--;

            if (currentLifes <= 0)
            {
                Gameover();
            }
        }



        private void Victory()
        {

        }

        private void Gameover()
        {
            print("Gameover");
        }
    }
}
