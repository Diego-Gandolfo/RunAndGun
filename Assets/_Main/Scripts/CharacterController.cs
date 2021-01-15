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

        [Header("Jump")]
        [SerializeField] private float jumpImpulse = 0;
        [SerializeField] private float moveReduction = 0;
        private bool canJump = false;

        private Rigidbody2D rb = null;

        public UnityEvent OnFire;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            canJump = true;
        }

        private void Update()
        {
            moveX = Input.GetAxis("Horizontal") * moveVelocity;

            if (Input.GetAxis("Fire1") > 0) OnFire?.Invoke();

            if (Input.GetKeyDown(KeyCode.Space) && canJump) DoJump();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveX, rb.velocity.y);
        }

        private void DoJump()
        {
            canJump = false;
            rb.AddForce(transform.up * jumpImpulse, ForceMode2D.Impulse);
            moveVelocity -= moveReduction;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                moveVelocity += moveReduction;
                canJump = true;
            }
        }
    }
}
