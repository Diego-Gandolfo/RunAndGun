using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectile
{
    public class ProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private float autoDestroyTimer = 60;
        private float destroyTimer = 0;

        private Rigidbody2D rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            destroyTimer = Time.time + autoDestroyTimer;
        }

        private void Update()
        {
            if (Time.time > destroyTimer) Explote();
        }

        public Rigidbody2D GetRigidbody2D()
        {
            return rb;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Explote();
        }

        private void Explote()
        {
            Destroy(gameObject);
        }
    }
}
