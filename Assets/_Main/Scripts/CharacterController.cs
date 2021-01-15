using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float moveVelocity = 0;

        private float moveX = 0;
        private float moveY = 0;

        private Rigidbody2D rb = null;

        public UnityEvent OnFire;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            moveX = Input.GetAxis("Horizontal") * moveVelocity;

            if (Input.GetAxis("Fire1") > 0) OnFire?.Invoke();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveX, moveY);
        }
    }
}
