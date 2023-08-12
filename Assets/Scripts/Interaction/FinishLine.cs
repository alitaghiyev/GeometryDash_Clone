using UnityEngine;

namespace GeometryDash
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class FinishLine : MonoBehaviour, IInteractable
    {
        private BoxCollider2D _collider;
        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
        }
        public void Interact(GameObject interactor)
        {
            EventManager.i.FinishEvent?.Invoke();
        }
    }
}
