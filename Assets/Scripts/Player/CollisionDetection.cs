using UnityEngine;
namespace GeometryDash
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class CollisionDetection : MonoBehaviour
    {
        private const string ObstacleTag = "Obstacle";

        public bool IsGround { get { return OnGround(); } }

        [Header("Ground Detection Box Size")]
        [SerializeField] private Vector2 _centerOfGroun;
        [SerializeField] private Vector2 _sizeOfGround;

        [Space(10)]
        [Header("Wall Detection Box Size")]
        [SerializeField] private Vector2 _centerOfWall;
        [SerializeField] private Vector2 _sizeOfWall;


        [Space(10)]
        [Header("Groun Mask")]
        [SerializeField] private LayerMask _groundMask;


        private void Update()
        {
            if (OnWall()) EventManager.i.DeadEvent?.Invoke();
        }

        /// <summary>
        /// ziplama eventi tetiklendiginde ground kontrolu yapar
        /// istege bagli olarak boyutlandirila bilir bu sayede coyote etkisi yaratir
        /// </summary>
        /// <returns></returns>
        private bool OnGround()
        {
            return Physics2D.OverlapBox((Vector2)transform.position + _centerOfGroun, _sizeOfGround, 0, _groundMask);
        }

        /// <summary>
        /// player parentinin on kisminda konumlandirilir playerin duvarlara onden temasi zamani game over olur
        /// </summary>
        /// <returns></returns>
        private bool OnWall()
        {
            return Physics2D.OverlapBox((Vector2)transform.position + _centerOfWall, _centerOfWall, 0, _groundMask);
        }

        /// <summary>
        /// Bu metod diger tum carpismalari kontrol eder
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteractable interactable))//finish, portal, ....
            {
                interactable.Interact(this.gameObject);
            }
            if (other.CompareTag(ObstacleTag))
            {
                EventManager.i.DeadEvent?.Invoke();
            }
        }



#if UNITY_EDITOR
        /// <summary>
        /// Draw OnGround and OnWall 
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