using UnityEngine;
namespace GeometryDash
{
    public class CursorLock : MonoBehaviour
    {
        [SerializeField] private bool _lockCursor;
        private void Awake()
        {
            if (_lockCursor) Cursor.lockState = CursorLockMode.Locked;
        }
    }
}