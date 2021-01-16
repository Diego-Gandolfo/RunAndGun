using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class PlatformController : MonoBehaviour
    {
        private BoxCollider2D _boxCollider2D = null;

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        public BoxCollider2D GetBoxCollider2D()
        {
            return _boxCollider2D;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _boxCollider2D.isTrigger = true;
            }
        }
    }
}
