using UnityEngine;
namespace GeometryDash.Interaction
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Portal : MonoBehaviour, IInteractable
    {
        [Tooltip("Portalden gectikten sonra playerin hangi modda olacagini belirler")]
        [SerializeField] private PlayerMode nextPlayerMode;

        private CircleCollider2D _collider;
        private void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _collider.isTrigger = true;
        }
        public void Interact(GameObject interactor)
        {
            if (interactor.TryGetComponent(out PlayerStateManager playerModeManager))
            {
                playerModeManager.SetState(nextPlayerMode);
            }
        }
    }
}