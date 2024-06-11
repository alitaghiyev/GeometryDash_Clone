using UnityEngine;
namespace GeometryDash.Interaction
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Portal : MonoBehaviour, IInteractable
    {
        [Tooltip("Determines the player's mode after passing through the portal")]
        [SerializeField] private PlayerMode nextPlayerMode;
        
        private void Start()
        {
            this.SetColliderAsTrigger<CircleCollider2D>();
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