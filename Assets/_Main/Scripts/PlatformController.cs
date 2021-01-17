using UnityEngine;

namespace Gameplay
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField] private Collider2D platformCollider = null;

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                platformCollider.isTrigger = true;
            }
        }
    }
}
