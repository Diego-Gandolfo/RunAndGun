using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class EnemyMaskController : MonoBehaviour
    {
        [SerializeField] private Transform _pointA, _pointB;
        [SerializeField] private float _velocity = 0f;
        private float _time;
        private float _currentVelocity;

        private void Start()
        {
            _time = 0.5f;
            _currentVelocity = _velocity;
        }

        private void Update()
        {
            if (_time >= 1)
            {
                _currentVelocity = _velocity * -1;
            }
            else if (_time <= 0)
            {
                _currentVelocity = _velocity;
            }

            _time += Time.deltaTime * _currentVelocity;

            transform.position = new Vector2(Mathf.Lerp(_pointA.position.x, _pointB.position.x, _time), transform.position.y);
        }
    }
}
