using UnityEngine;

namespace GeometryDash
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FinishLine : MonoBehaviour, IInteractable
    {
        private void Start()
        {
            this.SetColliderAsTrigger<BoxCollider2D>();
        }
        public void Interact(GameObject interactor)
        {
            EventManager.Instance.FinishEvent?.Invoke();
        }
    }
}
