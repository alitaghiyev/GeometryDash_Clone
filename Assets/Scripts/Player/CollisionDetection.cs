using UnityEngine;
namespace GeometryDash
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionDetection : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";

        public bool IsGround => OnGround();

        [Header("Ground Detection Box Size")]
        [SerializeField] private Vector2 _centerOfGroun;
        [SerializeField] private Vector2 _sizeOfGround;

        [Space(10)]
        [Header("Wall Detection Box Size")]
        [SerializeField] private Vector2 _centerOfWall;
        [SerializeField] private Vector2 _sizeOfWall;


        [Space(10)]
        [Header("Ground Mask")]
        [SerializeField] private LayerMask _groundMask;


        private void Update()
        {
            if (OnWall())
                EventManager.Instance.DeadEvent?.Invoke();
        }

        /// <summary>
        /// ground check for jump action
        /// It can be resized optionally, allowing for the creation of a "COYOTE" effect.
        /// </summary>
        /// <returns></returns>
        private bool OnGround()
        {
            return Physics2D.OverlapBox(
                (Vector2)transform.position + _centerOfGroun,
                _sizeOfGround, 0, _groundMask);
        }

        /// <summary>
        /// The player is positioned in front of the parent and collision with walls is controlled
        /// </summary>
        /// <returns> bool </returns>
        private bool OnWall()
        {
            return Physics2D.OverlapBox(
                (Vector2)transform.position + _centerOfWall, 
                _centerOfWall, 0, _groundMask);
        }

        /// <summary>
        /// This method checks all other collisions such as finish, portal, obstacle.
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
                interactable.Interact(this.gameObject);
            if (other.CompareTag(ObstacleTag))
                EventManager.Instance.DeadEvent?.Invoke();
        }

        
#if UNITY_EDITOR
        /// <summary>
        /// Draws debugging gizmos to visualize the OnGround and OnWall detection areas.
        /// Red gizmo represents the ground detection area.
        /// Blue gizmo represents the wall detection area.
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube((Vector2)transform.position + _centerOfGroun, _sizeOfGround);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube((Vector2)transform.position + _centerOfWall, _sizeOfWall);
        }
#endif
    }
}